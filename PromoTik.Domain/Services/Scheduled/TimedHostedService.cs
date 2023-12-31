using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PromoTik.Domain.Entities;
using PromoTik.Domain.Entities.Scheduled;
using PromoTik.Domain.Interfaces.Repositories;
using PromoTik.Domain.Interfaces.Services;
using PromoTik.Domain.Interfaces.Services.Scheduled;

namespace PromoTik.Domain.Services.Scheduled
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<TimedHostedService> _logger;
        private IServiceScopeFactory _serviceScopeFactory;
        private Timer? _timerLineExecution = null;
        private Timer? _timerRemoveOldChats = null;

        public TimedHostedService(ILogger<TimedHostedService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    IGeneralConfigurationRepo generalConfigurationRepo;
                    generalConfigurationRepo = scope.ServiceProvider.GetRequiredService<IGeneralConfigurationRepo>();

                    List<GeneralConfiguration>? generalConfigurations = generalConfigurationRepo.Get(Globalization.EXECUTION_TIME_INTERVAL);

                    if (generalConfigurations != null)
                    {
                        TimeSpan timeSpanLineExecution = TimeSpan.FromMinutes(Convert.ToInt16(generalConfigurations.First().Value1));

                        _timerRemoveOldChats = new Timer((e) => DoWorkRemoveOldChats(e), null, TimeSpan.FromDays(1), TimeSpan.FromDays(1));
                        _timerLineExecution = new Timer(async (e) => await DoWorkLineExecution(e), null, TimeSpan.Zero, timeSpanLineExecution);

                        return Task.CompletedTask;
                    }
                    else
                    {
                        return Task.FromException(new Exception("Configuração inexistente: EXECUTION_TIME_INTERVAL."));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return Task.FromException(ex);
            }
        }

        private async Task DoWorkLineExecution(object? state)
        {
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    IPublishingChannelService publishingChannelService;
                    publishingChannelService = scope.ServiceProvider.GetRequiredService<IPublishingChannelService>();
                    List<PublishingChannel> publishingChannels = publishingChannelService.GetAll() ?? new List<PublishingChannel>();

                    foreach (PublishingChannel publishingChannel in publishingChannels)
                    {
                        ILineExecutionService lineExecutionService;
                        lineExecutionService = scope.ServiceProvider.GetRequiredService<ILineExecutionService>();

                        LineExecution? lineExecution = await lineExecutionService.GetNext(publishingChannel);

                        if (lineExecution != null && lineExecution.PublishChatMessage != null)
                        {
                            IAppsConnectionControlService appsConnectionControlService;
                            appsConnectionControlService = scope.ServiceProvider.GetRequiredService<IAppsConnectionControlService>();

                            try
                            {
                                lineExecution.ExecutionDate = DateTime.Now;

                                if (await appsConnectionControlService.PublishMessageToApps(lineExecution.PublishChatMessage) == null)
                                {
                                    lineExecutionService.Update(lineExecution);
                                }
                            }
                            catch (Exception ex)
                            {
                                lineExecution.Priority = -99;
                                lineExecutionService.Update(lineExecution);
                                throw new Exception($"Erro na fila com ID: {lineExecution.ID}.", ex);
                            }
                        }
                    }

                    var count = Interlocked.Increment(ref executionCount);

                    _logger.LogInformation(
                        "Timed Hosted Service is working. Line execution count: {Count}", count);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
        }

        private void DoWorkRemoveOldChats(object? state)
        {
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    IPublishChatMessageService publishChatMessageService;
                    publishChatMessageService = scope.ServiceProvider.GetRequiredService<IPublishChatMessageService>();

                    publishChatMessageService.RemoveOldItens();
                }

                _logger.LogInformation("Old Chats removed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timerLineExecution?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timerLineExecution?.Dispose();
        }
    }
}
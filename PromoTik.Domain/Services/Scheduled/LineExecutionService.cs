using PromoTik.Domain.Entities;
using PromoTik.Domain.Entities.Scheduled;
using PromoTik.Domain.Interfaces.Repositories;
using PromoTik.Domain.Interfaces.Repositories.Scheduled;
using PromoTik.Domain.Interfaces.Services;
using PromoTik.Domain.Interfaces.Services.Scheduled;

namespace PromoTik.Domain.Services.Scheduled
{
    public class LineExecutionService : ILineExecutionService
    {
        private readonly ILineExecutionRepo LineExecutionRepo;
        private readonly IAppsConnectionControlService AppsConnectionControlService;
        private readonly IGeneralConfigurationRepo GeneralConfigurationRepo;

        public LineExecutionService(ILineExecutionRepo lineExecutionRepo,
                                    IAppsConnectionControlService appsConnectionControlService,
                                    IGeneralConfigurationRepo generalConfigurationRepo)
        {
            this.GeneralConfigurationRepo = generalConfigurationRepo;
            this.AppsConnectionControlService = appsConnectionControlService;
            this.LineExecutionRepo = lineExecutionRepo;
        }

        public LineExecution? GetById(int ID)
        {
            try
            {
                return LineExecutionRepo.GetById(ID);
            }
            catch { throw; }
        }

        public async Task<LineExecution?> GetNext()
        {
            try
            {
                LineExecution? lineExecution = LineExecutionRepo.GetNext();

                if (lineExecution == null)
                {
                    lineExecution = await AddNewsLineExecution();
                }

                return lineExecution;
            }
            catch { throw; }
        }

        public LineExecution? Add(LineExecution lineExecution)
        {
            try
            {
                LineExecution? lineExecutionAdded = LineExecutionRepo.Add(lineExecution);

                return LineExecutionRepo.SaveChanges() ? lineExecutionAdded : null;
            }
            catch { throw; }
        }

        public LineExecution? Update(LineExecution lineExecution)
        {
            try
            {
                LineExecution? lineExecutionUpdated = LineExecutionRepo.Update(lineExecution);

                return LineExecutionRepo.SaveChanges() ? lineExecutionUpdated : null;
            }
            catch { throw; }
        }

        private async Task<LineExecution?> AddNewsLineExecution()
        {
            LineExecution? lineExecution = null;
            List<LineExecution> lineExecutions = new List<LineExecution>();

            List<GeneralConfiguration>? generalConfigurationAmazonUrls = GeneralConfigurationRepo.Get(Globalization.AMAZON_URL_EXECUTION);
            string? amazonTag = GeneralConfigurationRepo.Get(Globalization.AFFILIATED_AMAZON_TAG)?.FirstOrDefault()?.Value1;
            GeneralConfiguration? generalConfigurationCurrentPage = GeneralConfigurationRepo.Get(Globalization.CURRENT_PAGE)?.FirstOrDefault();
            _ = int.TryParse(generalConfigurationCurrentPage?.Value1, out int currentPage);
            _ = int.TryParse(GeneralConfigurationRepo.Get(Globalization.MAX_PAGE)?.FirstOrDefault()?.Value1, out int maxPage);

            foreach (GeneralConfiguration generalConfigurationAmazonUrl in generalConfigurationAmazonUrls ?? new List<GeneralConfiguration>())
            {
                if (generalConfigurationCurrentPage != null && amazonTag != null && currentPage <= maxPage)
                {
                    var url = $"{generalConfigurationAmazonUrl.Value1}&tag={amazonTag}&pg={currentPage}";

                    List<PublishChatMessage> publishChatMessages = await AppsConnectionControlService.GetPublishChatMessagesAsync(url, amazonTag);

                    for (int i = 0; i < publishChatMessages.Count; i++)
                    {
                        lineExecutions.Add(new LineExecution
                        {
                            PublishChatMessage = publishChatMessages[i],
                            Type = Enum.ExecutionTypes.Normal,
                            Priority = i
                        });
                    }
                }
            }

            if (lineExecutions.Count > 0)
            {
                LineExecutionRepo.AddRange(lineExecutions.DistinctBy(x => x.PublishChatMessage.Title).ToList());
            }

            if (generalConfigurationCurrentPage != null)
            {
                currentPage++;
                generalConfigurationCurrentPage.Value1 = currentPage < maxPage ? currentPage.ToString() : "1";
                GeneralConfigurationRepo.Update(generalConfigurationCurrentPage);
            }

            if (generalConfigurationAmazonUrls?.Count > 0)
            {
                lineExecution = LineExecutionRepo.GetNext();
            }

            return lineExecution;
        }
    }
}
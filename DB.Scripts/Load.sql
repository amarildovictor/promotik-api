INSERT INTO PUBLISHING_APP VALUES('Telegram @promotik_bot', 'https://api.telegram.org/bot6359763642:AAHrK2X-Vv64DVc3gezPYMvOTDOPQZsjlbg/sendPhoto')
GO

INSERT INTO WAREHOUSE VALUES('Amazon')
GO

INSERT INTO PUBLISHING_CHANNEL VALUES ('PromoTik - Geral', '-1001633460618', (SELECT ID FROM PUBLISHING_APP WHERE Description = 'Telegram @promotik_bot'))
GO

INSERT INTO PUBLISHING_CHANNEL_PARAMETERS SELECT 'chat_id', Channel_ID, ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik - Geral'
GO

INSERT INTO PUBLISHING_CHANNEL_PARAMETERS VALUES ('parse_mode', 'html', (SELECT ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik - Geral'))
GO

INSERT INTO GENERAL_CONFIGURATION VALUES ('Intervalo de tempo de execução dos itens da fila', 'EXECUTION_TIME_INTERVAL', 5, null)
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Os Mais Vendidos da Amazon ES', 'AMAZON_URL_EXECUTION', 'https://www.amazon.es/-/pt/gp/bestsellers/videogames/ref=zg_bs_pg_2_videogames?ie=UTF8', null)
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Novos Lançamentos da Amazon ES', 'AMAZON_URL_EXECUTION', 'https://www.amazon.es/-/pt/gp/new-releases/videogames/ref=zg_bsnr_pg_2_videogames?ie=UTF8', null)
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Os Mais Desejados da Amazon ES', 'AMAZON_URL_EXECUTION', 'https://www.amazon.es/-/pt/gp/most-wished-for/videogames/ref=zg_mw_pg_1_videogames?ie=UTF8', null)
INSERT INTO GENERAL_CONFIGURATION VALUES('Tag de afiliado Amazon ES', 'AFFILIATED_AMAZON_TAG', 'cutty0c-21', null)
INSERT INTO GENERAL_CONFIGURATION VALUES('Página de execução atual da fila', 'CURRENT_PAGE', '1', null)
INSERT INTO GENERAL_CONFIGURATION VALUES('Máximo de páginas a executar', 'MAX_PAGE', '4', null)
GO

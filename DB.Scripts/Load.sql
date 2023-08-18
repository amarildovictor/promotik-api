INSERT INTO PUBLISHING_APP VALUES('Telegram @promotik_bot', 'https://api.telegram.org/bot6359763642:AAHrK2X-Vv64DVc3gezPYMvOTDOPQZsjlbg/sendPhoto')
GO

INSERT INTO WAREHOUSE VALUES('Amazon')
GO

INSERT INTO PUBLISHING_CHANNEL VALUES ('PromoTik para Mulheres', '-1001633460618', (SELECT ID FROM PUBLISHING_APP WHERE Description = 'Telegram @promotik_bot'), 0)
INSERT INTO PUBLISHING_CHANNEL VALUES ('PromoTik Nerds - Br', '-1001894891157', (SELECT ID FROM PUBLISHING_APP WHERE Description = 'Telegram @promotik_bot'), 1)
INSERT INTO PUBLISHING_CHANNEL VALUES ('PromoTik para Mulheres - Br', '-1001869399956', (SELECT ID FROM PUBLISHING_APP WHERE Description = 'Telegram @promotik_bot'), 1)
GO

--Inserts sobre assunto de produtos para Gamers
-- INSERT INTO GENERAL_CONFIGURATION VALUES('Url Os Mais Vendidos da Amazon ES', 'AMAZON_URL_EXECUTION', 'https://www.amazon.es/-/pt/gp/bestsellers/videogames/ref=zg_bs_pg_2_videogames?ie=UTF8', '1')
-- INSERT INTO GENERAL_CONFIGURATION VALUES('Url Novos Lançamentos da Amazon ES', 'AMAZON_URL_EXECUTION', 'https://www.amazon.es/-/pt/gp/new-releases/videogames/ref=zg_bsnr_pg_2_videogames?ie=UTF8', '1')
-- INSERT INTO GENERAL_CONFIGURATION VALUES('Url Os Mais Desejados da Amazon ES', 'AMAZON_URL_EXECUTION', 'https://www.amazon.es/-/pt/gp/most-wished-for/videogames/ref=zg_mw_pg_1_videogames?ie=UTF8', '1')
-- GO

-- Inserts sobre o assunto de produtos para mulheres - ES
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Os Mais Vendidos (Beleza) da Amazon ES', 'AMAZON_URL_EXECUTION', 'https://www.amazon.es/-/pt/gp/bestsellers/beauty', '1')
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Os Mais Vendidos (Moda mulher) da Amazon ES', 'AMAZON_URL_EXECUTION', 'https://www.amazon.es/-/pt/gp/bestsellers/fashion/5517558031', '1')
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Novos Lançamentos (Beleza) da Amazon ES', 'AMAZON_URL_EXECUTION', 'https://www.amazon.es/-/pt/gp/new-releases/beauty', '1')
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Novos Lançamentos (Moda mulher) da Amazon ES', 'AMAZON_URL_EXECUTION', 'https://www.amazon.es/-/pt/gp/new-releases/fashion/5517558031', '1')
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Os Mais Desejados (Beleza) da Amazon ES', 'AMAZON_URL_EXECUTION', 'https://www.amazon.es/-/pt/gp/most-wished-for/beauty', '1')
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Os Mais Desejados (Moda mulher) da Amazon ES', 'AMAZON_URL_EXECUTION', 'https://www.amazon.es/-/pt/gp/most-wished-for/fashion/5517558031', '1')
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Termômetro de vendas (Beleza) da Amazon ES', 'AMAZON_URL_EXECUTION', 'https://www.amazon.es/-/pt/gp/movers-and-shakers/beauty', '1')
INSERT INTO GENERAL_CONFIGURATION VALUES('Tag de afiliado Amazon ES', 'AFFILIATED_AMAZON_TAG', 'cutty0c-21', '1')
INSERT INTO GENERAL_CONFIGURATION VALUES('Página de execução atual da fila', 'CURRENT_PAGE', '1', '1')
INSERT INTO GENERAL_CONFIGURATION VALUES('Máximo de páginas a executar', 'MAX_PAGE', '4', '1')
GO

INSERT INTO PUBLISHING_CHANNEL_PARAMETERS SELECT 'chat_id', Channel_ID, ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik para Mulheres'
INSERT INTO PUBLISHING_CHANNEL_PARAMETERS VALUES ('parse_mode', 'html', (SELECT ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik para Mulheres'))
GO

-- Insert sobre o assunto de produtos para Nerds - BR
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Os Mais Vendidos da área de games da Amazon BR', 'AMAZON_URL_EXECUTION', 'https://www.amazon.com.br/gp/bestsellers/videogames', 2)
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Os Mais Vendidos (quadrinhos) da Amazon BR', 'AMAZON_URL_EXECUTION', 'https://www.amazon.com.br/gp/bestsellers/books/7842710011', 2)
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Os Mais Vendidos (figure action) da Amazon BR', 'AMAZON_URL_EXECUTION', 'https://www.amazon.com.br/gp/bestsellers/toys/16746942011', 2)
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Novidades (games) da Amazon BR', 'AMAZON_URL_EXECUTION', 'https://www.amazon.com.br/gp/new-releases/videogames', 2)
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Novidades (quadrinhos) da Amazon BR', 'AMAZON_URL_EXECUTION', 'https://www.amazon.com.br/gp/new-releases/books/7842710011', 2)
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Novidades (figure actions) da Amazon BR', 'AMAZON_URL_EXECUTION', 'https://www.amazon.com.br/gp/new-releases/toys/16746942011', 2)
INSERT INTO GENERAL_CONFIGURATION VALUES('Tag de afiliado Amazon BR', 'AFFILIATED_AMAZON_TAG', 'promotikbr-20', 2)
INSERT INTO GENERAL_CONFIGURATION VALUES('Página de execução atual da fila Amazon BR', 'CURRENT_PAGE', '1', 2)
INSERT INTO GENERAL_CONFIGURATION VALUES('Máximo de páginas a executar Amazon BR', 'MAX_PAGE', '4', 2)
GO

INSERT INTO PUBLISHING_CHANNEL_PARAMETERS SELECT 'chat_id', Channel_ID, ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik Nerds - Br'
INSERT INTO PUBLISHING_CHANNEL_PARAMETERS VALUES ('parse_mode', 'html', (SELECT ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik Nerds - Br'))
GO

-- Insert sobre o assunto de produtos para Mulheres - BR
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Os Mais Vendidos (Beleza) da Amazon BR', 'AMAZON_URL_EXECUTION', 'https://www.amazon.com.br/gp/bestsellers/beauty', (SELECT ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik para Mulheres - Br'))
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Os Mais Vendidos (Moda) da Amazon BR', 'AMAZON_URL_EXECUTION', 'https://www.amazon.com.br/gp/bestsellers/fashion/17681969011', (SELECT ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik para Mulheres - Br'))
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Novidades (Beleza) da Amazon BR', 'AMAZON_URL_EXECUTION', 'https://www.amazon.com.br/gp/new-releases/beauty', (SELECT ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik para Mulheres - Br'))
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Novidades (Moda) da Amazon BR', 'AMAZON_URL_EXECUTION', 'https://www.amazon.com.br/gp/new-releases/fashion/17681969011', (SELECT ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik para Mulheres - Br'))
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Os Mais Desejados (Beleza) da Amazon BR', 'AMAZON_URL_EXECUTION', 'https://www.amazon.com.br/gp/most-wished-for/beauty', (SELECT ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik para Mulheres - Br'))
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Os Mais Desejados (Beleza de luxo) Amazon BR', 'AMAZON_URL_EXECUTION', 'https://www.amazon.com.br/gp/most-wished-for/premium-beauty', (SELECT ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik para Mulheres - Br'))
INSERT INTO GENERAL_CONFIGURATION VALUES('Url Em Alta (Beleza) da Amazon BR', 'AMAZON_URL_EXECUTION', 'https://www.amazon.com.br/gp/movers-and-shakers/beauty', (SELECT ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik para Mulheres - Br'))
INSERT INTO GENERAL_CONFIGURATION VALUES('Tag de afiliado Amazon BR', 'AFFILIATED_AMAZON_TAG', 'promotikbr-20', (SELECT ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik para Mulheres - Br'))
INSERT INTO GENERAL_CONFIGURATION VALUES('Página de execução atual da fila Amazon BR', 'CURRENT_PAGE', '1', (SELECT ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik para Mulheres - Br'))
INSERT INTO GENERAL_CONFIGURATION VALUES('Máximo de páginas a executar Amazon BR', 'MAX_PAGE', '4', (SELECT ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik para Mulheres - Br'))
GO

INSERT INTO PUBLISHING_CHANNEL_PARAMETERS SELECT 'chat_id', Channel_ID, ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik para Mulheres - Br'
INSERT INTO PUBLISHING_CHANNEL_PARAMETERS VALUES ('parse_mode', 'html', (SELECT ID FROM PUBLISHING_CHANNEL WHERE Description = 'PromoTik para Mulheres - Br'))
GO

-- Inserts Gerais
INSERT INTO GENERAL_CONFIGURATION VALUES ('Intervalo de tempo de execução dos itens da fila', 'EXECUTION_TIME_INTERVAL', 5, null)
GO
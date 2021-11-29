# Find Numbers Divider

Calcula os divisores possíveis para um número inteiro positivo.

# Estrutura do projeto

O projeto e estruturado com as seguintes camadas

1. Entrypoint: É o ponto de entrada do sistema, deve ser o projeto a ser executado para que a aplicação seja executada.
2. Application: Corresponde a camada aonde ocorre a orquestração dos fluxos das funcionalidades do sistema.
3. Domain: Contém o core da aplicação, nela as regras de negócios são definidas.
4. CrossCutting: É uma camada que conté códigos que podem ser utilizados por todas as outras camadas do projeto.

# Consideraçoes

1. O foco deste projeto é resolver um problema em específico. Caso seja necessário gerar um serviço para que sejam realizados processamentos em grande escala é recomendável que seja feito um projeto que execute essas regras em segundo plano com uma abordagem que torne a execução performática. Um exemplo seria uma estratégia com o uso de filas de mensageria (RabbitMQ, Apache Kafka, etc...) usando cluster de preferência em uma plataforma cloud (AWS, Azure) para otimizar a execução e garantir principalmente resiliência, disponibilidade e escalabilidade.
2. Uma estratégia também interessante é o uso de cache para os números já calculados, isso economiza recursos de processamento e aumenta significativamente o ganho de performance. 

# Observaçoes

O projeto foi desenvolvido de forma opcional em inglês. Somente está em português as mensagens de retorno e interação com o usuário.

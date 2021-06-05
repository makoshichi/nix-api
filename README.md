# nix-api

-> Repositório 1: API (back-end) desenvolvida no Visual Studio 2019 com .NET 5.0

O objetivo foi implementar a API RESTful utilizando uma versão da "Onion Architecture" da Microsoft (https://social.technet.microsoft.com/wiki/contents/articles/36655.onion-architecture-in-asp-net-core-mvc.aspx), adicionando abstrações e Generics a fim de minimizar a repetição de código e assim, também obtendo um protótipo de boa escalabilidade. 

1) Gerar e atualizar banco de dados com migrations
Visual Studio 2019
- Selecionar projeto Domain como inicial no Solution Explorer
- No Package Manager Console:
-> Selecionar projeto Domain
-> Add-Migration <nome-migration>
-> Update-Database

Visual Studio Code/CLI
- navegar até a pasta do projeto Domain
-> dotnet ef migrations add <nome-migration>
-> dotnet ef database update

OBS: DefaultConnection está definida como "Server=localhost\\SQLEXPRESS;Database=NixApi;Trusted_Connection=True"

2) Rodar API (Visual Studio 2019)
-> Selecionar NixWeb como projeto inicial no Solution Explorer
-> Executar (F5). Projeto configurado para usar o IIS Express
API está rodando em http://localhost:44326 (a navegação será redirecionada direto ao swagger ao executar o projeto)

Os endpoints disponíveis, bem como exemplos de como formatar o objeto JSON para envio aos mesmos (apenas as estruturas necessárias à quem irá consumir a API) estão descritos e podem ser executados diretamente pelo swagger.
(Desenvolvimento testado via Postman)



-> Front-End será disponibilizado em repositório separado

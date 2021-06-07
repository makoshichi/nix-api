# nix-api

-> Repositório 1: API (back-end) desenvolvida no Visual Studio 2019 com .NET 5.0

O objetivo foi implementar a API RESTful utilizando uma versão da "Onion Architecture" da Microsoft (https://social.technet.microsoft.com/wiki/contents/articles/36655.onion-architecture-in-asp-net-core-mvc.aspx), adicionando abstrações e Generics a fim de minimizar a repetição de código e assim, também obtendo um protótipo de boa escalabilidade.

Foi optado por implementar um endpoint para criar usuários. Nome é o único campo obrigatório, mas também podem ser fornecidos fundos iniciais, limite de cartão e até mesmo números para contas e cartão. Se estes não forem informados, serão gerados automaticamente pela API. 

Caso um número da conta tente ser usado como número de cartão de crédito, ou vice-versa, o sistema apresentará uma mensagem de erro. 

Um filtro de data também foi implementado. O requisito dizia apenas filtro por crédito ou débito, mas sem data, fundos iniciais ou limite de cartão, a implementação das regras não ficavam muito condizentes.

Os campos de número de cartão, data inicial e data final foram validados com o FluentValidator do ASP.NET Core, em casos utilizando-o "out of the box", mas também foi necessário criar algumas regras customizadas, portanto não há uma padronização das mensagens de erro/validação (algumas estão em português e outras em inglês)

Os endpoints disponíveis, bem como exemplos de como formatar o objeto JSON para envio aos mesmos (apenas as estruturas necessárias à quem irá consumir a API) estão descritos e podem ser executados diretamente pelo swagger.
(Desenvolvimento testado via Postman)

Rodando a aplicação:

1) Gerar e atualizar banco de dados com migrations
Visual Studio 2019
- Selecionar projeto Domain como inicial no Solution Explorer
- No Package Manager Console
-> Selecionar projeto Domain
-> Add-Migration <nome-migration>
-> Update-Database

Visual Studio Code/CLI
- navegar até a pasta do projeto Domain
-> dotnet ef migrations add <nome-migration>
-> dotnet ef database update

OBS: DefaultConnection está definida como "Server=localhost\\SQLEXPRESS;Database=NixApi;Trusted_Connection=True"
Devido a problemas na configuração do meu ambiente para gerar migrations, esta string reside no arquivo appsettings.json mas também está explicitada na classe NixContext dentro do projeto Domain da solution.

2) Rodar API (Visual Studio 2019)
-> Selecionar NixWeb como projeto inicial no Solution Explorer
-> Executar (F5). Projeto configurado para usar o IIS Express
API está rodando em http://localhost:44326 (a navegação será redirecionada direto ao swagger ao executar o projeto). A porta pode ser alterada no arquivo launchSettings.json caso necessário

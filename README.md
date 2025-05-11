# Library CRUD

Este é um projeto simples de CRUD (Create, Read, Update, Delete) para gerenciamento de uma livraria, desenvolvido com ASP.NET Core MVC.

## Tecnologias Utilizadas

- ASP.NET Core MVC
- C#
- Entity Framework (opcional, dependendo da implementação do gerenciamento de dados)
- Bootstrap (para estilização da interface)

## Funcionalidades

- Listagem de livros cadastrados
- Adicionar um novo livro
- Editar informações de um livro
- Visualizar detalhes de um livro
- Remover um livro da lista

## Diagrama do Projeto
```mermaid
flowchart TD
    %% Client Side
    subgraph "Client Side"
        Browser["Browser"]:::ui
    end

    %% Server Side
    subgraph "Server Side"
        subgraph "Web App (Library)"
            Program["ASP.NET Core Entry Point\n(Program.cs)"]:::server
            Middleware["Static File Middleware"]:::server
            Routing["MVC Routing"]:::server
            Controller["HomeController"]:::server
            Views["Razor Views"]:::ui
            Assets["wwwroot assets"]:::ui
            CSS["site.css"]:::ui
            JS["site.js"]:::ui
            Shared["Shared Layouts & Partials"]:::ui
            ErrorModel["ErrorViewModel"]:::server
            AppSettings["appsettings.json &\nappsettings.Development.json"]:::server
            LibraryProj["Library.csproj"]:::server

            Browser -->|HTTP GET/POST| Program
            Program -->|configure pipeline| Middleware
            Middleware -->|route/static| Routing
            Routing -->|invoke| Controller
            Controller -->|renders| Views
            Views -->|HTML Response| Browser
            Controller -->|uses| BookManager
            Middleware -->|serves| Assets
            Assets -->|includes| CSS
            Assets -->|includes| JS
            Assets -->|uses| Shared
            Middleware -->|serves error| ErrorModel
            Program -->|loads config| AppSettings
        end

        subgraph "Class Library (LogicLibrary)"
            BookManager["BookManager Service"]:::server
            BookModel["Book Domain Model"]:::server
            LogicProj["LogicLibrary.csproj"]:::server

            BookManager -->|manages| BookModel
        end
    end

    %% Data Layer
    subgraph "Data Layer"
        BooksJson["Books.json Data Store"]:::data
        BookManager -->|reads/writes| BooksJson
        BooksJson -->|returns JSON| BookManager
    end

    %% External Frameworks & Libraries
    subgraph "External Frameworks"
        DotNet[".NET 9.0 Runtime"]:::ext
        Bootstrap["Bootstrap Library"]:::ext
        jQuery["jQuery & Validation"]:::ext

        DotNet --> Program
        Bootstrap --> Assets
        jQuery --> Assets
    end

    %% Click Events
    click Program "https://github.com/gabrielvesal/library-crud/blob/main/Library/Program.cs"
    click Assets "https://github.com/gabrielvesal/library-crud/tree/main/Library/wwwroot/"
    click CSS "https://github.com/gabrielvesal/library-crud/blob/main/Library/wwwroot/css/site.css"
    click JS "https://github.com/gabrielvesal/library-crud/blob/main/Library/wwwroot/js/site.js"
    click Bootstrap "https://github.com/gabrielvesal/library-crud/tree/main/Library/wwwroot/lib/bootstrap/"
    click jQuery "https://github.com/gabrielvesal/library-crud/tree/main/Library/wwwroot/lib/jquery/"
    click Controller "https://github.com/gabrielvesal/library-crud/blob/main/Library/Controllers/HomeController.cs"
    click Views "https://github.com/gabrielvesal/library-crud/tree/main/Library/Views/Home/"
    click Shared "https://github.com/gabrielvesal/library-crud/tree/main/Library/Views/Shared/"
    click ErrorModel "https://github.com/gabrielvesal/library-crud/blob/main/Library/Models/ErrorViewModel.cs"
    click AppSettings "https://github.com/gabrielvesal/library-crud/blob/main/Library/appsettings.json"
    click BooksJson "https://github.com/gabrielvesal/library-crud/blob/main/Library/Books.json"
    click BookManager "https://github.com/gabrielvesal/library-crud/blob/main/LogicLibrary/Services/BookManager.cs"
    click BookModel "https://github.com/gabrielvesal/library-crud/blob/main/LogicLibrary/Models/Book.cs"
    click LogicProj "https://github.com/gabrielvesal/library-crud/blob/main/LogicLibrary/LogicLibrary.csproj"
    click LibraryProj "https://github.com/gabrielvesal/library-crud/blob/main/Library/Library.csproj"

    %% Styles
    classDef ui fill:#cce5ff,stroke:#0066cc
    classDef server fill:#d4edda,stroke:#155724
    classDef data fill:#fff3cd,stroke:#856404
    classDef ext fill:#e2e3e5,stroke:#6c757d

```
## Instalação e Execução

1. Clone o repositório:
   ```sh
   git clone https://github.com/GabrielVesal/library-crud.git
   ```

2. Navegue até a pasta do projeto:
   ```sh
   cd library-crud
   ```

3. Restaure as dependências:
   ```sh
   dotnet restore
   ```

4. Execute o projeto:
   ```sh
   dotnet run
   ```

5. Acesse a aplicação no navegador:
   ```
   http://localhost:5000
   ```

## Como Usar

- Para adicionar um livro, clique em **"Add new book"** e preencha os campos necessários.
- Para editar um livro, clique no botão **"Edit"** ao lado do livro desejado.
- Para visualizar detalhes de um livro, clique em **"View"**.
- Para remover um livro, clique em **"Remove"** e confirme a remoção.

## Modelo de Dados (Book)
```csharp
public class Book
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public enum CategoryType { Technology, Business, Science, Arts, Health }
    public enum LanguageType { English, Spanish, French, German, Portuguese }
    public CategoryType Category { get; set; }
    public LanguageType Language { get; set; }
    public string Url { get; set; }
}
```

## Contribuição

Contribuições são bem-vindas! Para contribuir:
1. Fork o repositório
2. Crie uma nova branch (`git checkout -b minha-feature`)
3. Commit suas alterações (`git commit -m 'Adicionando uma nova funcionalidade'`)
4. Push para a branch (`git push origin minha-feature`)
5. Abra um Pull Request

## Licença

Este projeto está sob a licença MIT. Sinta-se à vontade para usar e modificar conforme necessário.


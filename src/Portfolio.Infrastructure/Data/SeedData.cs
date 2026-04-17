using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;

namespace Portfolio.Infrastructure.Data;

public static class SeedData
{
    public static async Task SeedAsync(PortfolioDbContext context)
    {
        await context.Database.MigrateAsync();

        if (!await context.Experiences.AnyAsync())
            await SeedExperiencesAsync(context);

        // Always reseed skills (clear + reinsert) so new skills are always deployed
        await ReseedSkillsAsync(context);

        if (!await context.Certifications.AnyAsync())
            await SeedCertificationsAsync(context);

        if (!await context.Educations.AnyAsync())
            await SeedEducationsAsync(context);

        if (!await context.ArchitectureLayers.AnyAsync())
            await SeedArchitectureLayersAsync(context);

        await context.SaveChangesAsync();
    }

    private static async Task SeedExperiencesAsync(PortfolioDbContext context)
    {
        await context.Experiences.AddRangeAsync(
            new Experience
            {
                Company = "Serasa Experian",
                RolePt = "Engenheiro de Software",
                RoleEn = "Software Engineer",
                DescriptionPt = "Como Engenheiro de Software no ecossistema de pagamentos PagueVeloz, sou especialista no desenvolvimento e entrega de features de alto impacto para o sistema de pagamentos instantâneos do Brasil (Pix).\nDesenvolvimento de Features Pix: Gerencio o ciclo de vida completo de novas features, incluindo a implementação do \"Pix Automático\" em conformidade com as normas do Banco Central. Isso envolve o design e construção dos microsserviços que alimentam todo o fluxo transacional.\nSistemas Assíncronos e Resilientes: Utilizo extensivamente sistemas de filas de mensagem como RabbitMQ e Amazon SQS para criar workflows de processamento desacoplados e confiáveis, além do Hangfire para agendamento de tarefas críticas em background.\nPerformance e Observabilidade: Responsável pela implementação de soluções de monitoramento com ferramentas como Datadog e Splunk para garantir a saúde da aplicação e a estabilidade do sistema.",
                DescriptionEn = "As a Software Engineer for the PagueVeloz payment ecosystem, I specialize in developing and delivering high-impact features for Brazil's instant payment system (Pix).\nPix Feature Development: I manage the full lifecycle for new features, including the implementation of \"Pix Automático\" in compliance with Central Bank regulations. This involves designing and building the microservices that power the entire transaction flow, from initiation to final settlement.\nAsynchronous & Resilient Systems: I heavily utilize message queuing systems like RabbitMQ and Amazon SQS to create decoupled and reliable transaction processing workflows, along with Hangfire for scheduling critical background tasks.\nApplication Performance & Observability: I am responsible for implementing monitoring solutions with tools like Datadog and Splunk to ensure application health, identify performance bottlenecks, and maintain system stability.",
                StartDate = new DateTime(2026, 2, 1, 0, 0, 0, DateTimeKind.Utc),
                IsCurrent = true,
                Technologies = ["C#", ".NET", "Microservices", "Azure", "Kubernetes", "Docker", "RabbitMQ", "Amazon SQS", "SQL Server", "Datadog", "GIT", "Hangfire"],
                Order = 1
            },
            new Experience
            {
                Company = "Meta IT",
                RolePt = "Engenheiro de Software | .NET | C# | SQL",
                RoleEn = "Software Engineer | .NET | C# | SQL",
                DescriptionPt = "Alocado na PagueVeloz. Especialista no desenvolvimento e entrega de features de alto impacto para o ecossistema de pagamentos instantâneos (Pix).\nCriação e aprimoramento de soluções robustas e de alta performance utilizando .NET, processamento assíncrono e arquitetura de microsserviços.\nGerenciamento do ciclo de vida completo do \"Pix Automático\".\nUtilização de RabbitMQ, Amazon SQS e Hangfire para fluxos assíncronos.\nImplementação de monitoramento com Datadog e Splunk.",
                DescriptionEn = "Assigned to PagueVeloz. Specialized in developing and delivering high-impact features for Brazil's instant payment system (Pix).\nBuilt and enhanced robust, high-performance solutions leveraging .NET, asynchronous processing, and microservice architecture.\nManaged the full lifecycle of \"Pix Automático\".\nUtilized message queuing systems (RabbitMQ, Amazon SQS, Hangfire) for decoupled processing.\nImplemented application monitoring with Datadog and Splunk.",
                StartDate = new DateTime(2025, 7, 1, 0, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2026, 2, 1, 0, 0, 0, DateTimeKind.Utc),
                IsCurrent = false,
                Technologies = ["C#", ".NET", "Microservices", "Azure", "Kubernetes", "Docker", "RabbitMQ", "Amazon SQS", "SQL Server", "Datadog", "GIT", "Hangfire"],
                Order = 2
            },
            new Experience
            {
                Company = "Blip",
                RolePt = "Engenheiro de Software | .NET | ChatBot",
                RoleEn = "Software Engineer | .NET | ChatBot",
                DescriptionPt = "Desenvolvimento e manutenção de APIs escaláveis com C# e .NET, focado em metodologias como DDD, Clean Architecture e SOLID.\nCriação e sustentação de Chatbots na plataforma Blip usando C# e JavaScript.\nParticipação no desenvolvimento de um chatbot para o Grupo Globo (Big Brother Brasil), alavancando o engajamento de milhões de usuários.\nAtuação em ambiente ágil com pipelines CI/CD no Azure DevOps e testes unitários.",
                DescriptionEn = "API development and maintenance using C#/.NET, focused on Clean Architecture, DDD, and SOLID.\nChatbot development using the Blip platform with C# and JavaScript.\nParticipated in building a chatbot for Grupo Globo (Big Brother Brasil), increasing digital interaction among millions of users.\nWorked in an Agile environment with CI/CD in Azure DevOps, Docker, Kubernetes, and unit testing.",
                StartDate = new DateTime(2021, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2025, 6, 1, 0, 0, 0, DateTimeKind.Utc),
                IsCurrent = false,
                Technologies = ["C#", ".NET", "JavaScript", "SQL Server", "Entity Framework", "Dapper", "Docker", "Kubernetes", "Azure DevOps", "XUnit", "Moq", "NSubstitute"],
                Order = 3
            },
            new Experience
            {
                Company = "AB SISTEMAS",
                RolePt = "Engenheiro de Software",
                RoleEn = "Software Engineer",
                DescriptionPt = "Manutenção e criação de novas funcionalidades em projetos existentes em .NET.\nEstruturação back-end e front-end com forte ênfase no back-end.\nLevantamento de requisitos e desenvolvimento de novos projetos web e mobile usando C#, Asp.NET Core e integrações via APIs REST.",
                DescriptionEn = "Maintenance and creation of new features in existing .NET projects.\nBack-end and front-end structuring with a strong focus on the back-end.\nRequirements gathering and development of new web and mobile projects using C#, Asp.NET Core, and REST APIs integration.",
                StartDate = new DateTime(2020, 2, 1, 0, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2021, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                IsCurrent = false,
                Technologies = ["C#", "ASP.NET Core", ".NET", "Xamarin.Forms", "PHP", "MySQL", "HTML", "CSS", "Bootstrap", "AngularJS", "Git", "GitHub"],
                Order = 4
            },
            new Experience
            {
                Company = "AB SISTEMAS",
                RolePt = "Analista de Suporte Técnico",
                RoleEn = "Technical Support Analyst",
                DescriptionPt = "Serviço de atendimento ao cliente, provendo suporte técnico e treinamentos.\nCriação de relatórios baseados em consultas ao banco e manipulação intensiva de banco de dados MySQL para resolução técnica de incidentes operacionais.",
                DescriptionEn = "Customer service, technical support, and user training.\nCreating reports and actively manipulating MySQL databases to resolve technical and operational incidents.",
                StartDate = new DateTime(2017, 10, 1, 0, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2020, 2, 1, 0, 0, 0, DateTimeKind.Utc),
                IsCurrent = false,
                Technologies = ["MySQL", "Technical Support", "Customer Service"],
                Order = 5
            }
        );
    }

    private static async Task ReseedSkillsAsync(PortfolioDbContext context)
    {
        // Remove existing skills and reinsert to ensure new skills are always deployed
        if (await context.Skills.AnyAsync())
        {
            context.Skills.RemoveRange(context.Skills);
            await context.SaveChangesAsync();
        }

        var skills = new List<Skill>
        {
            // Backend
            new() { NamePt = "C#", NameEn = "C#", CategoryPt = "Backend", CategoryEn = "Backend", Icon = "csharp", Order = 1 },
            new() { NamePt = ".NET / ASP.NET Core", NameEn = ".NET / ASP.NET Core", CategoryPt = "Backend", CategoryEn = "Backend", Icon = "dotnet", Order = 2 },
            new() { NamePt = "Web API RESTful", NameEn = "RESTful Web API", CategoryPt = "Backend", CategoryEn = "Backend", Icon = "api", Order = 3 },
            new() { NamePt = "Microsserviços", NameEn = "Microservices", CategoryPt = "Backend", CategoryEn = "Backend", Icon = "microservices", Order = 4 },
            new() { NamePt = "SOLID", NameEn = "SOLID", CategoryPt = "Backend", CategoryEn = "Backend", Icon = "solid", Order = 5 },
            new() { NamePt = "Domain-Driven Design", NameEn = "Domain-Driven Design", CategoryPt = "Backend", CategoryEn = "Backend", Icon = "ddd", Order = 6 },
            new() { NamePt = "Clean Architecture", NameEn = "Clean Architecture", CategoryPt = "Backend", CategoryEn = "Backend", Icon = "cleanarch", Order = 7 },
            // Banco de Dados
            new() { NamePt = "SQL Server", NameEn = "SQL Server", CategoryPt = "Banco de Dados", CategoryEn = "Database", Icon = "sqlserver", Order = 8 },
            new() { NamePt = "PostgreSQL", NameEn = "PostgreSQL", CategoryPt = "Banco de Dados", CategoryEn = "Database", Icon = "postgresql", Order = 9 },
            new() { NamePt = "MongoDB", NameEn = "MongoDB", CategoryPt = "Banco de Dados", CategoryEn = "Database", Icon = "mongodb", Order = 10 },
            new() { NamePt = "MySQL", NameEn = "MySQL", CategoryPt = "Banco de Dados", CategoryEn = "Database", Icon = "mysql", Order = 11 },
            // ORM
            new() { NamePt = "Entity Framework Core", NameEn = "Entity Framework Core", CategoryPt = "ORM", CategoryEn = "ORM", Icon = "ef", Order = 12 },
            new() { NamePt = "NHibernate", NameEn = "NHibernate", CategoryPt = "ORM", CategoryEn = "ORM", Icon = "nhibernate", Order = 13 },
            new() { NamePt = "Dapper", NameEn = "Dapper", CategoryPt = "ORM", CategoryEn = "ORM", Icon = "dapper", Order = 14 },
            // Cloud / DevOps
            new() { NamePt = "Azure", NameEn = "Azure", CategoryPt = "Cloud / DevOps", CategoryEn = "Cloud / DevOps", Icon = "azure", Order = 15 },
            new() { NamePt = "Docker", NameEn = "Docker", CategoryPt = "Cloud / DevOps", CategoryEn = "Cloud / DevOps", Icon = "docker", Order = 16 },
            new() { NamePt = "Kubernetes", NameEn = "Kubernetes", CategoryPt = "Cloud / DevOps", CategoryEn = "Cloud / DevOps", Icon = "kubernetes", Order = 17 },
            // Mensageria
            new() { NamePt = "RabbitMQ", NameEn = "RabbitMQ", CategoryPt = "Mensageria", CategoryEn = "Messaging", Icon = "rabbitmq", Order = 18 },
            new() { NamePt = "Amazon SQS", NameEn = "Amazon SQS", CategoryPt = "Mensageria", CategoryEn = "Messaging", Icon = "sqs", Order = 19 },
            new() { NamePt = "Redis", NameEn = "Redis", CategoryPt = "Mensageria", CategoryEn = "Messaging", Icon = "redis", Order = 20 },
            // Observabilidade
            new() { NamePt = "Datadog", NameEn = "Datadog", CategoryPt = "Observabilidade", CategoryEn = "Observability", Icon = "datadog", Order = 21 },
            new() { NamePt = "Splunk", NameEn = "Splunk", CategoryPt = "Observabilidade", CategoryEn = "Observability", Icon = "splunk", Order = 22 },
        };

        await context.Skills.AddRangeAsync(skills);
    }

    private static async Task SeedCertificationsAsync(PortfolioDbContext context)
    {
        await context.Certifications.AddRangeAsync(
            new Certification
            {
                NamePt = "Domain-Driven Design Fundamentals",
                NameEn = "Domain-Driven Design Fundamentals",
                Issuer = "Pluralsight",
                IssueDate = new DateTime(2025, 5, 1, 0, 0, 0, DateTimeKind.Utc),
                CredentialUrl = "https://media.licdn.com/dms/image/v2/D4D2DAQH2BXX1E-Qq7g/profile-treasury-document-cover-images_1280/B4DZbuV1V6HEA0-/0/1747755425124?e=1774537200&v=beta&t=e7ZzocwNC6115I9A9uBnTk0GEp_1qQNqKNhL_FivtIs"
            },
            new Certification
            {
                NamePt = "Azure DevOps Services Fundamentals",
                NameEn = "Azure DevOps Services Fundamentals",
                Issuer = "Pluralsight",
                IssueDate = new DateTime(2025, 5, 1, 0, 0, 0, DateTimeKind.Utc),
                CredentialUrl = "https://media.licdn.com/dms/image/v2/D4D2DAQE2uVu9mputlg/profile-treasury-document-images_1280/B4DZbpkiEBHsAY-/1/1747675391897?e=1775088000&v=beta&t=fAQEJJkvFxY_GGlYtPg4c-RaEIp3muVlBc0_Eh6ww9w"
            },
            new Certification
            {
                NamePt = "C# Design Patterns",
                NameEn = "C# Design Patterns",
                Issuer = "Pluralsight",
                IssueDate = new DateTime(2025, 5, 1, 0, 0, 0, DateTimeKind.Utc),
                CredentialUrl = "https://media.licdn.com/dms/image/v2/D4D2DAQE3E90FYbqiow/profile-treasury-document-images_1280/B4DZbaQK9tHQAc-/1/1747418396367?e=1775088000&v=beta&t=SHf7n5fHJbSJ7iSnzBWD_OuG0XzChf5o0yDhcT_LGBc"
            },
            new Certification
            {
                NamePt = "REST com ASP.NET Core WebAPI",
                NameEn = "REST with ASP.NET Core WebAPI",
                Issuer = "desenvolvedor.io",
                IssueDate = new DateTime(2022, 3, 1, 0, 0, 0, DateTimeKind.Utc),
                CredentialUrl = "https://desenvolvedor.io/certificado/98c125a8-a634-4d69-94d3-f79891001541"
            },
            new Certification
            {
                NamePt = "Microsoft Certified: Conceitos básicos do Azure",
                NameEn = "Microsoft Certified: Azure Fundamentals",
                Issuer = "Microsoft",
                IssueDate = new DateTime(2026, 4, 14, 0, 0, 0, DateTimeKind.Utc),
                CredentialUrl = "https://learn.microsoft.com/en-us/users/carloslima-5778/credentials/11817a0c9879606a"
            }
        );
    }

    private static async Task SeedEducationsAsync(PortfolioDbContext context)
    {
        await context.Educations.AddAsync(new Education
        {
            Institution = "Instituto Federal de Goiás (IFG) — Campus Goiânia",
            DegreePt = "Bacharelado em Sistemas de Informação",
            DegreeEn = "Bachelor's Degree in Information Systems",
            Field = "Information Technology",
            StartYear = 2016,
            EndYear = 2025
        });
    }

    private static async Task SeedArchitectureLayersAsync(PortfolioDbContext context)
    {
        await context.ArchitectureLayers.AddRangeAsync(
            new ArchitectureLayer
            {
                NamePt = "Camada de Domínio",
                NameEn = "Domain Layer",
                DescriptionPt = "O núcleo da aplicação. Contém as entidades do negócio e as interfaces de repositório. Não possui nenhuma dependência externa — é puro C# sem referências a frameworks.",
                DescriptionEn = "The core of the application. Contains business entities and repository interfaces. Has zero external dependencies — it is pure C# with no framework references.",
                CodeSnippet = """
namespace Portfolio.Domain.Entities;

public class Experience
{
    public int Id { get; set; }
    public string Company { get; set; } = string.Empty;
    public string RolePt { get; set; } = string.Empty;
    public string RoleEn { get; set; } = string.Empty;
    public string DescriptionPt { get; set; } = string.Empty;
    public string DescriptionEn { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsCurrent { get; set; }
    public List<string> Technologies { get; set; } = [];
    public int Order { get; set; }
}
""",
                Language = "csharp",
                Order = 1
            },
            new ArchitectureLayer
            {
                NamePt = "Camada de Aplicação",
                NameEn = "Application Layer",
                DescriptionPt = "Orquestra os casos de uso. Contém os serviços que aplicam a lógica de negócio, os DTOs retornados pela API e as interfaces de serviço. Depende apenas do Domínio.",
                DescriptionEn = "Orchestrates use cases. Contains services that apply business logic, DTOs returned by the API, and service interfaces. Depends only on the Domain layer.",
                CodeSnippet = """
public class ExperienceService(IExperienceRepository repository) : IExperienceService
{
    public async Task<IEnumerable<ExperienceDto>> GetAllAsync(string lang)
    {
        var experiences = await repository.GetAllAsync();
        bool isPt = lang.StartsWith("pt", StringComparison.OrdinalIgnoreCase);

        return experiences
            .OrderBy(e => e.Order)
            .Select(e => new ExperienceDto(
                e.Id,
                e.Company,
                isPt ? e.RolePt : e.RoleEn,
                isPt ? e.DescriptionPt : e.DescriptionEn,
                e.StartDate, e.EndDate, e.IsCurrent,
                e.Technologies, e.Order
            ));
    }
}
""",
                Language = "csharp",
                Order = 2
            },
            new ArchitectureLayer
            {
                NamePt = "Camada de Infraestrutura",
                NameEn = "Infrastructure Layer",
                DescriptionPt = "Implementa as interfaces do Domínio usando tecnologias concretas: Entity Framework Core para acesso ao banco de dados PostgreSQL e repositórios que executam as queries.",
                DescriptionEn = "Implements Domain interfaces using concrete technologies: Entity Framework Core for PostgreSQL database access and repositories that execute the queries.",
                CodeSnippet = """
public class PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
    : DbContext(options)
{
    public DbSet<Experience> Experiences => Set<Experience>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Certification> Certifications => Set<Certification>();
    public DbSet<Education> Educations => Set<Education>();
    public DbSet<ArchitectureLayer> ArchitectureLayers => Set<ArchitectureLayer>();
}
""",
                Language = "csharp",
                Order = 3
            },
            new ArchitectureLayer
            {
                NamePt = "Camada de API",
                NameEn = "API Layer",
                DescriptionPt = "ASP.NET Core Web API que expõe os endpoints REST. Recebe o parâmetro `?lang=pt` ou `?lang=en`, delega ao serviço da Application e retorna os DTOs. Documentada automaticamente via Swagger/OpenAPI.",
                DescriptionEn = "ASP.NET Core Web API exposing the REST endpoints. Accepts `?lang=pt` or `?lang=en` query param, delegates to the Application service, and returns DTOs. Automatically documented via Swagger/OpenAPI.",
                CodeSnippet = """
[ApiController]
[Route("api/[controller]")]
public class ExperiencesController(IExperienceService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string lang = "pt")
    {
        var experiences = await service.GetAllAsync(lang);
        return Ok(experiences);
    }
}
""",
                Language = "csharp",
                Order = 4
            },
            new ArchitectureLayer
            {
                NamePt = "Frontend Blazor",
                NameEn = "Blazor Frontend",
                DescriptionPt = "Interface do usuário escrita 100% em C# usando Blazor WebAssembly. Consome a API via HttpClient e renderiza os dados dinamicamente. O toggle PT | EN dispara a recarga de todos os dados no idioma selecionado.",
                DescriptionEn = "User interface written 100% in C# using Blazor WebAssembly. Consumes the API via HttpClient and dynamically renders the data. The PT | EN toggle triggers a full reload of all data in the selected language.",
                CodeSnippet = """
@page "/experience"
@inject PortfolioApiService Api
@inject LanguageService Lang
@implements IDisposable

<section class="experience-section">
    @foreach (var exp in experiences)
    {
        <ExperienceCard Experience="exp" />
    }
</section>

@code {
    private IEnumerable<ExperienceDto> experiences = [];

    protected override async Task OnInitializedAsync()
    {
        Lang.OnLanguageChanged += OnLanguageChanged;
        await LoadAsync();
    }

    private async Task LoadAsync()
    {
        experiences = await Api.GetExperiencesAsync(Lang.Current);
        StateHasChanged();
    }

    private async void OnLanguageChanged() => await LoadAsync();

    public void Dispose() => Lang.OnLanguageChanged -= OnLanguageChanged;
}
""",
                Language = "razor",
                Order = 5
            }
        );
    }
}

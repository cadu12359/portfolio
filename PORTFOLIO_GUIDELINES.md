# Portfolio Project — Guidelines & Architecture Reference

> Este documento serve como guia de referência para o projeto de portfólio de **Carlos Eduardo Santos Lima**.
> Sempre que retomar o trabalho neste projeto, leia este arquivo primeiro para restaurar o contexto completo.

---

## 🎯 Objetivo do Projeto

Criar um portfólio pessoal que **demonstre na prática as tecnologias que o desenvolvedor domina**.
O site em si é o projeto — um visitante técnico pode navegar pelo portfólio e entender como ele foi construído,
camada por camada, através da seção interativa **"Como Foi Feito"**.

O site suporta **dois idiomas: Português (PT-BR) e Inglês (EN)**, com alternância dinâmica via toggle no header.

---

## 👤 Informações do Desenvolvedor

- **Nome:** Carlos Eduardo Santos Lima
- **Cargo:** Software Developer .NET
- **Email:** csantoslima03@gmail.com
- **Telefone:** +55 62 99518-1974
- **GitHub:** (definir após criação do repositório)
- **LinkedIn:** (definir URL)
- **Educação:** Sistemas de Informação — IFG Campus Goiânia (2016–2025)

---

## 🏗️ Arquitetura

### Visão Geral

```
GitHub Pages                         Railway (Free Tier)
┌──────────────────────┐             ┌────────────────────────────────────┐
│   Portfolio.Web      │  HTTP/REST  │         Portfolio.API               │
│   Blazor WebAssembly │ ──────────► │   ASP.NET Core 8 Web API           │
│   (C# no frontend)   │             │   Clean Architecture                │
└──────────────────────┘             │   EF Core 8 + PostgreSQL           │
                                     │   Swagger / OpenAPI                 │
                                     └────────────────────────────────────┘
                                                    │
                                     ┌──────────────▼─────────────────────┐
                                     │    Railway PostgreSQL (Free 1GB)    │
                                     └────────────────────────────────────┘
```

### Camadas (Clean Architecture)

```
Portfolio.sln
├── src/
│   ├── Portfolio.Domain/          ← Entidades, interfaces de repositório, regras de negócio
│   ├── Portfolio.Application/     ← Casos de uso, DTOs, interfaces de serviço
│   ├── Portfolio.Infrastructure/  ← EF Core, DbContext, implementação de repositórios
│   ├── Portfolio.API/             ← Controllers, Program.cs, configuração Swagger/CORS
│   └── Portfolio.Web/             ← Blazor WebAssembly (frontend em C#)
└── .github/
    └── workflows/
        ├── api-deploy.yml         ← CI/CD: deploy API para Railway
        └── web-deploy.yml         ← CI/CD: deploy Blazor para GitHub Pages
```

---

## 🛠️ Stack Tecnológica

| Camada | Tecnologia | Versão |
|---|---|---|
| Frontend | Blazor WebAssembly | .NET 8 |
| Backend | ASP.NET Core Web API | .NET 8 |
| ORM | Entity Framework Core | 8.x |
| Banco de Dados | PostgreSQL | 16.x |
| Documentação API | Swagger / Swashbuckle | 6.x |
| Hospedagem Frontend | GitHub Pages | — |
| Hospedagem Backend + DB | Railway | Free Tier |
| CI/CD | GitHub Actions | — |

---

## 📐 Decisões de Design

### ❌ O que NÃO existe neste projeto (e por quê)

- **JWT Auth** — portfólio é 100% público, autenticação seria complexidade desnecessária
- **CQRS / MediatR** — Clean Architecture simples é suficiente para a escala do projeto
- **Testes automatizados** — pode ser adicionado em uma fase futura como melhoria

### ✅ O que existe e por quê

- **Clean Architecture** — demonstra domínio de design de software escalável
- **Dados no banco** — skills, experiências, projetos e certificações vêm de uma API real (não hardcoded)
- **Swagger habilitado** — qualquer dev pode explorar a API diretamente
- **Blazor WASM** — frontend escrito em C#, reforçando o domínio da linguagem

---

## 🌟 Funcionalidade Principal: "Como Foi Feito"

A seção mais diferenciada do portfólio. É uma página/aba interativa que:

1. **Exibe um diagrama da arquitetura** do próprio site (clicável)
2. **Ao clicar em cada camada**, mostra:
   - Explicação do papel daquela camada
   - Trecho de código real daquela camada
   - Link direto para o arquivo no GitHub
3. **Todo o conteúdo vem do endpoint `/api/architecture`** — ou seja, a funcionalidade ela mesma demonstra que a API funciona
4. Serve como um **tour técnico** para recrutadores e devs

### Endpoint `/api/architecture`

Retorna uma lista de `ArchitectureLayer`:

```json
[
  {
    "id": 1,
    "name": "Domain Layer",
    "description": "Contém as entidades e interfaces do negócio, sem dependências externas.",
    "order": 1,
    "codeSnippet": "public interface IProjectRepository { ... }",
    "language": "csharp",
    "githubFileUrl": "https://github.com/.../Portfolio.Domain/..."
  },
  ...
]
```

---

## 🎨 Design Visual

- **Estilo:** Dark mode — fundo escuro com acentos em tons de azul/ciano (mantendo identidade do portfólio atual)
- **Fontes:** Inter ou Outfit (Google Fonts)
- **Efeitos:** Glassmorphism nos cards, glow nos elementos de destaque
- **Animações:** Micro-animações em hover e transição entre seções

---

## 🌐 Internacionalização (i18n)

O site suporta PT-BR e EN com alternância dinâmica. A estratégia é dividida em duas partes:

### Texto estático da UI
- Usado para labels, títulos de seção, botões, etc.
- Implementado com **`.resx` files** (localização nativa do Blazor via `IStringLocalizer`)
- Arquivos: `Shared.pt-BR.resx` e `Shared.en-US.resx` em `Portfolio.Web/Resources/`

### Conteúdo dinâmico (vindo da API)
- Usado para descrições de experiência, projetos, habilidades, camadas de arquitetura, etc.
- Cada entidade do Domain possui campos duplicados: `*Pt` e `*En` (ex: `DescriptionPt`, `DescriptionEn`)
- A API aceita o query param `?lang=pt` ou `?lang=en` e mapeia o campo correto no DTO de resposta
- O Blazor passa o idioma atual em toda chamada via `PortfolioApiService`

### LanguageService (Blazor)
- Serviço singleton: `LanguageService.cs` em `Portfolio.Web/Services/`
- Persiste a preferência do usuário em `localStorage`
- Expoe evento `OnLanguageChanged` para que todas as páginas recarreguem os dados ao trocar o idioma
- `LanguageToggle.razor` — componente no header com botão `PT | EN`

---

## 🗂️ Entidades do Domínio

| Entidade | Campos principais |
|---|---|
| `Experience` | Id, Company, Role, Description, StartDate, EndDate, Technologies[] |
| `Skill` | Id, Name, Category, Icon |
| `Project` | Id, Title, Description, Technologies[], GitHubUrl, LiveUrl |
| `Certification` | Id, Name, Issuer, IssueDate, CredentialUrl |
| `Education` | Id, Institution, Degree, StartYear, EndYear |
| `ArchitectureLayer` | Id, Name, Description, Order, CodeSnippet, Language, GitHubFileUrl |

---

## 🚀 Deploy

### Frontend (GitHub Pages)
- Build: `dotnet publish Portfolio.Web -c Release`
- Output copiado para branch `gh-pages` via GitHub Actions

### Backend (Railway)
- Deploy automático via GitHub Actions a cada push em `main`
- Variáveis de ambiente configuradas no Railway:
  - `DATABASE_URL` — connection string PostgreSQL
  - `ASPNETCORE_ENVIRONMENT` — Production
  - `ALLOWED_ORIGINS` — URL do GitHub Pages

---

## 📋 Status do Projeto

> Atualizar esta seção conforme o projeto avança.

- [x] Planejamento e arquitetura definidos
- [ ] Estrutura da solution criada
- [ ] Entidades e repositórios do Domain
- [ ] Application layer (use cases + DTOs)
- [ ] Infrastructure (EF Core + migrations)
- [ ] API Controllers + Swagger
- [ ] Blazor WASM frontend
- [ ] Seção "Como Foi Feito"
- [ ] Deploy Railway + GitHub Pages
- [ ] Repositório GitHub criado e vinculado

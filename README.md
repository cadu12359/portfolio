# 🧠 Portfolio — Carlos Eduardo Santos Lima

> A personal portfolio built as a **real-world technical showcase**. The site itself is the project — built with the same technologies used in production enterprise systems.

[![.NET](https://img.shields.io/badge/.NET_9-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Blazor](https://img.shields.io/badge/Blazor_WASM-512BD4?style=for-the-badge&logo=blazor&logoColor=white)](https://blazor.net)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-336791?style=for-the-badge&logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)](https://www.docker.com/)

🔗 **Live:** [cadu12359.github.io/portfolio](https://cadu12359.github.io/portfolio)

---

## 🏗️ Architecture

This project follows **Clean Architecture** with clear layer separation and zero coupling between layers:

```
┌─────────────────────────────────────────────────┐
│              Blazor WASM (Frontend)             │
│                  GitHub Pages                   │
└────────────────────┬────────────────────────────┘
                     │ REST API (HTTP/JSON)
┌────────────────────▼────────────────────────────┐
│           ASP.NET Core Web API (Backend)        │
│          Oracle Cloud VPS (Docker + Caddy)      │
└────────────────────┬────────────────────────────┘
                     │ EF Core
┌────────────────────▼────────────────────────────┐
│              PostgreSQL Database                │
│              Oracle Cloud VPS (Docker)          │
└─────────────────────────────────────────────────┘
```

### Layer Breakdown

| Layer | Project | Responsibility |
|---|---|---|
| **Domain** | `Portfolio.Domain` | Entities & repository interfaces. Zero external dependencies |
| **Application** | `Portfolio.Application` | Use cases, DTOs, service interfaces |
| **Infrastructure** | `Portfolio.Infrastructure` | EF Core, PostgreSQL, repository implementations |
| **API** | `Portfolio.API` | ASP.NET Core REST endpoints, Swagger, CORS |
| **Web** | `Portfolio.Web` | Blazor WASM frontend, language service, API client |

---

## 🛠️ Tech Stack

### Backend
- **ASP.NET Core 9** Web API with Clean Architecture
- **Entity Framework Core** + PostgreSQL
- **Swagger / OpenAPI** for documentation
- Multilingual API: `?lang=pt` / `?lang=en`

### Frontend
- **Blazor WebAssembly** — entire UI written in C#
- **Custom CSS** with glassmorphism, dark mode, and micro-animations
- **Devicon** for technology icons
- **Font Awesome** for UI icons
- **Prism.js** for syntax-highlighted code snippets
- Bilingual support (PT-BR / EN) with `LanguageService` and `.resx` files

### Infrastructure
- **Docker Compose** for deployment and local development
- **Oracle Cloud (Always Free)** VPS for API and PostgreSQL hosting
- **Caddy Server** for automatic HTTPS (SSL) reverse proxy
- **GitHub Pages** for Blazor WASM deployment
- **GitHub Actions** for CI/CD

---

## 📂 Project Structure

```
portfolio/
├── src/
│   ├── Portfolio.Domain/          # Entities, interfaces
│   ├── Portfolio.Application/     # Services, DTOs
│   ├── Portfolio.Infrastructure/  # EF Core, repositories, seed data
│   ├── Portfolio.API/             # ASP.NET Core Web API
│   └── Portfolio.Web/             # Blazor WASM frontend
├── Dockerfile.api
├── Dockerfile.web
├── docker-compose.yml
└── Portfolio.sln
```

---

## 🚀 Running Locally

### Prerequisites
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

### With Docker Compose (recommended)

```bash
git clone https://github.com/cadu12359/portfolio.git
cd portfolio
docker compose up --build
```

| Service | URL |
|---|---|
| Frontend (Blazor WASM) | http://localhost:8080 |
| Backend (API) | http://localhost:5000 |
| Swagger UI | http://localhost:5000/swagger |
| PostgreSQL | localhost:5432 |

### Without Docker

```bash
# Start the API
dotnet run --project src/Portfolio.API

# In another terminal, start the frontend
dotnet run --project src/Portfolio.Web
```

---

## 🌐 API Endpoints

All GET endpoints accept an optional `?lang=pt` or `?lang=en` query parameter (default: `pt`).

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/experiences` | Work experience timeline |
| `GET` | `/api/skills` | Technical skills by category |
| `GET` | `/api/certifications` | Certifications with credential links |
| `GET` | `/api/education` | Education history |
| `GET` | `/api/architecture` | Legacy architecture layer metadata (not used by the overview page) |
| `POST` | `/api/contact` | Send contact email |

---

## ✨ Features

- **Architecture Overview** — Deployment topology, backend responsibilities, architecture decisions, and visual foundations in PT-BR / EN. The page is bundled with the frontend and remains readable when the API is unavailable.
- **Multilingual** — Full PT-BR / EN support with dynamic switching, no page reload
- **Dynamic data** — Experience, skills, projects, certifications, and education are served from PostgreSQL via REST API
- **Responsive design** — Adapts to all screen sizes
- **Containerized** — Full Docker Compose setup with health checks

---

## 👤 Author

**Carlos Eduardo Santos Lima**
- 🔗 [LinkedIn](https://www.linkedin.com/in/carlos-eduardo-santos-lima/)
- 🐙 [GitHub](https://github.com/cadu12359)

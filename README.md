

```markdown
# Dating Full Stack Application

A full-stack dating application built with **ASP.NET Core Web API** for the backend and a modern frontend.  
This project is designed as a real-world practice project with clean structure, authentication, and Docker support.

---

## Tech Stack

### Backend
- ASP.NET Core Web API
- C#
- Entity Framework Core
- JWT Authentication
- PostgreSQL / SQL Server

### Frontend
- TypeScript
- HTML / CSS
- Frontend framework (React or similar)

### Tools
- Docker & Docker Compose
- Git & GitHub

---

## Features

- User registration and login
- JWT-based authentication
- User profile management
- Role-based authorization
- RESTful API
- Dockerized setup

---

## Project Structure

```

Dating-Full-Strack
├── DatingApp
│   ├── API
│   │   ├── Controllers
│   │   ├── Entities
│   │   ├── DTOs
│   │   ├── Interfaces
│   │   ├── Services
│   │   ├── Data
│   │   └── Program.cs
│   └── Client
│       └── Frontend source code
├── docker-compose.yml
└── README.md

````

---

## Getting Started

### Clone Repository

```bash
git clone https://github.com/Mehrad44/Dating-Full-Strack.git
cd Dating-Full-Strack
````

### Run Backend

```bash
cd DatingApp/API
dotnet restore
dotnet run
```

### Run Frontend

```bash
cd DatingApp/Client
npm install
npm start
```

### Run with Docker

```bash
docker compose up --build
```

---

## API Endpoints (Sample)

| Method | Endpoint              | Description      |
| ------ | --------------------- | ---------------- |
| POST   | /api/account/register | Register user    |
| POST   | /api/account/login    | Login user       |
| GET    | /api/users            | Get users        |
| GET    | /api/users/{id}       | Get user profile |

---

## Environment Variables

```
DATABASE_CONNECTION=
JWT_SECRET=
JWT_ISSUER=
JWT_AUDIENCE=
```

---

## License

MIT License

---

## Author

Mehrad Khavary
GitHub: [https://github.com/Mehrad44](https://github.com/Mehrad44)



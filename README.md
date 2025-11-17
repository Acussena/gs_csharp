# Career Navigator API

API desenvolvida em **C# .NET 8**, utilizando **Entity Framework Core**, organizada em arquitetura de **Controllers**, **Services**, **Repositories** e **Models**.  
O objetivo do sistema é gerenciar usuários, habilidades, metaskills, carreiras futuras e análises de GAP profissional.

---

## 📌 Funcionalidades da API

A API possui 5 módulos principais:

### 1. **Users**

- Cadastrar usuário
- Listar todos os usuários
- Buscar usuário por ID
- Atualizar usuário
- Deletar usuário

### 2. **User Skills**

- Adicionar habilidades para o usuário
- Listar skills do usuário
- Atualizar skill
- Deletar skill

### 4. **Future Careers**

- Cadastrar carreiras futuras
- Listar carreiras
- Atualizar carreira
- Remover carreira

### 5. **Career Gap Analysis**

Compara:

- Skills que o usuário possui
- Skills necessários para uma carreira

E retorna:

- Lista de skills que faltam para atingir a carreira desejada.

---

## 📁 Estrutura do Projeto

│
├── Controllers/v1/
│ ├── FutureCareersController.cs
│ ├── GapAnalysisController.cs
│ ├── UsersController.cs
│ └── UserSkillsController.cs
│
├── Data/
│ └── AppDbContext.cs
│
├── Models/
│ ├── CareerGapAnalysis.cs
│ ├── FutureCareer.cs
│ ├── User.cs
│ └── UserSkill.cs
│
├── Repositories/
│ ├── Interfaces/
│ │ ├── IFutureCareerRepository.cs
│ │ ├── IGapAnalysisRepository.cs
│ │ ├── IUserRepository.cs
│ │ └── IUserSkillRepository.cs
│ ├── FutureCareerRepository.cs
│ ├── GapAnalysisRepository.cs
│ ├── UserRepository.cs
│ └── UserSkillRepository.cs
│
├── Services/
│ ├── FutureCareerService.cs
│ ├── GapAnalysisService.cs
│ ├── UserService.cs
│ └── UserSkillService.cs
│
└── appsettings.Development.json

### 📂 **Arquitetura**

- **Models** → Estruturas das tabelas
- **Repositories** → Comunicação com o banco
- **Services** → Regras de negócio
- **Controllers** → Endpoints da API
- **DbContext** → Mapeamento das entidades

---

## Como rodar o projeto:

Dotnet run

A API irá rodar em: http://localhost:5263/swagger/index.html

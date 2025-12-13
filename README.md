# 🔐 JWT Auth API - Aplicações

API desenvolvida em .NET para autenticação, autorização e validações.  
Ela implementa **JWT (JSON Web Token)** para garantir segurança e controle de acesso, seguindo boas práticas de arquitetura em camadas (API, Application, Domain, Infrastructure).

---

## 🚀 Tecnologias
- [.NET 10](https://dotnet.microsoft.com/)
- **Entity Framework Core** para persistência
- **JWT** para autenticação e autorização
- **Validation** para validações
- **PostgreSQL**

---

## 📂 Estrutura do Projeto
- `jwt-auth-api.Api` → Endpoints da API
- `jwt-auth-api.Application` → Casos de uso e regras de negócio
- `jwt-auth-api.Domain` → Entidades
- `jwt-auth-api.Infrastructure` → Repositórios e acesso a dados

---
## 📖 Documentação com Scalar
Após rodar a aplicação, acesse:
Você verá a interface do **Scalar**, onde é possível:
- Navegar pelos endpoints (`/api/auth`, `/api/person`, etc.)
- Executar requisições de login e validação
- Visualizar exemplos de payloads e respostas
- Testar autenticação com JWT diretamente na interface

---

## 🔑 Autenticação & Autorização
- Login com **email e senha**
- Geração de **JWT Token**
- Claims e Roles para controle de permissões

Exemplo de login:
```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "usuario@teste.com",
  "password": "123456"
}
```
Resposta:
```http
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6..."
}
```
---

## ✅ Validações
* Uso de Validation para ViewModels

* Exemplo: PersonPostRequest exige FirstName e LastName preenchidos

* Retorno de erros padronizado em JSON
  
---

## 🛠️ Como rodar localmente
1. Clone o repositório:

```Bash
git clone https://github.com/Daniela2319/jwt-auth-api.git
```
2. Entre na pasta:

```Bash
cd jwt-auth-api/jwt-auth-api.Api
```
3. Restaure dependências:
```Bash
dotnet restore
```
4. Rode a aplicação:
 ```Bash
dotnet run

```
5. Abra o Scalar:
```Bash
http://localhost:5000/scalar/v1
```
---
## 🧪 Testes
* Testes unitários para casos de uso

* Testes de integração para endpoints

* Executar:
```Bash
dotnet test
```
---
## 📜 Licença
Este projeto está sob a licença MIT. Sinta-se livre para usar e contribuir!

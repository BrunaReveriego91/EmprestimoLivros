## Emprestimo de Livro
Projeto de conclusão da Fase 4 da Pós Tech Fiap Curso de Arquitetura de Sistemas .NET com Azure

:file_folder: Pastas
- src - Arquivos fontes
- doc - Documentação dos requisitos, justficativas das tecnologias utilizadas.

🛠️ Construído com
- .NET CORE 6 - O framework web usado
- MongoDB - Banco de dados NoSQL
- AutoMapper - https://automapper.org/

✒️ Autores
- Andre Toledo Gama - Dev
- Bruna Reveriego - Dev
- Fernando Parissenti - Dev
- Rodrigo Reis - Dev

Requisitos
1.	Requisitos Funcionais
O sistema de empréstimo de livros terá um API que será responsável pelas regras de negócio. 
    
    1. Lista de requisitos obrigatórios
    2. Login do sistema
    3. Cadastro de usuários
    4. Cadastro de Editora
    5. Cadastro de área de conhecimento
    6. Cadastro de tipo de publicações
    7. Cadastro de publicações 
    8. Cadastro de empréstimos
    9. Cadastro de reserva de livros

## Instalar MongoDB

- [MongoDB](https://www.mongodb.com/try/download/community)

## Instalar .Net

- [.NET Core SDK](https://www.microsoft.com/net/download)

## Build e Run o projeto Emprestimo de livros

1. Vá para a pasta src\EmprestimoLivros.API e faça o build

    ```console
    dotnet build
    ```

2. Para rodar o projeto:

    ```console
    dotnet run
    ```
3. Acesse a documentação da api no endereço
    
    https://localhost:7098/swagger

4. Realize o Cadastro do Usuário utilizando o endpoint
    
    https://localhost:7098/swagger/Usuario
    
    Exemplo:
    ```console
    curl -X 'POST' \
    'https://localhost:7098/Usuario' \
    -H 'accept: */*' \
    -H 'Content-Type: application/json' \
    -d '{
    "nome": "Teste",
    "matricula": "12345",
    "dataNascimento": "2024-07-13T19:06:12.634Z",
    "tipoUsuario": "Funcionário",
    "login": "teste",
    "password": "123456",
    "role": "funcionario"
    }
    ```
5. Realize a autenticação pelo endpoint com os dados informados na etapa 4.
    
    https://localhost:7098/swagger/Autenticar
    
    Exemplo:
    ```console
    curl -X 'POST' \
    'https://localhost:7098/Autenticar' \
    -H 'accept: */*' \
    -H 'Content-Type: application/json' \
    -d '{
    "login": "teste",
    "password": "123456"
    }'
    ```
6. Realize o Cadastro de um área de conhecimento, utilize o token retornado no passo 5 para preencher o authorization

    Exemplo:
    ```console
    curl -X 'POST' \
    'https://localhost:7098/AreaConhecimento' \
    -H 'accept: */*' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiVGVzdGUiLCJuYmYiOjE3MjA4OTc2NjgsImV4cCI6MTcyMDkwMTI2OCwiaWF0IjoxNzIwODk3NjY4LCJpc3MiOiJGaWFwVGVjaENoYWxsZW5nZSIsImF1ZCI6InlvdXJBdWRpZW5jZSJ9.OohdRgLW5IqZFx2SH7d-2yxSTRYGmzSvMot4H-4fBEI' \
    -H 'Content-Type: application/json' \
    -d '{
    "id": 0,
    "nomeArea": "Tecnologia"
    }'
    ```
7. Realize a consulta de todas as áreas de conhecimento

    Exemplo:
    ```console
    curl -X 'GET' \
    'https://localhost:7098/AreaConhecimento' \
    -H 'accept: */*' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiVGVzdGUiLCJuYmYiOjE3MjA4OTc2NjgsImV4cCI6MTcyMDkwMTI2OCwiaWF0IjoxNzIwODk3NjY4LCJpc3MiOiJGaWFwVGVjaENoYWxsZW5nZSIsImF1ZCI6InlvdXJBdWRpZW5jZSJ9.OohdRgLW5IqZFx2SH7d-2yxSTRYGmzSvMot4H-4fBEI'
    ```

8. Vá para a pasta src\EmprestimoLivros.Tests para executar os testes.

    ```console
    dotnet restore
    dotnet test
    ```
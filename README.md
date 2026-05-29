# RestauranteApi

API desenvolvida em .NET 8 com Entity Framework Core para gerenciamento de cardápio.

## Funcionalidades base do projeto
* Listar todos os pratos do cardápio;
* Buscar um prato específico por ID;
* Buscar pratos pelo nome;
* Filtrar pratos por categoria (Entrada, Prato Principal, Sobremesa, Bebida e Lanche);
* Listar apenas os pratos disponíveis no momento;
* Cadastrar um novo prato;
* Atualizar as informações de um prato existente;
* Ativar ou desativar a disponibilidade de um prato;
* Remover um prato do cardápio.

## Como rodar o projeto localmente

### 1. Clonar o repositório:
    
    git clone (NomeDoProjeto)

### 2. Restaurar pacotes:

    dotnet restore

### 3. Criar e atualizar o banco de dados (Migrations):
    
    "dotnet ef migrations add Restaurante" 
    
    "dotnet ef database update"

### 4. Executar a API:
    
    dotnet run

## Resolução de problemas (EF Tools)
### Caso o comando 'dotnet-ef' dê erro no terminal:
    
    dotnet tool install --global dotnet-ef

### Se persistir:
   
     export PATH="$PATH:$HOME/.dotnet/tools"

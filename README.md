# SuperMarket

Api REST criada para realizar o controle de um supermecado.

## 🚀 Começando
Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

## Índice

- [Instalação](#instalação)
- [Configuração](#configuração)
- [Uso](#uso)
- [Endpoints](#endpoints)
- [Contribuição](#contribuição)

## Instalação

Certifique-se de ter o Go instalado em seu sistema antes de prosseguir.

**1. Clone o repositório:**
   ```
   git clone [https://github.com/MarcosVenicioSJr/Supermarket.git]
  ```

**2. Navegue até o diretório da API:**
   ```
   cd Supermarket
  ```
**3. Baixe e as dependências:**
   ```
   dotnet restore
  ```
**4. Compile e execute a API:**
   ```
   dotnet build
   dotnet run
  ```
## ⚙️ Configuração
Para a criação do banco de dados SqlServer, Configure o arquivo appsetting.json, coloque os seus dados do banco que deseja usar: Segue infomações a serem preenchidas:

```
"connectionString": "Server=;Database=;User ID=;Password=;Trusted_Connection=False; TrustServerCertificate=True;"

```
Preencha conforme necessário.

Para executar o projeto, se faz necessário a criação de um banco de dados primeiro, com o nome contido na propriedade Database

## Uso
Para utilizar 100% da API será necessário possuir um Employee(Empregado), Product(Produto).

## Endpoints
A API possui endpoints para Employees e Products.


## Contribuição

Se você deseja contribuir para este projeto, siga estas etapas:

- Fork do repositório
- Crie um branch para sua feature (git checkout -b feature/sua-feature)
- Faça commit das suas alterações (git commit -m 'Adicione sua feature')
- Faça push para o branch (git push origin feature/sua-feature)
- Abra um Pull Request
- Certifique-se de seguir as diretrizes de contribuição 

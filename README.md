# Monetize!

Sistema de deposito e conversão de moedas!


# Arquitetura
##  Backend:

Criado com padrão **REST**.
Protocolos **HTTTP** para comunicação externa.
Banco de dados **Sqlite**.
Design Patters **DDD** com projetos separado:
**Camada CrossCuting** : Responsavel por injeção de dependencias.
**Camada API**: Responsavel pelos controllers da rotas e inicialização do servidor.
**Camada Application**: Responsavel por implementar os UseCases e Regras de negocio com nomeclatura *Services*.
**Camada de Domain** : Responsavel por manter Interfaces, Models, Entities e Enums.
**Camada de Infra**: Responsavel por implementar Providers de implementação externa ao negocio (*Ex: Implementação do Repositorios em banco usado Entity Core, Migrations etc.*) 
 **Camada de Teste** : Respónsavel por mater toda implementação ou preparação dos mocks para testes.
 ### Endpoints:
 `GET /balance -> Lista todos saldos e moedas disponiveis.`
 
 `PUT / Balance-> Recebe um novo deposito e soma ao saldo.`
 
 `GET /moviments -> Retona todas as movimentações feitas sejam elas deposito ou conversão.`

# Frontend

Foi construido com duas tecnologias:
- **Angular 12**
-  **React JS**

No projeto em Angular foi feito em apenas um modulo como typeScript, usando estilização hibrida entre CSS e Bootstrap 5.
No projeto em React foi utilizado o Desigin Patters proprio, usando estilização com Styled-Components e tema global integrado. Construido em apenas uma pagina como TypeScript.

# Executando os projetos

### Backend:
- Primeiro é preciso ter o SDK e Runtime do .Net Core 5 previamente instalado. 
- Segue link da documentação de como fazer : [Instalar o .NET Windows, Linux e macOS | Microsoft Docs](https://docs.microsoft.com/pt-br/dotnet/core/install/)
- Navegue ate a pasta `monetize` na raiz do repositório.
- No terminal rode os seguinte comandos: 
-- Para instalar todas as dependências:

	`dotnet restore`
  
-- Para Compilar:

	`dotnet build`
  
-- Para executar: 

	`dotnet run`
  
-- para rodar os testes: 

	`dotnet test`	
  

### Front Angular
- É preciso ter o setup basico para executar.
- Para isso segue o link da documentação: [Angular - Setting up the local environment and workspace](https://angular.io/guide/setup-local)

- Navegue ate a pasta `monetizeangular`

-- Rode para instalar as dependências:

	`yarn install` ou `npm install`
  
-- Para executa: 

	`yarn start`
  
No navegador acesso http://localhost:4200

### Front React JS
- É preciso ter o setup basico para executar.

- Para isso segue o link da documentação:[Introdução – React (reactjs.org)](https://pt-br.reactjs.org/docs/getting-started.html)

- Navegue ate a pasta `monetize_react`

-- Rode para instalar as dependências:

	`yarn install` ou `npm install`
  
-- Para executa: 

	`yarn start`
  
No navegador acesso http://localhost:3000

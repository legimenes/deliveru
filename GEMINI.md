# Deliveru

## Visão Geral

O **Deliveru** é uma aplicação de entrega que conecta clientes que precisam enviar quaisquer objetos com entregadores disponíveis, calculando rotas, preços e rastreando tudo em tempo real.

Seu domínio está dividido em 5 contextos delimitados:

* **IAM**
* **Order**
* **Dispatch**
* **Tracking**
* **Billing**

## Contexto IAM

O contexto **IAM** lida com a autenticação, autorização e gestão de identidade.

Desenvolvido sobre o ecossistema **.NET 10**, é composto por um projeto **Web Minimal API** utilizando a infraestrutura do **ASP.NET Core Identity** para a gestão de usuários, perfis, credenciais e políticas internas de autenticação. Para a emissão de tokens e a implementação completa dos protocolos OpenID Connect e OAuth2, a solução integra o framework **OpenIddict** como Servidor de Autorização (Authorization Server). O OpenIddict atua em conjunto com o Identity, utilizando seu repositório de usuários, mas fornecendo uma camada avançada e padronizada para fluxos modernos de autenticação — como Authorization Code + PKCE, Client Credentials, Refresh Tokens e outros.

Essa combinação garante que a aplicação siga rigorosamente os padrões oficiais de autenticação e autorização da indústria, oferecendo interoperabilidade, segurança e compatibilidade com qualquer cliente ou serviço que consuma tokens OIDC/OAuth2. Assim, a arquitetura separa de forma clara a gestão de usuários (via ASP.NET Core Identity) da emissão e validação de tokens (via OpenIddict), resultando em um sistema robusto, escalável e aderente às melhores práticas de segurança.

## Contexto Order

Contexto da gestão de pedidos. Implementa a criação, orçamento e persistência do pedido.

## Contexto Dispatch

Contexto da busca do melhor entregador para o pedido. Implementa o motor que lida com a logística de localização do entregador.

## Contexto Tracking

Contexto do rastreamento em tempo real dos entregadores. Implementa o registro e visualização das coordenadas de geolocalização da viagem.

## Contexto Billing

Contexto do faturamento dos pedidos. Implementa o processamento de pagamento.

## Regras e convenções obrigatórias

Todas as sugestões de código, refatorações e novas implementações **DEVEM** aderir às seguintes regras:

## Diretrizes de desenvolvimento de código C#

A principal diretriz é obedecer as regras contidas em no arquivo `.editorconfig` da raíz da solução. Abaixo, as regras que devem ser destacadas e reforçadas.

### 1. Convenções de Nomenclatura

* **Classes, Métodos, Propriedades, Records e Structs**: Usar `PascalCase`.
* **Variáveis Locais e Parâmetros**: Usar `camelCase`.
* **Interfaces**: Devem sempre começar com `I` (ex: `IUserService`).
* **Campos Privados**: Use `_camelCase` (underscore prefixo). Ex: `private readonly ILogger _logger;`.
* **Métodos Assíncronos**: Devem sempre terminar com o sufixo `Async`. Ex: `GetDataAsync()`.

### 2. Sintaxe e Estilo
* **Namespaces**: Utilize "File-scoped namespaces" para reduzir identação (C# 10+).
* **Declaração de Tipos:**
  * **NÃO** use `var`.
  * Sempre use tipos explícitos.
  * **Strings**: Sempre use Interpolação de Strings (`$"{var}"`) em vez de `String.Format` ou concatenação com `+`.
* **Chaves (Braces)**: Use o estilo "Allman" (chaves sempre em uma nova linha).
  ```csharp
  if (isValid)
  {
      // código
  }
  ```
* **Comentários**: **NÃO** comentar ou criar documentações dentro do código.
* **Construtores**: Usar construtores primários sempre que possível.

## Padrões Arquiteturais
* **Repository Pattern:** Acesso a dados DEVE ser feito exclusivamente através de interfaces de repositórios. O `DbContext` não pode ser injetado diretamente em serviços de aplicação.
* **Injeção de Dependência:** Utilizar injeção via construtor para todas as dependências.
* **Tratamento de Erros:** Usar `try-catch` apenas na camada de serviço ou API. Propagar exceções customizadas (`CustomException`) para erros de negócio.

## Testes
* **Framework:** Usar XUnit e o padrão Given-When-Then em todos os testes unitários.
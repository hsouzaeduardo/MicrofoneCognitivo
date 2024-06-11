# MicrofoneCognitivo

![banner](./docs/banner.png)

Demo Microfone Cognitivo utilizando Azure AI Speech

## Pré-requisitos

- [Conta Azure](https://azure.microsoft.com/pt-br/free/)
- [Azure Speech Service](https://azure.microsoft.com/pt-br/services/cognitive-services/speech-service/)
- [Azure Speech SDK](https://docs.microsoft.com/pt-br/azure/cognitive-services/speech-service/quickstarts/setup-platform?tabs=dotnet%2Cwindows%2Cjre%2Cbrowser&pivots=programming-language-csharp)
- [Azure Speech SDK - C#](https://docs.microsoft.com/pt-br/azure/cognitive-services/speech-service/quickstarts/setup-platform?tabs=dotnet%2Cwindows%2Cjre%2Cbrowser&pivots=programming-language-csharp)

## Configuração

- Crie um recurso de fala no portal do Azure
- Obtenha a chave e a região do recurso
- Substitua a chave e a região no código

> O arquivo appsettings.exemplo.json deve ser renomeado, e deve ter o seguinte nome: "appsettings.json". Então preencha as informações obtidas no site do Azure, conforme exemplo abaixo:

```csharp
{
  "SubscriptionKey": "",
  "Region": ""
}

```

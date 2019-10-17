# Executando o projeto:

> Ponto de atenção: O projeto está configurado em modo de deploy.

- Em uma máquina com dotnet instalado é possível executar o projeto acessando via *CMD* a pasta do projeto (../CalculadoraDeFreteSimulado/CalculadoraDeFreteSimulado.API) e executando o comando **_dotnet run_**.

- Ou basta abrir a solução, selecionar o projeto **CalculadoraDeFreteSimulado.API** como principal e executar a *Build*.

## Utilizando a solução:

Trata-se de uma API que busca a melhor negociação de frete e para utilizá-la basta executar um chamada ao link https://localhost:5001/CalculoFrete/ObterCalculoFretePorEmbarque?codigoEmbarque={param/ex:1} via navegador ou ferramenta de *API Client* por exemplo o [Postman](https://www.getpostman.com/downloads/).

> Pontos de atenção: 
> - Ao executar no Postman (ou outra ferramenta) favor desabilitar o **SSL** em *File > Settings > General > **SSL certificate verification***
> - O https://localhost:5001 é o padrão da solução, sendo possível alterá-lo em código.
> - O [?codigoEmbarque={param/ex:1}](?codigoEmbarque={param/ex:1}) é um parâmetro do tipo long obrigátorio para a chamada.
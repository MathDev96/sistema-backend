using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace PrimeiraAPI.Controllers
{

    [Route("api/aula8")]
    [ApiController]

    public class Aula8Controller : ControllerBase
    {
        [Route("olaMundo")]
        [HttpGet]
        public string OlaMundo()
        {
            var mensagem = "Olá mundo via API";

            return mensagem;
        }

        [Route("olaMundoPersonalizado")]
        [HttpGet]
        public string OlaMundoPersonalizado(string nome)
        {
            var mensagem = "Olá mundo via API " + nome;

            return mensagem;
        }

        [Route("somar")]
        [HttpGet]
        public string Somar(decimal valor1, decimal valor2)
        {

            var soma = valor1 + valor2;

            var mensagem = "A soma é " + soma;

            return mensagem;
        }

        [Route("media")]
        [HttpGet]
        public string Media(decimal valor1, decimal valor2)
        {

            var media = valor1 / valor2;

            var mensagem = "A media é " + media;

            return mensagem;
        }

        [Route("terreno")]
        [HttpGet]

        public string Terreno(decimal valor1, decimal valor2, decimal valor3)
        {
            var calculoArea = valor1 * valor2;
            var calculoValorArea = valor3 / calculoArea;

            var mensagem = "A área desse terreno é: " + calculoArea + " M²." + " E o valor desse terreno por M² é: R$ " + calculoValorArea;

            return mensagem;
        }
        
        [Route("troco")]
        [HttpGet]

        public string Troco(decimal valor1, decimal valor2, decimal valor3)
        {
            var calculo = valor1 * valor2;
            var calculo2 = valor3 - calculo;

            var mensagem = "O valor da compra é: R$ " + calculo + " e o troco do cliente é: R$ " + calculo2;

            return mensagem;

        }

        [Route("funcionario")]
        [HttpGet]

        public string Funcionario(string nome, decimal valor1, decimal valor2, decimal valor3)
        {
            var calculo = valor1 / valor2;
            var calculo2 = calculo / valor3;

            var calculo3 = valor2 * valor3;

            var mensagem = "Olá, " + nome + ". Você recebe R$ " + calculo + " por dia e recebe R$ " + calculo2 + " por hora trabalhada. Você trabalha " + calculo3 + " horas por mês.";

            return mensagem;
        }

        [Route("kilometragem")]
        [HttpGet]

        public string Kilometragem(decimal valor1, decimal valor2)
        {
            var calculo = valor1 / valor2;
            
            var mensagem = "O consumo médio do veículo é de R$ " + calculo + " por litro. ";
            return mensagem;
        }

    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.models;

namespace PrimeiraAPI.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class Aula11Controller : ControllerBase
    {
        [Route("obterVeiculo")]
        [HttpGet]
        //Instancia da classe
        public Veiculo obterVeiculo()
        {
            //Objeto
            var meuVeiculo = new Veiculo();
            
            meuVeiculo.Cor = "Amarelo";
            meuVeiculo.Marca = "Fiat";
            meuVeiculo.Modelo = "Argo";
            meuVeiculo.Placa = "DEX-4321";

            meuVeiculo.Acelerar();
            meuVeiculo.Acelerar();

            return meuVeiculo;
        }
        //ENDpoint
        [Route("obterCarro")]
        [HttpGet]
        
        //instancia da classe Carro
        public Carro obterCarro()
        {
            //Objeto
            var meuCarro = new Carro();

            meuCarro.Marca = "Honda";
            meuCarro.Modelo = "Fit";
            meuCarro.Placa = "DRT-5588";
            meuCarro.Cor = "Vermelho";

            meuCarro.Acelerar();
            
            return meuCarro;

        }
        [Route("obterMoto")]
        [HttpGet]
        public Moto obterMoto()
        {
            var minhaMoto = new Moto();

            minhaMoto.Marca = "Yamaha";
            minhaMoto.Modelo = "Fazer 250";
            minhaMoto.Placa = "TCX - 5555";
            minhaMoto.Cor = "Preta";

            minhaMoto.Acelerar();

            return minhaMoto;
        }
    }
}

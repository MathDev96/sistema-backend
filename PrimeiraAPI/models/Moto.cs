namespace PrimeiraAPI.models
{
    //Classe moto herdando atributos da classe Veiculo
    public class Moto : Veiculo
    {
        //Construtor (Colocar as caracteristicas especificas da classe Moto)
        public Moto()
        {
            QuantidadaRodas = 2;

            TanqueCombustivel = 15;
        }

        public override void Acelerar()
        {
            InjetarCombustivel(1);
        }
        //Encapsulamento
        private void InjetarCombustivel(int quantidadeCombustivel)
        {
            base.TanqueCombustivel = base.TanqueCombustivel - quantidadeCombustivel;
        }

        public int QuantidadaRodas { get; set; }
    }
       
}
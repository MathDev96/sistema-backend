namespace PrimeiraAPI.models
{
    //Classe Carro herdando atributos da classe Veiculo
    public class Carro : Veiculo
    {
        //Construtor (Colocar as caracteristicas especificas da classe Carro)
        public Carro() 
        {
            QuantidadeRodas = 4;

            
        }

        public int QuantidadeRodas { get; set; }

        //Override é usado para sobrescrever o metodo herdado da classe mãe (polimorfismo)
        public override void Acelerar()
        {
            InjetarCombustivel(4);
        }
        //Encapsulamento
        private void InjetarCombustivel(int quantidadeCombustivel)
        {
            //base está chamando o TanqueCombustivel da classe Viuculo
            base.TanqueCombustivel = base.TanqueCombustivel - quantidadeCombustivel;
        }
    }
}

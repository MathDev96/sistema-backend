namespace PrimeiraAPI.models
{
    //Classe mãe
    public class Veiculo
    {
        //Construtor (Colocar as caracteristicas especificas da classe Veiculo)
        public Veiculo()
        {
            TanqueCombustivel = 40;
        }
        
        // atributos ou propriedades da classe Veiculo
        public string Cor { get; set; }

        public string Marca { get; set; }

        public string Placa { get; set; }

        public string Modelo { get; set; }

        public int TanqueCombustivel { get; set; }

        //Metodos(funções/comportamentos)
        //virtual permite que as classes herdadas subscreva o metodo Acelerar e Frear (polimorfismo)
        public virtual void Acelerar() 
        {
            InjetarCombustivel(2);
        }

        public void Frear() 
        {

        } 
        //Encapsulamento
        private void InjetarCombustivel (int quantidadeCombustivel)
        {
            TanqueCombustivel = TanqueCombustivel - quantidadeCombustivel;
        }
    }
}

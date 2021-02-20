namespace Projeto_Csharp_1.Classes
{
    public  class Funcionarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Funcao { get; set; }
        public int SubtotaisPorCargo { get; set; }
        public int TotalGeral { get; set; }

        public static int ContarFuncao;

        public static int AdicionarFuncao()
        {
            return ++ContarFuncao;
        }

    }
}

using Projeto_Csharp_1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Csharp_1
{
    class Program
    {
         private static List<Funcionarios> ListaFuncionario = new List<Funcionarios>();
            static void Main(string[] args)
            {
                Int32 opcao1 = MostrarMenu();
                MainCall(opcao1);
                Console.Read();

            }


        private static void MainCall(Int32 option)
        {
            Int32 resultado = 0;
            Int32 contas = 0;
            switch (option)
            {
                case 1:
                    AdicionarFuncionario();
                    break;
                case 2:
                    MostrarLista();
                    Int32 opcao1 = MostrarMenu();
                    MainCall(opcao1);
                    break;
                case 3:
                    Console.WriteLine("Digite o Id do Funcionário para o qual você queira atualizar: ");
                    contas = Convert.ToInt32(Console.ReadLine());
                    resultado = Update(contas);
                    break;
                case 4:
                    Console.WriteLine("Digite o Id do Funcionário que você queira deletar: ");
                    contas = Convert.ToInt32(Console.ReadLine());
                    resultado = DeleteEmployee(contas);
                    if (resultado == 1)
                        Console.WriteLine("Funcionário Deletado");
                    else
                        Console.WriteLine("Funcionário com o Id : " + contas + " Não foi encontrado");
                    opcao1 = MostrarMenu();
                    MainCall(opcao1);
                    break;
                case 5:
                    Console.WriteLine("Obrigado por usar o sistema");
                    break;
                default:
                    Console.WriteLine("Invalidado!!!!!!Tente Novamente");
                    opcao1 = MostrarMenu();
                    MainCall(opcao1);
                    break;
            }
        }




        private static int MostrarMenu()
            {
                Console.WriteLine("\nSelecione alguma opção:");
                Console.WriteLine("1. Adicionar Funcionário");
                Console.WriteLine("2. Mostrar Funcionário");
                Console.WriteLine("3. Editar Funcionário");
                Console.WriteLine("4. Deletar Funcionário");
                Console.WriteLine("5. Sair");

                Int32 opcao = 0;

                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {

                    Console.WriteLine("Ocorreu algum erro");
                }

                return opcao;
            }


            private static List<Funcionarios> AdicionarFuncionario()
            {
                Funcionarios funcionarios = new Funcionarios();

                try
                {
                    Console.WriteLine("Digite as informações para adicionar o funcionário:");
                    Console.WriteLine("Digite o Nome: ");
                    funcionarios.Nome = Console.ReadLine();
                    Console.WriteLine("Digite o Sobrenome");
                    funcionarios.SobreNome = Console.ReadLine();
                    Console.WriteLine("Digite o ID: ");
                    funcionarios.Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o Função: ");
                    funcionarios.Funcao = Console.ReadLine();

                    if (ListaFuncionario.Count > 0)
                    {
                        if (ListaFuncionario.Exists(emp => emp.Id == funcionarios.Id))
                        {
                            Console.WriteLine("Funcionário Já existe com ID: " + funcionarios.Id);

                        }
                        else
                        {
                            ListaFuncionario.Add(funcionarios);
                        }
                    }
                    else
                    {
                        ListaFuncionario.Add(funcionarios);
                        Console.WriteLine("Funcionário adicionado com sucesso");
                    }

                    Console.WriteLine(@"Você quer adicionar mais um funcionário? S\N");
                    char choice = Console.ReadKey().KeyChar;
                    switch (Char.ToUpper(choice))
                    {
                        case 'S':
                            AdicionarFuncionario();
                            break;
                        case 'N':
                            Int32 option1 = MostrarMenu();
                            MainCall(option1);
                            break;
                        default:
                            Console.WriteLine("Ocorreu algum erro!! Fvor, selecione a opção certa");
                            Console.WriteLine("-----------------------------------------------");
                            option1 = MostrarMenu();
                            MainCall(option1);
                            break;

                    }
                }

                catch (Exception)
                {
                        Console.WriteLine("Ocorreu algum erro!! Favor, selecione a opção certa");
                        Console.WriteLine("-----------------------------------------------");
                        Int32 option1 = MostrarMenu();
                        MainCall(option1);

                }

                    return ListaFuncionario;
            }

                private static void MostrarLista()
                {
                    Console.WriteLine("");
                    Console.WriteLine("-----------------------------Detalhes do Funcionário---------------------------------------");

                   

                    foreach (Funcionarios emp in ListaFuncionario)
                    {
                        Console.WriteLine("IdFuncionario: " + emp.Id + " Nome: " + emp.Nome + " SobreNome: " + emp.SobreNome + " Função: " + emp.Funcao);
                        
                    }

                        ListaOrdenadaPorSobreNome();
                        AgruparPorFuncao();
                        TotaisPorfuncoes();


                }

                private static Int32 Update(Int32 id)
                {
                    Int32 resultado = 0;
                    Funcionarios funcionarios = new Funcionarios();

                    try
                    {
                        var empinfo = ListaFuncionario.Where(e => e.Id == id).FirstOrDefault();
                        if (empinfo != null)
                        {
                            Console.WriteLine("Digite o Nome");
                            funcionarios.Nome = Console.ReadLine();
                            Console.WriteLine("Digite a Função");
                            funcionarios.Funcao = Console.ReadLine();
                            ListaFuncionario.Where(e => e.Id == id).FirstOrDefault().Nome = funcionarios.Nome;
                            ListaFuncionario.Where(e => e.Id == id).FirstOrDefault().Funcao = funcionarios.Funcao;
                            Console.WriteLine("Funcionário com o id: " + id + "Atualizado com sucesso");
                            Int32 option1 = MostrarMenu();
                            MainCall(option1);
                        }
                        else
                        {
                            Console.WriteLine("Funcionário do ID:" + id + "Não existe");
                            Int32 option1 = MostrarMenu();
                            MainCall(option1);
                        }
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Ocorreu algum erro!! Favor, selecione a opção certa");
                        Console.WriteLine("-----------------------------------------------");
                        Int32 option1 = MostrarMenu();
                        MainCall(option1);

                    }
                    return resultado;

                }

                private static int DeleteEmployee(Int32 empid)
                {
                    Int32 result = ListaFuncionario.RemoveAll(e => e.Id == empid);
                    return result;
                }


                static void ListaOrdenadaPorSobreNome()
                {
                    
                    ListaFuncionario.Sort(delegate (Funcionarios p1, Funcionarios p2)
                    {
                        return p1.SobreNome.CompareTo(p2.SobreNome);
                    });

                    //ListaFuncionario.ForEach(delegate (Funcionarios p)
                    //{
                    //    Console.WriteLine(String.Format("{0} {1}", p.SobreNome, p.Id));
                    //});
                }

                private static void AgruparPorFuncao()
                {
                    var listaAgrupada = from funcionarios in ListaFuncionario
                                        group funcionarios by funcionarios.Funcao into funcaoGrupo
                                        orderby funcaoGrupo.Key ascending
                                        select funcaoGrupo;

                    foreach (var grupo in listaAgrupada)
                    {
                        Console.WriteLine(string.Format($"Curso:{grupo.Key}"));

                        foreach (var funcionarios in grupo)
                        {

                            Console.WriteLine($"{funcionarios.Id} - {funcionarios.Nome}");
                        }
                    }
                }

               private static void TotaisPorfuncoes()
               {
                    var lista = new List<Funcionarios>();

                    var AgrouparLista = lista.GroupBy(x => x.Funcao)
                                        .Select(g => new
                                        {
                                            Key = g.Key,
                                            Count = g.Count(),
                                            ListaFuncionario = g.GroupBy(x => x.Nome)
                                        });

                    foreach (var grupo in AgrouparLista)
                    {
                        Console.WriteLine(string.Format($"Curso:{grupo.ListaFuncionario}"));

                        
                    }
               }
    }
}









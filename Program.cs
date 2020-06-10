using RestSharp;
using System;

namespace teste1
{
    class Program
    {
        static void Main(string[] args)
        {
            string resp = "S";
            while (resp == "S") 
            {
                Console.WriteLine();
                Console.WriteLine("------------BEM VINDO A PLOOMES------------");
                Console.WriteLine();
                Console.WriteLine("            Escolha uma Opcçao?");
                Console.Write($"                 1-Cliente \n                 2-Negócios \n");
                int OqFazer = int.Parse(Console.ReadLine());

                switch (OqFazer)
                {
                    case 1:

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("-----------CLIENTE-----------");
                            Console.WriteLine();
                        
                            AddCliente NovoCliente = new AddCliente();
                            Console.Write("  Cadastrar Cliente:  ");
                            NovoCliente.SetNome(Console.ReadLine());
                            Console.Write("  Adicione o Tipo do CLiente: Empresa(1) - Pessoa(2)   ");
                            NovoCliente.SetType(int.Parse(Console.ReadLine()));

                            Console.WriteLine(NovoCliente.Post());

                            Console.WriteLine("Cadastrar mais Clintes? (S/N)");
                            resp = Console.ReadLine();
                            Console.Clear();
                        } while (resp == "s");

                            Console.Clear();
                            Console.WriteLine("Saindo....");
                            resp = "N";                    
                        break;


                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("-------------------------------NEGÓCIOS-------------------------------");
                            Console.WriteLine();
                            Console.Write($"   1-Novo Negocio  2-Criar Tarefa  3-Atualizar Negociação  4-Ganhar Negociação \n");
                            int IdNegocio = int.Parse(Console.ReadLine());

                            switch (IdNegocio)
                            {
                                case 1:
                                    do
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("-----------NOVO NEGÓCIO-----------");
                                        Console.WriteLine();
                                        Negocios NovaNegocio = new Negocios();
                                    
                                        Console.Write("  Titulo da Negociação:  ");
                                        NovaNegocio.Titulo = Console.ReadLine();

                                        Console.Write("  Identificação do Cliente:  ");
                                        NovaNegocio.IdCliente = double.Parse(Console.ReadLine());

                                        Console.Write("  Valor do Negócio:  ");
                                        NovaNegocio.ValorNegocio = double.Parse(Console.ReadLine());


                                        Console.WriteLine(NovaNegocio.PostNegocios());

                                        Console.WriteLine("Deseja Continuar? (S/N)");
                                        resp = Console.ReadLine();
                                        Console.Clear();
                                    } while (resp == "s");

                                        Console.Clear();
                                        Console.WriteLine("Saindo....");
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("-----------TAREFA-----------");
                                    Console.WriteLine();
                                    Tarefas Tarefa = new Tarefas();
                                    Console.WriteLine(" 1 - Criar Tarefa      2- Finalizar Tarefa ");
                                    int tarefa = int.Parse(Console.ReadLine());

                                    switch (tarefa)
                                    {
                                        case 1:
                                            do
                                            {
                                                Console.WriteLine("-----------Criar Tarefa-----------");
                                                Console.WriteLine(); 

                                                Console.Write("Titulo da Tarefa:  ");
                                                Tarefa.Titulo = Console.ReadLine();

                                                Console.Write("Descrição da Tarefa:  ");
                                                Tarefa.Descricao = Console.ReadLine();

                                                Console.Write("Data da Tarefa- (dd/mm/aaaa):  ");
                                                Tarefa.Data = DateTime.Parse(Console.ReadLine());

                                                Console.Write("Codigo do Cliente: ");
                                                Tarefa.IdCliente = int.Parse(Console.ReadLine());


                                                Console.WriteLine(Tarefa.Post());

                                                Console.WriteLine("Deseja Continuar? (S/N)");
                                                resp = Console.ReadLine();

                                            } while (resp == "s");

                                            Console.Clear();
                                            Console.WriteLine("Saindo....");
                                            break;

                                        case 2:
                                            do
                                            {
                                                Console.WriteLine("-----------Finalizar Tarefa-----------");
                                                Console.WriteLine();
                                            
                                                Console.Write("Codigo da Tarefa:  ");
                                                Tarefa.IdTarefa = int.Parse(Console.ReadLine());

                                                Console.WriteLine("Deseja realmente finalizar essa tarefa? (S/N)");
                                                if (Console.ReadLine() == "s")
                                                {
                                                    Tarefa.finished = true; 
                                                }
                                                Console.WriteLine(Tarefa.Finalizar());
                                            } while (resp == "s");
                                            Console.Clear();
                                            Console.WriteLine("Saindo....");
                                            break;
                                    }

                                    
                                     break;


                                case 3:
                                    do
                                    {
                                        Console.WriteLine("----------ATUALIZAR NEGOCIAÇÃO-----------");
                                        Console.WriteLine();
                                        Negocios Atualizar = new Negocios();

                                        Console.WriteLine("Código da Negociação:");
                                        Atualizar.IdNegocio = double.Parse(Console.ReadLine());
                                        Console.WriteLine("Atualizar Valor da Negociação:");
                                        Atualizar.ValorNegocio = double.Parse (Console.ReadLine());

                                        Console.WriteLine(Atualizar.PatchNegocios());

                                        Console.WriteLine("Deseja Continuar? (S/N)");
                                        resp = Console.ReadLine();

                                    } while (resp == "s");

                                    Console.Clear();
                                    Console.WriteLine("Saindo....");
                                    break;

                                
                            }
                            

                        }                       
                            Console.Clear();
                            Console.WriteLine("Saindo....");
                            resp = "N";
                        break;
                }
            }
            
            
               
            

            Console.ReadKey();



        }
    }
}

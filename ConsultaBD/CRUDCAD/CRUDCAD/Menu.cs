using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCAD
{
    class Menu
    {
        public void Inicio()
        {
            Console.Clear();
            Console.WriteLine("            ----------------------------------------------------------");//58
            Console.WriteLine("            -------------------------- MENU --------------------------");//26MENU24
            Console.WriteLine("            ----------------------------------------------------------");//58
            Console.WriteLine("            ----- 1. FUNCIONARIO ----- 2. CLIENTE ----- 3. CARRO -----");//5 FUNCIONARIO//5
            Console.WriteLine("            ----------------------------------------------------------");
            Console.WriteLine("\n\n\n");

            try
            {
                int i = int.Parse(Console.ReadLine());
                Console.Clear();

                if (i == 1)
                {
                    Funcionario();
                }
                else if (i == 2)
                {
                    // Cliente();
                }
                else if (i == 3)
                {
                    // Carro();
                }
                else
                {
                    Console.WriteLine("\n\n Opção não encontrada !");
                    Console.ReadKey();
                    Inicio();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n ERRO: DIGITE APENAS VALORES NUMERICOS !");
                Console.ReadKey();
                Console.Clear();
                Inicio();
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n\n ERRO: VARIAVEL NAO SUPORTA ESSA QUANTIDADE DE NUMEROS !");
                Console.ReadKey();
                Console.Clear();
                Inicio();
            }
        }

        public void Funcionario()
        {
            Console.WriteLine(" 1. Cadastrar Funcionario");
            Console.WriteLine(" 2. Consultar Funcionario");
            Console.WriteLine(" 3. Alterar Funcionario");
            Console.WriteLine(" 4. Deletar Funcionario");
            Console.WriteLine(" 5. Voltar\n\n");

            try
            {
                int ii = int.Parse(Console.ReadLine());
                Console.Clear();

                if (ii == 1)
                {
                    BancoDados f = new BancoDados();
                    f.NovoFuncionario();
                    Console.ReadKey();
                    Console.Clear();
                    Funcionario();
                }
                else if (ii == 2)
                {
                    BancoDados f = new BancoDados();
                    f.ConsultarFuncionario();
                    Console.ReadKey();
                    Console.Clear();
                    Funcionario();
                }
                else if (ii == 3)
                {
                    BancoDados f = new BancoDados();
                    f.AlterarFuncionario();
                    Console.ReadKey();
                    Console.Clear();
                    Funcionario();
                }
                else if (ii == 4)
                {
                    BancoDados f = new BancoDados();
                    // f.DeletarFuncionario();
                    Console.ReadKey();
                    Console.Clear();
                    Funcionario();
                }
                else if (ii == 5)
                {
                    Inicio();
                }
                else
                {
                    Console.WriteLine("\n\n Opção não encontrada !");
                    Console.ReadKey();
                    Console.Clear();
                    Funcionario();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n ERRO: DIGITE APENAS VALORES NUMERICOS !");
                Console.ReadKey();
                Console.Clear();
                Funcionario();
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n\n ERRO: VARIAVEL NAO SUPORTA ESSA QUANTIDADE DE NUMEROS !");
                Console.ReadKey();
                Console.Clear();
                Funcionario();
            }
        }
    }
}
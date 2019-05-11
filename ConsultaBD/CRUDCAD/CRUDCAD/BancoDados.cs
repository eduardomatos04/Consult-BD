using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace CRUDCAD
{
    class BancoDados
    {

        private string stringConexao =
 @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\PC\Documents\ConsultaBD\BDCRUD\BDCRUD.mdb";
        private OleDbConnection ObterConexao()
        { return new OleDbConnection(stringConexao); }

        // Classe Funcionario
        public void NovoFuncionario()
        {
            OleDbConnection con = ObterConexao();
            try
            {
                Funcionario objFun = new Funcionario();
                Console.WriteLine
                    ("Digite o nome do funcionario");
                objFun.Nome = Console.ReadLine();
                Console.WriteLine
                    ("\nDigite o CPF Funcionário");
                long aux = long.Parse(Console.ReadLine());
                objFun.CPF = Convert.ToString(aux);
                Console.WriteLine
                    ("\nDigite o cargo do funcionário");
                objFun.Cargo = Console.ReadLine();

                if (objFun.Nome == "" || aux <= 0 ||
                    objFun.Cargo == "")
                {
                    throw new CampoVazio
                   ("\n\nErro:Preencha todos os campos!!");
                }
                else
                {
                    con.Open();
                    string sql =
                        String.Format
                   ("INSERT INTO funcionario (nome,cpf, cargo)" +
                   "VALUES('{0}', '{1}', '{2}')");
                    OleDbCommand cmd = new OleDbCommand
                        (sql, con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine
                   ("\n\n     Funcionário cadastrado com sucesso!");
                }
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("\n\n" + ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu objNovo = new Menu();
                objNovo.Funcionario();
            }
            catch (CampoVazio ex)

            {
                Console.WriteLine("\n\n" + ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu objNovo = new Menu();
                objNovo.Funcionario();
            }
            catch (FormatException)
            {
                Console.WriteLine
                ("\n\nError: CPF ACEITA APENAS NÚMEROS");
                Console.ReadKey();
                Console.Clear();
                Menu objNovo = new Menu();
                objNovo.Funcionario();

            }
            catch (OverflowException)
            {
                Console.WriteLine
                   ("\n\nError: NÚMERO CPF MUITO GRANDE!!");
                Console.ReadKey();
                Console.Clear();
                Menu objNovo = new Menu();
                objNovo.Funcionario();
            }
            finally
            {
                con.Close();
            }
        }
        public void ConsultarFuncionario()
        {
            OleDbConnection con = ObterConexao();
            OleDbDataReader dr = null;
            try
            {
                con.Open();
                string sql =
                    "SELECT * FROM Funcionario";
                OleDbCommand cmd = new OleDbCommand
                    (sql, con);
                dr = cmd.ExecuteReader();
                Console.WriteLine
               ("Consultando os dados do Funcionário!");

                while (dr.Read())
                {
                    Funcionario f = new Funcionario();
                    f.Id = (int)dr["idFuncionario"];
                    f.Nome = dr["Nome"].ToString();
                    f.CPF = dr["CPF"].ToString();
                    f.Cargo = dr["Cargo"].ToString();
                    Console.WriteLine
     ("ID:{0} | Nome: {1} | CPF: {2} | Cargo: {3}.\n",
     f.Id, f.Nome, f.CPF, f.Cargo);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine
                      ("ERROR:" + ex.Message);
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }

        public void AlterarFuncionario()
        { OleDbConnection con = ObterConexao();
            OleDbDataReader dr = null;

            try
            {
                Console.WriteLine("Digite o n° CPF Funcionario!!\n");
                long auxi = long.Parse(Console.ReadLine());
                string cpfatt = Convert.ToString(auxi);

                con.Open();
                string sql = string.Format
                    ("SELECT * FROM Funcionario WHERE CPF = '{0}'", cpfatt);
                OleDbCommand cmd = new OleDbCommand
                    (sql, con);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Console.WriteLine("\n\nFuncionario a ser alterado");
                    Funcionario objFunc = new Funcionario();
                    objFunc.Id = (int)dr["IdFuncionario"];
                    objFunc.Nome = dr["Nome"].ToString();
                    objFunc.CPF = dr["CPF"].ToString();
                    objFunc.Cargo = dr["Cargo"].ToString();
                    Console.WriteLine("ID: {0} | NOME: {1} | CPF: {2} | CARGO: {3}.\n", objFunc.Id,
                                                                                        objFunc.Nome,
                                                                                        objFunc.CPF,
                                                                                        objFunc.Cargo);


                    Funcionario objFun = new Funcionario();
                    Console.Write("Digite o nome do funcionario:");
                    objFunc.Nome = Console.ReadLine();

                    Console.Write("\nDigite CPF do funcionario:");
                    long aux = long.Parse(Console.ReadLine());
                    objFunc.CPF = Convert.ToString(aux);

                    Console.Write("\nDigite o cargo do funcionario:");
                    objFunc.Cargo = Console.ReadLine();

                    if (objFun.Nome == "" || aux < 0 || objFun.Cargo == "")
                    {
                        throw new CampoVazio
                            ("\n\nErro: Preencha todos os dados !!");
                    }
                    else
                    {
                        string sqll = string.Format
                            ("UPDATE Funcionario SET Nome = '{0}'," + "CPF = '{1}', Cargo '{2}' WHERE CPF = '{3}'",
                            objFun.Nome,
                            objFun.CPF,
                            objFun.Cargo,
                            cpfatt);

                        OleDbCommand cmdUp = new OleDbCommand(sqll, con);

                        cmdUp.ExecuteNonQuery();

                        Console.WriteLine("Funcionario alterado com sucesso!!\n");

                    }
                }
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("\n\n:" + ex.Message);

                Console.ReadKey();
                Console.Clear();

                Menu novo = new Menu();
                novo.Funcionario();
            }
        }
    }
}
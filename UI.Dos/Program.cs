using System;
using System.Data.Odbc;

namespace UI.Dos
{
    class Program
    {
        static void Main(string[] args)
        {
          
            OdbcConnection conn = new OdbcConnection(
                @"DRIVER=SQLite3 ODBC Driver;Database=f:\php\cadastro-ecv\database\database.sqlite;LongNames=0;Timeout=1000;NoTXN=0;SyncPragma = NORMAL; StepAPI = 0;");

            conn.Open();

            Console.Write("Usuário:");
            string nome =  Console.ReadLine();
            Console.Write("Senha:");
            string senha = Console.ReadLine();
            Console.Write("Email:");
            string email = Console.ReadLine();


            string stQuery = string.Format("insert into users(name, email, password) values ('{0}','{1}','{2}')", nome, email, senha); 
            OdbcCommand cmdInsert = new OdbcCommand(stQuery, conn);
            cmdInsert.ExecuteNonQuery();

            stQuery = "select * from users";
            OdbcCommand cmdSelect = new OdbcCommand(stQuery, conn);
            OdbcDataReader dados = cmdSelect.ExecuteReader();

            foreach(var dado in dados)
            {
                Console.WriteLine("Nome: {0} | Email: {1}", dados["name"], dados["email"]);
            }

        }
    }
}

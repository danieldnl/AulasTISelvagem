using System;
using System.Data.Odbc;
using System.Data.SQLite;

namespace UI.Dos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Usuário:");
            string nome =  Console.ReadLine();
            Console.Write("Senha:");
            string senha = Console.ReadLine();
            Console.Write("Email:");
            string email = Console.ReadLine();

            var contexto = new Contexto();

            string stQuery = string.Format("insert into users(name, email, password) values ('{0}','{1}','{2}')", nome, email, senha);
            contexto.ExecuteNonQuery(stQuery);

            stQuery = "select * from users";
            SQLiteDataReader dados = contexto.ExecuteReader(stQuery);

            foreach(var dado in dados)
            {
                Console.WriteLine("Nome: {0} | Email: {1}", dados["name"], dados["email"]);
            }

        }
    }
}

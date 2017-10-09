using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace UI.Dos
{
    class Contexto : IDisposable
    {
        private readonly SQLiteConnection con;

        public Contexto()
        {
            con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["SqliteCon"].ConnectionString);
            con.Open();
        }

        public void ExecuteNonQuery(string strQuery)
        {
            var cmd = new SQLiteCommand {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = con
            };

            cmd.ExecuteNonQuery();
        }

        public SQLiteDataReader ExecuteReader(string strQuery)
        {
            var cmd = new SQLiteCommand(strQuery, con);
            return cmd.ExecuteReader();
        }

        public void Dispose()
        {
            if(con.State == ConnectionState.Open)
                con.Close();
        }
    }
}

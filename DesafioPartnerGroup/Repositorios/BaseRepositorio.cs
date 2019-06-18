using DesafioPartnerGroup.Dto;
using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace DesafioPartnerGroup.Repositorios
{
    public abstract class BaseRepositorio
    {

        public static RetornoDto ExecutaQuery(string commandText)
        {
            RetornoDto RetMsg = new RetornoDto();
            try
            {

                string constring = ConfigurationManager.AppSettings["constr"].ToString();
                using (SQLiteConnection con = new SQLiteConnection("Data Source =" + constring+ ";" + "Version = 3;"))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(commandText, con))
                    {
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                RetMsg.OK = "S";
                RetMsg.Mensagem = "Sucesso";
            }
            catch (Exception ex)
            {
                RetMsg.OK = "N";
                RetMsg.Mensagem = ex.Message;
            }
            return RetMsg;

        }

        public static SQLiteDataReader OpenQuery(string commandText, CommandType commandType, params IDbDataParameter[] parameters)
        {
            string constring = ConfigurationManager.AppSettings["constr"].ToString();
            SQLiteConnection con = new SQLiteConnection("Data Source =" + constring + ";" + "Version = 3;");
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(commandText, con);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            SQLiteDataReader reader = cmd.ExecuteReader();

            return reader;
        }

    }
}
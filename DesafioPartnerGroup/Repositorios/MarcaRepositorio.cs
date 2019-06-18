using DesafioPartnerGroup.Dto;
using DesafioPartnerGroup.Model;
using DesafioPartnerGroup.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPartnerGroup.Repositorios
{
    public class MarcaRepositorio : BaseRepositorio
    {
        private long ObterID() {

            //string commando = "SELECT * FROM marca WHERE ((marcaid = @p_id)or(@p_id is null));";
            string commando = "SELECT MAX(MarcaID) as Maximo FROM marca";
            SQLiteCommand cmd = new SQLiteCommand();

            var dr = OpenQuery(commando, CommandType.Text);

            var  vMax = Convert.ToInt64(dr["Maximo"].ToString());

            dr.Close();
            dr.Dispose();

            return vMax;
        }

        private long? ExisteNome(string nome)
        {


            //string commando = "SELECT * FROM marca WHERE ((marcaid = @p_id)or(@p_id is null));";
            string commando = "SELECT Count(MarcaID) as Contador FROM marca WHERE Upper(Nome) = Upper(@p_nome)";
            SQLiteCommand cmd = new SQLiteCommand();

            var parameters = new SQLiteParameter[]
            {
                    new SQLiteParameter("@p_nome", DbType.AnsiString){ Value = nome, Direction = ParameterDirection.Input}
            };

            var dr = OpenQuery(commando, CommandType.Text, parameters);

            int retorno = 0;
            if (dr.HasRows)
            {
                retorno = 1;
            }

            dr.Close();
            dr.Dispose();

            return retorno;
        }


        public RetornoDto Inserir(long? id, string nome)
        {
            long? vID = ExisteNome(nome);

            if(vID == 0)
            {
                string commando = string.Format("INSERT INTO marca(marcaid, nome) VALUES ({0},'{1}');", id, nome);
                return ExecutaQuery(commando);
            }
            else
            {
                RetornoDto d = new RetornoDto();
                d.OK = "N";
                d.Mensagem = "Esse nome ja Existe no banco de dados";

                return d;           
            }

        }

        public List<MarcaDto> ObterPatrimonio(long? id)
        {
            {
                //string commando = "SELECT * FROM marca WHERE ((marcaid = @p_id)or(@p_id is null));";
                string commando = "SELECT marca.* FROM marca " +
                                  "INNER JOIN patrimonio ON patrimonio.marcaid = marca.marcaid " +
                                  "WHERE patrimonio.ntombo = @p_id";

                List<MarcaDto> LstMarca = new List<MarcaDto>();
                SQLiteCommand cmd = new SQLiteCommand();

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@p_id", DbType.Int64){ Value = id, Direction = ParameterDirection.Input}
                };

                var dr = OpenQuery(commando, CommandType.Text, parameters);


                List<MarcaDto> lstmarca = new List<MarcaDto>();
                while (dr.Read())
                {
                    lstmarca.Add(
                         new MarcaDto()
                         {
                             MarcaID = Convert.ToInt64(dr["marcaid"].ToString()),
                             Nome = dr["nome"].ToString()
                         }
                    );
                }

                dr.Close();
                dr.Dispose();

                return lstmarca;
            }
        }



        public List<MarcaDto> Obter(long? id)
        {
            {
                //string commando = "SELECT * FROM marca WHERE ((marcaid = @p_id)or(@p_id is null));";
                string commando = "SELECT * FROM marca WHERE marcaid = @p_id";
                List<MarcaDto> LstMarca = new List<MarcaDto>();
                SQLiteCommand cmd = new SQLiteCommand();

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@p_id", DbType.Int16){ Value = id, Direction = ParameterDirection.Input}
                };

                var dr = OpenQuery(commando, CommandType.Text, parameters);


                List<MarcaDto> lstmarca = new List<MarcaDto>();
                while (dr.Read())
                {
                    lstmarca.Add(
                         new MarcaDto()
                         {
                             MarcaID = Convert.ToInt64(dr["marcaid"].ToString()),
                             Nome = dr["nome"].ToString()
                         }
                    );
                }

                dr.Close();
                dr.Dispose();

                return lstmarca;
            }
        }

        public List<MarcaDto> Lista()
        {
            {
                //string commando = "SELECT * FROM marca WHERE ((marcaid = @p_id)or(@p_id is null));";
                string commando = "SELECT * FROM marca";
                List<MarcaDto> LstMarca = new List<MarcaDto>();
                SQLiteCommand cmd = new SQLiteCommand();

                var dr = OpenQuery(commando, CommandType.Text);


                List<MarcaDto> lstmarca = new List<MarcaDto>();
                while (dr.Read())
                {
                    lstmarca.Add(
                         new MarcaDto()
                         {
                             MarcaID = Convert.ToInt64(dr["marcaid"].ToString()),
                             Nome = dr["nome"].ToString()
                         }
                    );
                }

                dr.Close();
                dr.Dispose();

                return lstmarca;
            }
        }

        public RetornoDto Update(long? id, string nome)
        {
            string commando = string.Format("Update marca set nome = '{0}' where marcaid = {1}", nome, id);
            return ExecutaQuery(commando);
        }

        public RetornoDto Delete(long? id)
        {
            string commando = string.Format("Delete from marca where marcaid = {0}", id);
            return ExecutaQuery(commando);
        }



    }
}

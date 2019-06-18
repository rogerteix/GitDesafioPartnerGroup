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
    public class PatrimonioRepositorio : BaseRepositorio
    {

        public RetornoDto Inserir(long? marcaid, string nome, string descricao)
        {
            long? vMax = ObterID();

            RetornoDto RetMsg = new RetornoDto();
            string commando = "INSERT INTO patrimonio(marcaid, nome, descricao, ntombo) VALUES ('" + marcaid + "', '" + nome + "', '" + descricao + "', '" + vMax + "');";
            return ExecutaQuery(commando);
        }

        private long? ObterID()
        {
            string commando = "SELECT MAX(ntombo) as Maximo FROM patrimonio";
            SQLiteCommand cmd = new SQLiteCommand();

            var dr = OpenQuery(commando, CommandType.Text);

            DataTable dt = new DataTable();
            dt.Load(dr);

            long? retorno = 1;
            if (dt.Rows.Count >0)
            {
                string a = dt.Rows[0]["Maximo"].ToString();
                retorno = Convert.ToInt64(a) + 1;
            }

            dr.Close();
            dr.Dispose();

            return retorno;

        }

        public List<PatrimonioDto> Obter(long? id)
        {
            {
                //string commando = "SELECT * FROM marca WHERE ((marcaid = @p_id)or(@p_id is null));";
                string commando = "SELECT * FROM patrimonio WHERE NTombo = @p_id";
                List<PatrimonioDto> LstPatrimonio = new List<PatrimonioDto>();
                SQLiteCommand cmd = new SQLiteCommand();

                var parameters = new SQLiteParameter[]
                {
                  new SQLiteParameter("@p_id", DbType.Int64){ Value = id, Direction = ParameterDirection.Input}
                };

                var dr = OpenQuery(commando, CommandType.Text, parameters);

                while (dr.Read())
                {
                    LstPatrimonio.Add(
                            new PatrimonioDto()
                            {
                                MarcaID = Convert.ToInt64(dr["marcaid"].ToString()),
                                Nome = dr["nome"].ToString(),
                                Descricao = dr["descricao"].ToString(),
                                NTombo = Convert.ToInt64(dr["ntombo"].ToString())

                            }
                    );
                }

                dr.Close();
                dr.Dispose();

                return LstPatrimonio;
            }
        }

        public List<PatrimonioDto> Lista()
        {
            {
                //string commando = "SELECT * FROM marca WHERE ((marcaid = @p_id)or(@p_id is null));";
                string commando = "SELECT * FROM patrimonio";
                List<PatrimonioDto> LstPatrimonio = new List<PatrimonioDto>();
                SQLiteCommand cmd = new SQLiteCommand();

                var dr = OpenQuery(commando, CommandType.Text);

                while (dr.Read())
                {
                    LstPatrimonio.Add(
                            new PatrimonioDto()
                            {
                                MarcaID = Convert.ToInt64(dr["marcaid"].ToString()),
                                Nome = dr["nome"].ToString(),
                                Descricao = dr["descricao"].ToString(),
                                NTombo = Convert.ToInt64(dr["ntombo"].ToString())
                            }
                    );
                }

                dr.Close();
                dr.Dispose();

                return LstPatrimonio;
            }
        }

        public RetornoDto Update(long? id, string nome, string descricao, long? marcaid)
        {
            string commando = string.Format("Update patrimonio set nome = '{0}', descricao = '{3}', marcaid = {2} where ntombo = {1}", nome, id, marcaid, descricao);
            return ExecutaQuery(commando);
        }

        public RetornoDto Delete(long? id)
        {
            string commando = string.Format("Delete from patrimonio where ntombo = {0}", id);
            return ExecutaQuery(commando);
        }

    }


}

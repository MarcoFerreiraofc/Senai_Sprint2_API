using senai.inlock.webAPI.Domains;
using senai.inlock.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-HMTUR0P; initial catalog=inlock_games_tarde; user Id=SA; pwd=Soufoda2";

        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySearchById = "SELECT idTipoUsuario, permissao FROM tipoUsuarios WHERE tipoUsuarios.idTipoUsuario = @id";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySearchById, connection))
                {
                    // passa o valor para o parâmetro @id
                    command.Parameters.AddWithValue("@id", id);

                    // executa a query e armazena os dados na "reader"
                    reader = command.ExecuteReader();

                    // verifica se o resultado da query retornou algum registro
                    if (reader.Read())
                    {
                        // se sim, será instanciado um novo objeto "funcionarioBuscado" do tipo FuncionarioDomain
                        TipoUsuarioDomain tipoUsuarioBuscado = new TipoUsuarioDomain
                        {
                            // atribui a propriedade "idFuncionario" o valor da coluna "idFuncionario" da tabela do banco de dados, assim, a ordem não vai mais importar
                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                            // atribui a propriedade "nome" o valor da coluna "Nome" da tabela do banco de dados
                            permissao = reader["permissao"].ToString()
                        };

                        // retorna os "funcionarioBuscado" com os dados obtidos
                        return tipoUsuarioBuscado;
                    }
                    // se não, retorna null
                    else
                        return null;
                }
            }
        }


        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> listaTipoUsuario = new List<TipoUsuarioDomain>();

            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idTipoUsuario, permissao FROM tipoUsuarios";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySelectAll, connection))
                {
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                            permissao = reader["permissao"].ToString()
                        };

                        listaTipoUsuario.Add(tipoUsuario);
                    }
                }
            }
            return listaTipoUsuario;
        }


    }
}

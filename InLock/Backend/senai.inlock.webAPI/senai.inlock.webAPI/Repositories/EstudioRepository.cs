using senai.inlock.webAPI.Domains;
using senai.inlock.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-HMTUR0P; initial catalog=inlock_games_tarde; user Id=SA; pwd=Soufoda2";

        public void Atualizar(int id, EstudioDomain estudioAtualizado)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                // declara a query a ser executada
                string queryUpdateIdUrl = "UPDATE estudios SET nomeEstudio = @nomeEstudio WHERE idEstudio = @id";

                using (SqlCommand command = new SqlCommand(queryUpdateIdUrl, connection))
                {
                    // passa os valores para os parâmetros
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nomeEstudio", estudioAtualizado.nomeEstudio);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public EstudioDomain BuscarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySearchById = "SELECT idEstudio, nomeEstudio FROM estudios WHERE estudios.idEstudio = @id";

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
                        EstudioDomain estudioBuscado = new EstudioDomain
                        {
                            // atribui a propriedade "idFuncionario" o valor da coluna "idFuncionario" da tabela do banco de dados, assim, a ordem não vai mais importar
                            idEstudio = Convert.ToInt32(reader["idEstudio"]),

                            // atribui a propriedade "nome" o valor da coluna "Nome" da tabela do banco de dados
                            nomeEstudio = reader["nomeEstudio"].ToString(),
                        };

                        // retorna os "funcionarioBuscado" com os dados obtidos
                        return estudioBuscado;
                    }
                    // se não, retorna null
                    else
                        return null;
                }
            }
        }

        public EstudioDomain BuscarPorNome(string nomeEstudio)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySearchByName = "SELECT idEstudio, nomeEstudio FROM estudios WHERE nomeEstudio = @nomeEstudio";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySearchByName, connection))
                {
                    command.Parameters.AddWithValue("@nomeEstudio", nomeEstudio);

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        EstudioDomain estudioBuscado = new EstudioDomain
                        {
                            idEstudio = Convert.ToInt32(reader["idEstudio"]),

                            nomeEstudio = reader["nomeEstudio"].ToString()
                        };
                        return estudioBuscado;
                    }
                    else
                        return null;
                }
            }
        }

        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO estudios(nomeEstudio) VALUES (@nomeEstudio)";

                using (SqlCommand command = new SqlCommand(queryInsert, connection))
                {
                    // passa o valor de novoFuncionario para os parâmetros(@)
                    command.Parameters.AddWithValue("@nomeEstudio", novoEstudio.nomeEstudio);

                    // abre a conexão com o banco de dados
                    connection.Open();

                    // executa a query
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                // declara a query a ser executada passando o parâmetro @id
                string queryDelete = "DELETE estudios WHERE estudios.idEstudio = @id";

                // declara o SqlCommand "command" passando a query que será executada e a conexão como parâmetros
                using (SqlCommand command = new SqlCommand(queryDelete, connection))
                {
                    // define o valor id recebido no método como valor do parâmetro @id || usamos esse parâmetro para não cairmos no "efeito Joana D'Arc"
                    command.Parameters.AddWithValue("@id", id);

                    // abre a conexão com o banco de dados
                    connection.Open();

                    // executa o comando
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> Listar()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idEstudio, nomeEstudio FROM estudios";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySelectAll, connection)){
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(reader["idEstudio"]),

                            nomeEstudio = reader["nomeEstudio"].ToString()
                        };

                        listaEstudios.Add(estudio);
                    }
                }
            }
            return listaEstudios;
        }

    }
}

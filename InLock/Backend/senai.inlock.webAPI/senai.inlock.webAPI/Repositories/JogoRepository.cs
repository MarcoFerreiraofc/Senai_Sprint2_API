using senai.inlock.webAPI.Domains;
using senai.inlock.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=DESKTOP-HMTUR0P; initial catalog=inlock_games_tarde; user Id=SA; pwd=Soufoda2";


        public void Atualizar(int id, JogoDomain jogoAtualizado)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                // declara a query a ser executada
                string queryUpdateIdUrl = "UPDATE jogos SET jogos.nomeJogo = @nomeJogo, jogos.descricao = @descricao, jogos.dataLancamento = @dataLancamento, jogos.valor = @valor, jogos.idEstudio = @idEstudio WHERE idJogo = @id";

                using (SqlCommand command = new SqlCommand(queryUpdateIdUrl, connection))
                {
                    // passa os valores para os parâmetros
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nomeJogo", jogoAtualizado.nomeJogo);
                    command.Parameters.AddWithValue("@descricao", jogoAtualizado.descricao);
                    command.Parameters.AddWithValue("@dataLancamento", jogoAtualizado.dataLancamento);
                    command.Parameters.AddWithValue("@valor", jogoAtualizado.valor);
                    command.Parameters.AddWithValue("@idEstudio", jogoAtualizado.idEstudio);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySearchById = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, jogos.idEstudio, estudios.nomeEstudio FROM jogos INNER JOIN estudios ON jogos.idEstudio = estudios.idEstudio WHERE jogos.idJogo = @id";

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
                        JogoDomain jogoBuscado = new JogoDomain
                        {
                            // atribui a propriedade "idFuncionario" o valor da coluna "idFuncionario" da tabela do banco de dados, assim, a ordem não vai mais importar
                            idJogo = Convert.ToInt32(reader["idJogo"]),

                            nomeJogo = reader["nomeJogo"].ToString(),

                            descricao = reader["descricao"].ToString(),

                            dataLancamento = Convert.ToDateTime(reader["dataLancamento"]),

                            valor = Convert.ToDouble(reader["valor"]),

                            idEstudio = Convert.ToInt32(reader["idEstudio"]),

                            estudio = new EstudioDomain
                            {
                                idEstudio = Convert.ToInt32(reader["idEstudio"]),

                                nomeEstudio = reader["nomeEstudio"].ToString()
                            }
                        };

                        // retorna os "funcionarioBuscado" com os dados obtidos
                        return jogoBuscado;
                    }
                    // se não, retorna null
                    else
                        return null;
                }
            }
        }

        public JogoDomain BuscarPorNome(string nome)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySearchByName = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, jogos.idEstudio, estudios.nomeEstudio FROM jogos INNER JOIN estudios ON jogos.idEstudio = estudios.idEstudio WHERE nomeJogo = @nomeJogo";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySearchByName, connection))
                {
                    command.Parameters.AddWithValue("@nomeJogo", nome);

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain
                        {
                            idJogo = Convert.ToInt32(reader["idJogo"]),

                            nomeJogo = reader["nomeJogo"].ToString(),

                            descricao = reader["descricao"].ToString(),

                            dataLancamento = Convert.ToDateTime(reader["dataLancamento"]),

                            valor = Convert.ToDouble(reader["valor"]),

                            idEstudio = Convert.ToInt32(reader["idEstudio"]),

                            estudio = new EstudioDomain
                            {
                                idEstudio = Convert.ToInt32(reader["idEstudio"]),

                                nomeEstudio = reader["nomeEstudio"].ToString()
                            }
                        };
                        return jogoBuscado;
                    }
                    else
                        return null;
                }
            }
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO jogos(nomeJogo, descricao, dataLancamento, valor, idEstudio) VALUES (@nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio)";

                using (SqlCommand command = new SqlCommand(queryInsert, connection))
                {
                    // passa o valor de novoFuncionario para os parâmetros(@)
                    command.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    command.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    command.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    command.Parameters.AddWithValue("@valor", novoJogo.valor);
                    command.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);

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
                string queryDelete = "DELETE jogos WHERE jogos.idJogo = @id";

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

        public List<JogoDomain> Listar()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, jogos.idEstudio, estudios.nomeEstudio FROM jogos INNER JOIN estudios ON jogos.idEstudio = estudios.idEstudio";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySelectAll, connection))
                {
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(reader["idJogo"]),

                            nomeJogo = reader["nomeJogo"].ToString(),

                            descricao = reader["descricao"].ToString(),

                            dataLancamento = Convert.ToDateTime(reader["dataLancamento"]),

                            valor = Convert.ToDouble(reader["valor"]),

                            idEstudio = Convert.ToInt32(reader["idEstudio"]),

                            estudio = new EstudioDomain
                            {
                                idEstudio = Convert.ToInt32(reader["idEstudio"]),

                                nomeEstudio = reader["nomeEstudio"].ToString()
                            }
                        };

                        listaJogos.Add(jogo);
                    }
                }
            }
            return listaJogos;
        }
    }
}

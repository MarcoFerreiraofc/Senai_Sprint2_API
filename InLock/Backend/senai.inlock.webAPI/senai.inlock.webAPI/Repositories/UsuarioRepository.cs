using senai.inlock.webAPI.Domains;
using senai.inlock.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-HMTUR0P; initial catalog=inlock_games_tarde; user Id=SA; pwd=Soufoda2";

        public void Atualizar(int id, UsuarioDomain usuarioAtualizado)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                // declara a query a ser executada
                string queryUpdateIdUrl = "UPDATE usuarios SET email = @email, senha = @senha, idTipoUsuario = @idTipoUsuario WHERE idUsuario = @id";

                using (SqlCommand command = new SqlCommand(queryUpdateIdUrl, connection))
                {
                    // passa os valores para os parâmetros
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@email", usuarioAtualizado.email);
                    command.Parameters.AddWithValue("@senha", usuarioAtualizado.senha);
                    command.Parameters.AddWithValue("@idTipoUsuario", usuarioAtualizado.idTipoUsuario);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain BuscarEmailSenha(string email, string senha)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string queryLogin = "SELECT idUsuario, email, senha, usuarios.idTipoUsuario, tipoUsuarios.permissao FROM usuarios INNER JOIN tipoUsuarios ON usuarios.idTipoUsuario = tipoUsuarios.idTipoUsuario WHERE usuarios.email = @email AND senha = @senha";
                
                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(queryLogin, connection))
                {
                    // passa o valor para o parâmetro @id
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@senha", senha);

                    // executa a query e armazena os dados na "reader"
                    reader = command.ExecuteReader();

                    // verifica se o resultado da query retornou algum registro
                    if (reader.Read())
                    {
                        // se sim, será instanciado um novo objeto "funcionarioBuscado" do tipo FuncionarioDomain
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            // atribui a propriedade "idFuncionario" o valor da coluna "idFuncionario" da tabela do banco de dados, assim, a ordem não vai mais importar
                            idUsuario = Convert.ToInt32(reader["idUsuario"]),

                            email = reader["email"].ToString(),

                            senha = reader["senha"].ToString(),

                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                            tipoUsuario = new TipoUsuarioDomain
                            {
                                idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                                permissao = reader["permissao"].ToString()
                            }
                        };

                        // retorna os "funcionarioBuscado" com os dados obtidos
                        return usuarioBuscado;
                    }
                    // se não, retorna null
                    else
                        return null;
                }
            }
        }

        public UsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySearchById = "SELECT idUsuario, email, senha, usuarios.idTipoUsuario, tipoUsuarios.permissao FROM usuarios INNER JOIN tipoUsuarios ON usuarios.idTipoUsuario = tipoUsuarios.idTipoUsuario WHERE usuarios.idUsuario = @id";

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
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            // atribui a propriedade "idFuncionario" o valor da coluna "idFuncionario" da tabela do banco de dados, assim, a ordem não vai mais importar
                            idUsuario = Convert.ToInt32(reader["idUsuario"]),

                            email = reader["email"].ToString(),

                            senha = reader["senha"].ToString(),

                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                            tipoUsuario = new TipoUsuarioDomain
                            {
                                idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                                permissao = reader["permissao"].ToString()
                            }
                        };

                        // retorna os "funcionarioBuscado" com os dados obtidos
                        return usuarioBuscado;
                    }
                    // se não, retorna null
                    else
                        return null;
                }
            }
        }


        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO usuarios(email, senha, idTipoUsuario) VALUES (@email, @senha, @idTipoUsuario)";

                using (SqlCommand command = new SqlCommand(queryInsert, connection))
                {
                    // passa o valor de novoFuncionario para os parâmetros(@)
                    command.Parameters.AddWithValue("@email", novoUsuario.email);
                    command.Parameters.AddWithValue("@senha", novoUsuario.senha);
                    command.Parameters.AddWithValue("@idTipoUsuario", novoUsuario.idTipoUsuario);

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
                string queryDelete = "DELETE usuarios WHERE usuarios.idUsuario = @id";

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

        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> listaUsuario = new List<UsuarioDomain>();

            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idUsuario, email, senha, usuarios.idTipoUsuario, tipoUsuarios.permissao FROM usuarios INNER JOIN tipoUsuarios ON usuarios.idTipoUsuario = tipoUsuarios.idTipoUsuario";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySelectAll, connection))
                {
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(reader["idUsuario"]),

                            email = reader["email"].ToString(),

                            senha = reader["senha"].ToString(),

                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                            tipoUsuario = new TipoUsuarioDomain
                            {
                                idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                                permissao = reader["permissao"].ToString()
                            }
                        };

                        listaUsuario.Add(usuario);
                    }
                }
            }
            return listaUsuario;
        }

        public string RoleString(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string queryPermissao = "SELECT permissao FROM tipoUsuarios WHERE idTipoUsuario = @id";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(queryPermissao, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string permissao = reader["permissao"].ToString();

                        return permissao;
                    }
                }
            }
            return null;
        }

    }
}

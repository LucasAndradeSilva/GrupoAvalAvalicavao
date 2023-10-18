using Dapper;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace GrupoAval.Data.Database
{
    public class DatabaseRepository : IDatabaseIntaface
    {
        private SqlConnection _sqlConnection;
        private IConfiguration _configuration;    
        public DatabaseRepository(IConfiguration configuration)
        {
			_configuration = configuration;
			_sqlConnection = new SqlConnection(_configuration["ConnectionStrings:Default"]);
        }

        private void BuildConnection()
        {
			_sqlConnection = new SqlConnection(_configuration["ConnectionStrings:Default"]);            
		}


		private SqlConnection GetConnection()
        {
            BuildConnection();

			_sqlConnection.Open();

            return _sqlConnection;
        }
        public async Task<IEnumerable<T>> QueryMultipleAsync<T>(string sql, object @params = null)
        {
            var connection = GetConnection();
            try
            {
                var result = await connection.QueryAsync<T>(sql, @params, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                await connection.CloseAsync();
                await connection.DisposeAsync();
            }

            return default;
        }
        public async Task<T> QueryFirstAsync<T>(string sql, object @params = null)
        {
            var connection = GetConnection();
            try
            {
                var result = await connection.QueryFirstAsync<T>(sql, @params, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                await connection.CloseAsync();
                await connection.DisposeAsync();
            }

            return default;
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, Func<SqlMapper.GridReader, List<T>> map, object parameters = null)
        {
            var connection = GetConnection();
            try
            {
                var gridReader = connection.QueryMultiple(sql, parameters);
                return map(gridReader);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                await connection.CloseAsync();
                await connection.DisposeAsync();
            }

            return default;          
        }
        public SqlCommand GetCommand(string command, object parameters, SqlConnection connection)
        {
            var resul = new SqlCommand(command.Trim(), connection);
            if (parameters != null)
            {
                foreach (var prop in parameters.GetType().GetProperties())
                {
                    resul.Parameters.AddWithValue(prop.Name, prop.GetValue(parameters));
                }
                resul.CommandType = CommandType.StoredProcedure;
            }
            return resul;
        }

        public async Task QueryFirstAsync(string sql, object @params = null)
        {
            var connection = GetConnection();
            try
            {
                await connection.QueryFirstAsync(sql, @params, commandType: CommandType.StoredProcedure);                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                await connection.CloseAsync();
                await connection.DisposeAsync();
            }            
        }
    }
}

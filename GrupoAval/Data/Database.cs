using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace GrupoAval.Data
{
	public class Database
	{
		private SqlConnection _sqlConnection;
		public Database(IConfiguration configuration)
		{
			_sqlConnection = new SqlConnection(configuration["ConnectionStrings:Default"]);
		}
	
		private SqlConnection GetConnection()
		{
			_sqlConnection.Open();

			return _sqlConnection;
		}
		public async Task<IEnumerable<T>> QueryMultipleAsync<T>(string sql, object @params = null)
		{
			var connection = GetConnection();
			try
			{
				var result = await connection.QueryAsync<T>(sql, @params, commandType: System.Data.CommandType.StoredProcedure);
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

		public SqlCommand GetCommand(string command, object parameters, SqlConnection connection)
		{
			var resul = new SqlCommand(command.Trim(), connection);
			if (parameters != null)
			{
				foreach (var prop in parameters.GetType().GetProperties())
				{
					resul.Parameters.AddWithValue(prop.Name, prop.GetValue(parameters));
				}
				resul.CommandType = System.Data.CommandType.StoredProcedure;
			}
			return resul;
		}
	}
}

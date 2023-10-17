using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace GrupoAval.Data.Database
{
	public interface IDatabaseIntaface
	{
		Task<IEnumerable<T>> QueryMultipleAsync<T>(string sql, object @params = null);
		Task<T> QueryFirstAsync<T>(string sql, object @params = null);
        Task QueryFirstAsync(string sql, object @params = null);
        SqlCommand GetCommand(string command, object parameters, SqlConnection connection);     
	}
}

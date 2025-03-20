
using System.Data;
using Dapper;
using ChecklistAPI.Domain;
using Npgsql;

namespace ChecklistAPI.Data;

public class ItemRepository(IConfiguration configuration)
{
	private readonly NpgsqlConnection _connection = new(configuration.GetConnectionString("DefaultConnection"));
	private readonly string _tableName = "item";

	public async Task<IEnumerable<ListItem>> GetAllAsync()
	{
		var query = $"SELECT * FROM {_tableName}";
		return await _connection.QueryAsync<ListItem>(query);
	}

	public async Task<ListItem> GetByIdAsync(int id)
	{
		var query = $"SELECT * FROM {_tableName} WHERE Id = @Id";
		var res = await _connection.QueryFirstOrDefaultAsync<ListItem>(query, new { Id = id })
			?? throw new KeyNotFoundException($"Item with id {id} not found");
		return res;
	}

	// public async Task<int> CreateAsync(ListItem item)
	// {
	// 	var query = $"INSERT INTO {_tableName} (Name, Notes, quantity, category, user_id) VALUES (@Name, @Description); SELECT CAST(SCOPE_IDENTITY() as int)";
	// 	return await _connection.ExecuteScalarAsync<int>(query, item);
	// }

	// public async Task<bool> UpdateAsync(ListItem checklist)
	// {
	// 	const string query = "UPDATE item SET Name = @Name, Description = @Description WHERE Id = @Id";
	// 	var rowsAffected = await _dbConnection.ExecuteAsync(query, checklist);
	// 	return rowsAffected > 0;
	// }

	// public async Task<bool> DeleteAsync(int id)
	// {
	// 	const string query = "DELETE FROM item WHERE Id = @Id";
	// 	var rowsAffected = await _dbConnection.ExecuteAsync(query, new { Id = id });
	// 	return rowsAffected > 0;
	// }
}

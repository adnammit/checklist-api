
using Dapper;
using ChecklistAPI.Domain;
using Npgsql;

namespace ChecklistAPI.Data;

public class ItemRepository(IConfiguration configuration)
{
	private readonly NpgsqlConnection _connection = new(configuration.GetConnectionString("DefaultConnection"));
	private readonly string _tableName = "item";

	public async Task<IEnumerable<ListItem>> GetAll()
	{
		var query = $"SELECT * FROM {_tableName}";
		return await _connection.QueryAsync<ListItem>(query);
	}

	public async Task<ListItem> Create(ListItem item)
	{
		var query = $"INSERT INTO {_tableName} (Name, Notes, quantity, category, list_id) VALUES (@Name, @Notes, @Quantity, @Category, @ListId) RETURNING Id";
		item.Id = await _connection.ExecuteScalarAsync<int>(query, item);
		return item;
	}

	public async Task<ListItem> GetById(int id)
	{
		var query = $"SELECT * FROM {_tableName} WHERE Id = @Id";
		var res = await _connection.QueryFirstOrDefaultAsync<ListItem>(query, new { Id = id })
			?? throw new KeyNotFoundException($"Item with id {id} not found");
		return res;
	}

	public async Task<bool> Update(ListItem item)
	{
		// TODO update modified_date OR better yet, make it a function
		var query = $"UPDATE {_tableName} SET Name = @Name, notes = @Notes, quantity = @Quantity, category = @Category, completed = @Completed, active = @Active WHERE Id = @Id";
		var rowsAffected = await _connection.ExecuteAsync(query, item);
		return rowsAffected > 0;
	}

	public async Task<bool> SetActive(int id, bool isActive) // replace with Update
	{
		var query = $"UPDATE {_tableName} SET active = @isActive WHERE Id = @Id";
		var rowsAffected = await _connection.ExecuteAsync(query, new { Id = id, isActive });
		return rowsAffected > 0;
	}

	public async Task<bool> Delete(int id)
	{
		var query = $"DELETE FROM {_tableName} WHERE Id = @Id";
		var rowsAffected = await _connection.ExecuteAsync(query, new { Id = id });
		return rowsAffected > 0;
	}

	// public async Task<int> CreateAsync(ListItem item)
	// {
	// 	var query = $"INSERT INTO {_tableName} (Name, Notes, quantity, category, user_id) VALUES (@Name, @Description); SELECT CAST(SCOPE_IDENTITY() as int)";
	// 	return await _connection.ExecuteScalarAsync<int>(query, item);
	// }



	// public async Task<bool> DeleteAsync(int id)
	// {
	// 	const string query = "DELETE FROM item WHERE Id = @Id";
	// 	var rowsAffected = await _dbConnection.ExecuteAsync(query, new { Id = id });
	// 	return rowsAffected > 0;
	// }
}

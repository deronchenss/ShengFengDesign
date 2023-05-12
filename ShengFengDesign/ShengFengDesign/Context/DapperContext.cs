using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ShengFengDesign.Context;

public class DapperContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
        string dbUser = Environment.GetEnvironmentVariable("DB_USER");
        string dbPass = Environment.GetEnvironmentVariable("DB_PASS");
        string dbName = Environment.GetEnvironmentVariable("DB_NAME");
        string dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
        _connectionString = $"Server={dbServer};Database={dbName};User Id={dbUser};Password={dbPass}";
        //_connectionString = _configuration.GetConnectionString("ConnectionString");
    }

    private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    public string sql = string.Empty;

    public DynamicParameters parameter = new();

    public async Task<T> GetQueryData<T>(Object obj = null)
    {
        using var connection = CreateConnection();
        connection.Open();
        var data = await connection.QueryAsync<T>(sql, obj ?? parameter);

        return data.FirstOrDefault();
    }

    public async Task<List<T>> GetQueryListData<T>(Object obj = null)
    {
        using var connection = CreateConnection();
        connection.Open();
        var data = await connection.QueryAsync<T>(sql, obj ?? parameter);

        return data.ToList();
    }

    public async Task<int> ExecuteSql(Object obj = null)
    {
        using var connection = CreateConnection();
        connection.Open();
        return await connection.ExecuteAsync(sql, obj ?? parameter);
    }
}
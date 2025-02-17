using Dapper;
using saurav.Controllers;
using Npgsql;
using saurav.Entities;

namespace saurav.Services;

public class StudentServices
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public StudentServices(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = configuration.GetConnectionString("Default")!;
    }

    public async Task CreateAsync(StudentDto studentDto)
    {
        const string insertQuery = $"""
                                    insert into members (firstname,lastname, email, phonenumber, address)
                                    values(@firstname,@lastname, @email, @phonenumber, @address) 
                                    """;

        await using var connection = new NpgsqlConnection(_connectionString);

        await connection.ExecuteAsync(insertQuery, new
        {
            firstname = studentDto.FirstName,  
            lastname = studentDto.LastName,
            email = studentDto.Email,
            phonenumber = studentDto.Phone,
            address = studentDto.Address
        });
    }

    public async Task DeleteAsync(int id)
    {
        const string deleteQuery = $"""
                                    delete from members where id = @id
                                    """;

        var connectionString = _configuration.GetConnectionString("Default");

        await using var connection = new NpgsqlConnection(connectionString);

        await connection.ExecuteAsync(deleteQuery, new
        {
            id = id
        });
    }
}
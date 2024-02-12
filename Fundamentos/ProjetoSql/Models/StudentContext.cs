using Microsoft.EntityFrameworkCore;


namespace ProjetoSql.Models;
public class StudentContext : DbContext
{
    // Criar um construtor que envia as configurações de inicialização
    // para o construtor da classe pai DbContext
    public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

    public StudentContext() { }

    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        var connectionString = "Server=127.0.0.1;Database=trybe_db;User ID=sa;Password=Nj0q4$Fr1fa7@9aksedQUOp";
        // Verificamos se o banco de dados já foi configurado
        //var connectionString = Environment.GetEnvironmentVariable("DOTNET_CONNECTION_STRING");
        optionsBuilder.UseSqlServer(connectionString);

    }
}

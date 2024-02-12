using Microsoft.EntityFrameworkCore;

namespace ApiSql.Data;

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=trybe_db;User ID=sa;Password=Nj0q4$Fr1fa7@9aksedQUOp");
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiSql.Models;

public class Author
{
    [Key]
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public string Email { get;set; }

    [InverseProperty("Author")]
    [JsonIgnore]
    public ICollection<Book> Books { get; set; }
}

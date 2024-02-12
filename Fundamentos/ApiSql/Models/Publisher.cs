using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiSql.Models;

public class Publisher
{
    [Key]
    public int PublisherId { get; set; }
    public string Name { get; set; }

    [InverseProperty("Publisher")]
    [JsonIgnore]
    public ICollection<Book> Books { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiSql.Models;

public class Book
{
    [Key]
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }
    public int Pages { get; set; }

    public int? AuthorId { get; set; }
    [ForeignKey("AuthorId")]
    [JsonIgnore]
    public Author? Author { get; set; }

    public int? PublisherId { get; set; }

    [ForeignKey("PublisherId")]
    [JsonIgnore]
    public Publisher? Publisher { get; set; }
}

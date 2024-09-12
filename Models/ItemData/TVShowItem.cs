using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("TVShows")]
public class TVShowItem : IExternalItem
{
    [Key]
    public int ID { get; set; }
    public string ExternalID { get; set; }
}

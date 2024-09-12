using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Comics")]
public class ComicItem : IExternalItem
{
    [Key]
    public int ID { get; set; }
    public string ExternalID { get; set; }
    public bool _1001 { get; set; }
}

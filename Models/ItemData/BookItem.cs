using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Books")]
public class BookItem : IExternalItem
{
    [Key]
    public int ID { get; set; }
    public string ExternalID { get; set; }
    public bool is1001 { get; set; }
}

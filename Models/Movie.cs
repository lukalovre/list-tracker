using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Movies")]
public class Movie : IItem
{
    [Key]
    public int ID { get; set; }
    public string Director { get; set; }
    public string Title { get; set; }
    public int? Year { get; set; }
    public int? NumVotes { get; set; }
    public int? Runtime { get; set; }
    public string ExternalID { get; set; }
    public DateTime? Date { get; set; }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Movies")]
public class Movie : IItem
{
    public string Director { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int? Year { get; set; }
    public int? NumVotes { get; set; }
    public int? Runtime { get; set; }
    public string ExternalID { get; set; } = null!;
    public DateTime? Date { get; set; }

    public string URL { get; set; } = null!;
}

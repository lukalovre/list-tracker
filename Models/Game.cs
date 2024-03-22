using System;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Games")]
public class Game : IItem
{
    public string category { get; set; }
    public string companies { get; set; }
    public string description { get; set; }
    public string game { get; set; }
    public string genres { get; set; }
    public int id { get; set; }
    public string platforms { get; set; }
    public string rating { get; set; }
    public string release_date { get; set; }
    public string themes { get; set; }
    public string url { get; set; }
    public int ID { get; set; }
    public string ExternalID { get; set; }
    public DateTime? Date { get; set; }
}

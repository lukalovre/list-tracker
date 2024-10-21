using System;

public interface IItem
{
    public string ExternalID { get; set; }
    public DateTime? Date { get; set; }
    public string URL { get; set; }
}
public class Fighter
{
    public string Name { get; set; }
    public string Logo { get; set; }
    public bool Winner { get; set; }
}

public class Fight
{
    public int Id { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public string Slug { get; set; }
    public bool IsMain { get; set; }
    public string Category { get; set; }
    public string Status { get; set; }
    public Fighter FirstFighter { get; set; }
    public Fighter SecondFighter { get; set; }
    public string WinnerName => FirstFighter.Winner ? FirstFighter.Name : SecondFighter.Name;
}

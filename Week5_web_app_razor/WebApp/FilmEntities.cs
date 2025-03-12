namespace FilmEntities;

public class Film
{
    public int FilmID { get; set; }
    public string? Title { get; set; } = string.Empty;
    public int Year { get; set; }
    public int ActorID { get; set; }
}

public class Actor
{
    public int ActorID { get; set; }
    public string? Firstname { get; set; } = string.Empty;
    public string? Lastname { get; set; } = string.Empty;
}

public class FilmActor
{
    public int FilmID { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public int ActorID { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
}

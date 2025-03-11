namespace FilmEntities;

public class Film
{
    public Int32 FilmID { get; set; }
    public String Title { get; set; }
    public Int32 Year { get; set; }

    public Int32 ActorID { get; set; }
}

public class Actor
{
    public Int32 ActorID { get; set; }
    public String Firstname { get; set; }
    public String Lastname { get; set; }
}

public class FilmActor
{
    public Int32 FilmID { get; set; }
    public String Title { get; set; }
    public Int32 Year { get; set; }
    public Int32 ActorID { get; set; }
    public String Firstname { get; set; }
    public String Lastname { get; set; }
}

namespace RevvyTask.Entity;

public class Note
{
    public int Index { get; set; }
    public List<Note> Requirements { get; set; }
}
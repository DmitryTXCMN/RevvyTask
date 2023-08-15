using RevvyTask.Entity;

namespace RevvyTask.DomainService;

/*Эмитация обращения к доменке*/
public static class NoteDomainService
{
    private static List<Note> notes = new List<Note>();
    public static List<Note> GetAll()
    {
        return notes;
    }

    public static void SetAll(List<Note> inputNotes)
    {
        notes.Clear();
        notes.AddRange(inputNotes);
    }
}

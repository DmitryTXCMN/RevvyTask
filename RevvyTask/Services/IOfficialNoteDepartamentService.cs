using RevvyTask.Entity;

namespace RevvyTask.Services;

/// <summary>
/// Отдел выдачи справок у чиновника
/// </summary>
public interface IOfficialNoteDepartamentService
{
    public bool IsNoteGetable(Note note, List<Note> alreadyGeted);
}

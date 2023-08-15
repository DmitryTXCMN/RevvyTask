using Castle.MicroKernel.Registration;
using RevvyTask.DomainService;
using RevvyTask.Entity;
using System.Diagnostics.Metrics;

namespace RevvyTask.Services;

/// <summary>
/// Отдел выдачи справок у чиновника
/// </summary>
public class OfficialNoteDepartamentService : IOfficialNoteDepartamentService
{
    public bool IsNoteGetable(Note note, List<Note> alreadyGeted)
    {
        if (note == null)
        {
            return false;
        }

        return !note.Requirements.Except(alreadyGeted).Any();
    }
}

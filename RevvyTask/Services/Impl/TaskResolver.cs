using RevvyTask.DomainService;
using RevvyTask.Entity;
using System.Text;

namespace RevvyTask.Services;

/// <summary>
/// Отдел выдачи справок у чиновника
/// </summary>
public class TaskResolver : ITaskResolver
{
    /* O(n^2) текущим алгоритм */
    public string Resolve()
    {
        var result = new StringBuilder();

        var noteDep = CastleControllerFactory.Container.Resolve<IOfficialNoteDepartamentService>();

        var geted = new List<Note>();
        var notes = NoteDomainService.GetAll();

        while (notes.Count > 0)
        {
            var getedIter = notes.Where(note => noteDep.IsNoteGetable(note,geted))
                .ToList();

            if (!getedIter.Any())
            {
                throw new Exception("Невозможно собрать все справки :(");
            }

            getedIter.ForEach(x =>
                {
                    geted.Add(x);
                    notes.Remove(x);
                    result.Append(x.Index);
                });
        }

        CastleControllerFactory.Container.Release(noteDep);

        return result.ToString();
    }
}

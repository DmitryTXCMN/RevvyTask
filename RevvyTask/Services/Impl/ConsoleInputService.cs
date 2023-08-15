using RevvyTask.DomainService;
using RevvyTask.Entity;
using System.Text;
using System.Text.RegularExpressions;

namespace RevvyTask.Services;

/// <summary>
/// Отдел выдачи справок у чиновника
/// </summary>
public class ConsoleInputService : IConsoleInputService
{
    private readonly string _regexParserPattern = "{(\\d+),\\[([\\d,]+)\\]\\}";
    private readonly string _preInputText = "Введите данные: ";

    public bool Input()
    {
        Console.WriteLine(_preInputText);
        var input = Console.ReadLine();

        if (input == null || input == "")
        {
            return false;
        }

        var noteDirty = new List<Note>();

        var regex = new Regex(_regexParserPattern);
        var matches = regex.Matches(input.Replace(" ", ""));
        foreach (Match match in matches)
        {
            if (match.Success)
            {
                // Индекс справки
                var index = Convert.ToInt32(match.Groups[1].ToString());
                // Индексы необходимых справок
                var reqs = match.Groups[2]
                    .ToString()
                    .Split(',')
                    .Select(x => Convert.ToInt32(x))
                    .ToList();

                if (!noteDirty.Any(x => x.Index == index))
                {
                    noteDirty.Add(new Note
                    {
                        Index = index,
                        Requirements = new List<Note>()
                    });
                }

                reqs.ForEach(req =>
                {
                    if (!noteDirty.Any(x => x.Index == req))
                    {
                        noteDirty.Add(new Note
                        {
                            Index = req,
                            Requirements = new List<Note>()
                        });
                    }
                });

                var note = noteDirty.First(x => x.Index == index);

                note.Requirements
                    .AddRange(noteDirty
                    .Where(x => reqs.Contains(x.Index)));
            }
        }

        // Пользуюсь правом на хардкод и явно указываю куда вставлять данные)
        NoteDomainService.SetAll(noteDirty);

        return noteDirty.Any();
    }
}

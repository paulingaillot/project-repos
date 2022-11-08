namespace LOCMI.Models.Menu;

using System.Collections;

public sealed class Menu<T> : IEnumerable<T> where T : ICommand
{
    private readonly List<Entry<T>> _entries;

    private string _name;

    private T? _selected;

    public Menu(string name)
    {
        _name = name;
        _entries = new List<Entry<T>>();
    }

    public bool IsClosed { get; } = false;

    public void Add(string text, T command)
    {
        var entry = new Entry<T>(text, command);

        _entries.Add(entry);
    }

    public void Execute(int userChoice)
    {
        if (userChoice < _entries.Count)
        {
            _entries[userChoice].Execute();
            _selected = _entries[userChoice].Command;
        }
        else
        {
            Console.WriteLine("Please enter a valid choice");
        }
    }

    public List<Entry<T>> GetEntries()
    {
        return _entries;
    }

    /// <inheritdoc />
    public IEnumerator<T> GetEnumerator()
    {
        return _entries.Select(static c => c.Command).GetEnumerator();
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
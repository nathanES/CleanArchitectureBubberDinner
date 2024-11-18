using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.Menu.ValueObjects;
using ErrorOr;

namespace BubberDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Name { get; }
    public string Description { get; }

    IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
    //It can be changed by converting it to list. Normally you want to create another list and return it

    public MenuSection(MenuSectionId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }
    public static MenuSection Create(string name, string description)
    {
        return new(MenuSectionId.CreateUnique(), name, description);
    }
}
using ZenSquad.Domain.Common.Interfaces;
using ZenSquad.Domain.Game.ValueObjects;

namespace ZenSquad.Domain.Game;

public class Game : IAggregateRoot
{
    public GameId Id { get; } = null!;

    public string Name { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public Game()
    {
        // For Ef Core
    }

    private Game(string name, string description)
    {
        Id = new GameId(Guid.NewGuid());

        Name = name;
        Description = description;
    }

    public static Game CreateNew(string name, string description)
    {
        return new(name, description);
    }
}
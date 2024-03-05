using ZenSquad.Domain.Common.Models;

namespace ZenSquad.Domain.Game.ValueObjects;

public class GameId : IdValueBase
{
    public GameId(Guid value) : base(value) { }
}
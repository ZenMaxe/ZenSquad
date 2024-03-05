using ZenSquad.Domain.Common.Models;

namespace ZenSquad.Domain.Squads.ValueObjects;

public class SquadId : IdValueBase
{
    public SquadId(Guid value) : base(value) { }
}
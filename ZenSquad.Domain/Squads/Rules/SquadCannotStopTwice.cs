using ZenSquad.Domain.Common.Interfaces;

namespace ZenSquad.Domain.Squads.Rules;

public class SquadCannotStopTwice : IBusinessRule
{
    private readonly bool isStarted;

    internal SquadCannotStopTwice(bool isStarted) { this.isStarted = isStarted; }

    public bool IsOkay()
        => isStarted;

    public string Message => "Squad Cannot Stop Twice";
}
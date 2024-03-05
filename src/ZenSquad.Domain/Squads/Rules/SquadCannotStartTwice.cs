using ZenSquad.Domain.Common.Interfaces;

namespace ZenSquad.Domain.Squads.Rules;

public class SquadCannotStartTwice : IBusinessRule
{

    private readonly bool isStarted;

    internal SquadCannotStartTwice(bool isStarted)
    {
        this.isStarted = isStarted;
    }

    public bool IsOkay() => !isStarted;
    public string Message => "Squad Cannot Start Twice";
}
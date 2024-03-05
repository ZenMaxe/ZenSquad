using ZenSquad.Domain.Common.Interfaces;

namespace ZenSquad.Domain.Squads.Rules;

public class OnlyFinishedSquadCanDeleted : IBusinessRule
{
    private readonly bool _isRunning;

    internal OnlyFinishedSquadCanDeleted(bool isRunning)
    {
        _isRunning = isRunning;
    }


    public bool IsOkay()
        => !_isRunning;
    public string Message => "Only Finished Squad Can Deleted";
}
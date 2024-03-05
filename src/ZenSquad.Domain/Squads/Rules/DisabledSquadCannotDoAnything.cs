using ZenSquad.Domain.Common.Interfaces;

namespace ZenSquad.Domain.Squads.Rules;

public class DisabledSquadCannotDoAnything : IBusinessRule
{
    private readonly bool _isDisabled;
    internal DisabledSquadCannotDoAnything(bool isDisabled) { _isDisabled = isDisabled; }

    public bool IsOkay()
        => !_isDisabled;
    public string Message => "You Cannot Do Any Task on Removed Squad";
}
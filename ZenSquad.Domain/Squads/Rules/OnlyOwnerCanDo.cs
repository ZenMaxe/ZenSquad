using ZenSquad.Domain.Common.Interfaces;

namespace ZenSquad.Domain.Squads.Rules;

internal class OnlyOwnerCanDo : IBusinessRule
{
    private readonly int ownerId;

    // TODO: IMemberContext field here

    internal OnlyOwnerCanDo(int ownerId)
    {
        this.ownerId = ownerId;
    }


    public bool IsOkay()
    {
        return true;
    }
    public string Message => "Only Owner Can Do This";
}
using System.Diagnostics.CodeAnalysis;
using ZenSquad.Domain.Common.Interfaces;
using ZenSquad.Domain.Common.Models;
using ZenSquad.Domain.Game.ValueObjects;
using ZenSquad.Domain.Squads.Rules;
using ZenSquad.Domain.Squads.ValueObjects;

namespace ZenSquad.Domain.Squads;

public class Squad : Entity, IAggregateRoot
{

    public SquadId Id { get; } = null!;

    public GameId GameId { get; } = null!;

    public string Name { get; private set; } = null!;

    public string Description { get; private set; } = "Lobby";

    public DateTime CreatedAt { get; }

    public DateTime? ScheduleAt { get; private set; }

    public DateTime? StartedAt { get; private set; }

    public DateTime? DisabledAt { get; private set; }

    public bool IsDisabled { get; private set; }
    public bool IsStarted { get; private set; }

    public int OwnerId { get; private set; }

    // Todo: Members List


    // Todo: Invited Members List


#region Constructors

    private Squad()
    {
        // For Ef Core
    }

    private Squad(int ownerId,
                  GameId gameId,
                  string name,
                  [MaybeNull] string? description,
                  DateTime? scheduleAt)
    {
        Id = new SquadId(Guid.NewGuid());
        GameId = gameId;
        Name = name;

        if (!string.IsNullOrEmpty(description))
        {
            Description = description;
        }

        OwnerId = ownerId;
        CreatedAt = DateTime.UtcNow;
    }

#endregion


#region Factories

    public static Squad CreateNew(int ownerId,
                                  GameId gameId,
                                  string name,
                                  string? description)
    {
        return new Squad(ownerId, gameId, name, description, null);
    }

    public static Squad CreateNew(int ownerId,
                                  GameId gameId,
                                  string name,
                                  string? description,
                                  DateTime scheduleAt)
    {
        return new Squad(ownerId, gameId, name, description, scheduleAt);
    }

#endregion



    /// <summary>
    /// Starts Squad To Play The Game, When Squad Has Started It WilL Locked
    /// And No One Can Join , Than All Invites Will be Deleted
    /// </summary>
    public void Start()
    {
        this.CheckRule(new DisabledSquadCannotDoAnything(isDisabled: IsDisabled));
        this.CheckRule(new OnlyOwnerCanDo(OwnerId));
        this.CheckRule(new SquadCannotStartTwice(IsStarted));

        this.IsStarted = true;

        //Todo: Remove Invites

        //Todo: Add Event
    }


    /// <summary>
    /// Stop The Squad Status to NotRunning!
    /// At This Status Owner Can Invite Members and Invited Members Can Join
    /// If Squad Is at "Open" They Can Join Freely
    /// </summary>
    public void Stop()
    {
        this.CheckRule(new DisabledSquadCannotDoAnything(isDisabled: IsDisabled));
        this.CheckRule(new OnlyOwnerCanDo(OwnerId));
        this.CheckRule(new SquadCannotStopTwice(IsStarted));


        this.IsStarted = false;

        //Todo: Add Event
    }


    /// <summary>
    /// Deleted Squad.
    /// All Members Will Be Removed!
    /// </summary>
    public void Delete()
    {
        this.CheckRule(new DisabledSquadCannotDoAnything(isDisabled: IsDisabled));
        this.CheckRule(new OnlyOwnerCanDo(OwnerId));

        this.CheckRule(new OnlyFinishedSquadCanDeleted(IsStarted));

        IsDisabled = true;

        //Todo: Add Event and Deletes Member and Remove Invites
    }

    /// <summary>
    /// Leave Squad
    /// </summary>

    // Todo: Provide User Id
    public void Leave()
    {
        // Todo: Add Event And Remove User From Squad, If it's Owner Than We Need Change Owner
    }


    public void InviteMember()
    {

        throw new NotImplementedException();
    }


    public void RemoveMember()
    {
        throw new NotImplementedException();
    }

}
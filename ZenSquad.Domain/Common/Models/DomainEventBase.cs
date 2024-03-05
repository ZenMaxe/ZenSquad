using ZenSquad.Domain.Common.Interfaces;

namespace ZenSquad.Domain.Common.Models;
public class DomainEventBase : IDomainEvent
{
	public Guid Id { get; set; }
	public DateTime DateOccurred { get; set; }
	public bool IsCompleted { get; set; }

    public DomainEventBase()
    {
        Id = Guid.NewGuid();
		DateOccurred = DateTime.UtcNow;
    }
}


namespace ZenSquad.Domain.Common.Interfaces;
public interface IDomainEvent
{
	Guid Id { get; set; }

	DateTime DateOccurred { get; set; }

	bool IsCompleted { get; set; }

}

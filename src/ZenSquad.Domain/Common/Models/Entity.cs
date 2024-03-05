using ZenSquad.Domain.Common.Interfaces;

namespace ZenSquad.Domain.Common.Models;
public class Entity
{
	/// <summary>
	/// Domain Events Occurred
	/// </summary>
	public IReadOnlyCollection<IDomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();


	private List<IDomainEvent> _domainEvents = new();

	/// <summary>
	/// Clear All Domain Events That Occurred in The Entity
	/// </summary>

	public void ClearDomainEvents()
	{
		_domainEvents?.Clear();
	}


	/// <summary>
	/// Add Domain Event To Entity
	/// </summary>
	protected void AddDomainEvent(IDomainEvent domainEvent)
	{
		_domainEvents ??= [];

		this._domainEvents.Add(domainEvent);
	}


	/// <summary>
	/// Check Business Rule
	/// </summary>
	/// <param name="rule">Bussiness Rule That You Need To Check</param>
	/// <exception></exception>
	protected void CheckRule(IBusinessRule rule)
	{
		if (rule.IsOkay())
		{
			//TODO: Exception
			throw new ();
		}
	}

}
namespace ZenSquad.Domain.Common.Interfaces;
public interface IBusinessRule
{

	bool IsOkay();

	string Message { get; }
}
using Microsoft.AspNetCore.Identity;
using ZenSquad.Domain.Users.ValueObjects;

namespace ZenSquad.Domain.Users;

public sealed class User : IdentityUser<UserId>
{

    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;

    #region  Constructors

    private User()
    {
        // For Ef Core
    }

    private User(string firstName,
                 string lastName,
                 string email
                 ) : base()
    {
        Id = new UserId(Guid.NewGuid());
        Email = email;
        NormalizedEmail = email.ToUpper();
        FirstName = firstName;
        LastName = lastName;

    }

    private User(string firstName,
                 string lastName,
                 string email, string userName) : base(userName)
    {
        Id = new UserId(Guid.NewGuid());
        Email = email;
        NormalizedEmail = email.ToUpper();
        FirstName = firstName;
        LastName = lastName;

    }
    


    #endregion

    #region Factories

    public static User CreateNew(string firstName,
                                 string lastName,
                                 string email)
    {
        return new User(firstName, lastName, email);
    }

    public static User CreateNew(string firstName,
                                 string lastName,
                                 string email, string userName)
    {
        return new User(firstName, lastName, email, userName);
    }

    #endregion


}
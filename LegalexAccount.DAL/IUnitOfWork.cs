﻿using LegalexAccount.DAL.Models.AccountAggregate;
using LegalexAccount.DAL.Models.CaseAggregate;
using LegalexAccount.DAL.Models.ChatAggregate;
using LegalexAccount.DAL.Models.OrderAggregate;
using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories.Contracts;


namespace LegalexAccount.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository<User> Users { get; }
        IRepository<Specialist, Guid> Specialists { get; }
        IRepository<Client, Guid> Clients { get; }
        IRepository<Person, Guid> Individuals { get; }
        IRepository<Legal, Guid> LegalEntities { get; }
        IRepository<Order, int> Orders { get; }
        IRepository<Case, int> Cases { get; }
        IRepository<Chat, Guid> Chats { get; }
        IRepository<PasswordResetToken, int> PasswordResetTokens { get; }
    }
}

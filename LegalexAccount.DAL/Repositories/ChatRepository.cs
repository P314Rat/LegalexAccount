﻿using LegalexAccount.DAL.Models.ChatAggregate;
using LegalexAccount.DAL.Repositories.Contracts;


namespace LegalexAccount.DAL.Repositories
{
    class ChatRepository : IRepository<Chat, Guid>
    {
        private readonly ApplicationDbContext _dbContext;


        public ChatRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Chat?> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Chat item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Chat?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Chat item)
        {
            throw new NotImplementedException();
        }
    }
}

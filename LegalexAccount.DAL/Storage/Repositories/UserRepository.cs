using LegalexAccount.DAL.Models;
using LegalexAccount.DAL.Models.UserAggregate;
using Microsoft.EntityFrameworkCore;
using System;


namespace LegalexAccount.DAL.Storage.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContextFactory _dbContextFactory;


        public UserRepository(IApplicationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var tasks = new Dictionary<Task<User>, ApplicationDbContext>();

            for (int i = 0; i < 3; i++)
            {
                var dbContext = _dbContextFactory.CreateDbContext();

                Task<User> task = i switch
                {
                    0 => dbContext.Individuals.FirstOrDefaultAsync(c => c.Email == email).ContinueWith(t => (User)t.Result),
                    1 => dbContext.LegalEntities.FirstOrDefaultAsync(c => c.Email == email).ContinueWith(t => (User)t.Result),
                    2 => dbContext.Specialists.FirstOrDefaultAsync(s => s.Email == email).ContinueWith(t => (User)t.Result),
                    _ => Task.FromResult<User>(null)
                };

                tasks.Add(task, dbContext);
            }

            while (tasks.Any())
            {
                var pendingTasks = tasks.Keys.ToArray();
                var completedTask = await Task.WhenAny(pendingTasks);

                if (await completedTask is User user && user != null)
                {
                    tasks.GetValueOrDefault(completedTask)?.Dispose();
                    tasks.Remove(completedTask);
                    return user; // Возвращаем пользователя
                }

                // Удаляем завершенное задание из списка
                tasks.GetValueOrDefault(completedTask)?.Dispose();
                tasks.Remove(completedTask);
            }

            throw new InvalidOperationException("User was not found");
        }

        public bool IsExists(string email)
        {
            var dbContext = _dbContextFactory.CreateDbContext();

            var isLoginExists = dbContext.Specialists
                .Select(x => x.Email)
                .Union(dbContext.Individuals.Select(x => x.Email).Union(dbContext.LegalEntities.Select(x => x.Email)))
                .Any(x => x == email);

            return isLoginExists;
        }
    }
}

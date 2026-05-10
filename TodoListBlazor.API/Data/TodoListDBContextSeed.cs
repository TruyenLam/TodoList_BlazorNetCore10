using Microsoft.AspNetCore.Identity;
using TodoListBlazor.API.Entities;
using TodoListBlazor.API.Enums;
using Task = System.Threading.Tasks.Task;

namespace TodoListBlazor.API.Data
{
    public class TodoListDBContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public async Task SeedAsync(TodoListDBContext context, ILogger<TodoListDBContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM"
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123");
                context.Users.Add(user);

            }
            if (!context.Tasks.Any())
            {
                var task1 = new Entities.Task
                {
                    Id = Guid.NewGuid(),
                    Name = "Sample Task 1",
                    CreateDate = DateTime.Now,
                    Status = Status.Open,
                };
                context.Tasks.Add(task1);
                
            }
            await context.SaveChangesAsync();
        }
    }
}

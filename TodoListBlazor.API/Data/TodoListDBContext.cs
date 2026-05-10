
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoListBlazor.API.Entities;
namespace TodoListBlazor.API.Data
{
    public class TodoListDBContext : IdentityDbContext<User,Role, Guid>
    {
        public TodoListDBContext(DbContextOptions<TodoListDBContext> options) : base(options)
        {
        }
        public DbSet<Entities.Task> Tasks { get; set; }
    }
}

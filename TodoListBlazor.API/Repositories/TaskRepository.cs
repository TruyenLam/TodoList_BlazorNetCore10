
using TodoListBlazor.API.Data;
using Microsoft.EntityFrameworkCore;

namespace TodoListBlazor.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoListDBContext _context;
        public TaskRepository(TodoListDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Entities.Task>> GetTaskList()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Entities.Task> Create(Entities.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Entities.Task> Delete(Entities.Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Entities.Task> GetById(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        
        }

        public async Task<Entities.Task> Update(Entities.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }
        
    }
}

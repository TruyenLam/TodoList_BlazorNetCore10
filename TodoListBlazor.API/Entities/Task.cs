using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoListBlazor.API.Enums;

namespace TodoListBlazor.API.Entities
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(500)]
        [Required]
        public string Name { get; set; }
        public Guid? AssigneeId { get; set; }
        [ForeignKey(nameof(AssigneeId))]
        public User Assignee { get; set; }
        public DateTime CreateDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}

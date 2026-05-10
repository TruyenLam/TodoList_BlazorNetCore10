using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TodoListBlazor.API.Entities
{
    public class Role: IdentityRole<Guid>
    {
        [MaxLength(500)]
        [Required]
        public string Description { get; set; }
    }
}

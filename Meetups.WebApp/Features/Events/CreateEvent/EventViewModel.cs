using System.ComponentModel.DataAnnotations;

namespace Meetups.WebApp.Features.Events.CreateEvent
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string? Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string? Description { get; set; } = string.Empty;

        [Required]
        public DateTime BeginDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string? Location { get; set; } = string.Empty;

        [Required]
        public string? Category { get; set; } = string.Empty;

        public int Capacity { get; set; }

        public int OrganizerId { get; set; }
    }
}
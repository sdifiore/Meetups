using System.ComponentModel.DataAnnotations;

namespace Meetups.WebApp.Data.Entities
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string? Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string? Description { get; set; } = string.Empty;

        [Required]
        public DateOnly BeginDate { get; set; }

        public TimeOnly BeginTime { get; set; }

        public DateOnly EndDate { get; set; }

        public TimeOnly EndTime { get; set; }

        public string? Location { get; set; } = string.Empty;

        public string? MeetupLink { get; set; } = string.Empty;

        public string? Category { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        public int OrganizerId { get; set; }
    }
}
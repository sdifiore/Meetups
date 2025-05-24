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
        public DateOnly BeginDate { get; set; }

        public TimeOnly BeginTime { get; set; }

        public DateOnly EndDate { get; set; }

        public TimeOnly EndTime { get; set; }

        public string? Location { get; set; } = string.Empty;

        public string? MeetupLink { get; set; } = string.Empty;

        [Required]
        public string? Category { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be above 0.")]
        public int Capacity { get; set; }

        public int OrganizerId { get; set; }

        public void EvenntViewModel()
        {
            BeginDate = DateOnly.FromDateTime(DateTime.Now);
            EndDate = DateOnly.FromDateTime(DateTime.Now);
            BeginTime = TimeOnly.FromDateTime(DateTime.Now);
            EndTime = TimeOnly.FromDateTime(DateTime.Now);
            Category = MeetupCategoriesEnum.InPerson.ToString();
        }

        public bool ValidateDateRange()
        {
            return BeginDate <= EndDate && (BeginDate != EndDate || BeginTime < EndTime);
        }

        public bool ValidateLocation()
        {
            return Category != MeetupCategoriesEnum.InPerson.ToString() || !string.IsNullOrWhiteSpace(Location);
        }

        public bool ValidateMeetupLink()
        {
            return Category != MeetupCategoriesEnum.Online.ToString() || !string.IsNullOrWhiteSpace(MeetupLink);
        }
    }
}
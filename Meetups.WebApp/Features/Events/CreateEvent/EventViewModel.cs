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

        public string? Category { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public int Capacity { get; set; }

        public int OrganizerId { get; set; }

        public EventViewModel()
        {
            BeginDate = DateOnly.FromDateTime(DateTime.Now);
            EndDate = DateOnly.FromDateTime(DateTime.Now);
            BeginTime = TimeOnly.FromDateTime(DateTime.Now);
            EndTime = TimeOnly.FromDateTime(DateTime.Now);
            Category = MeetupCategoriesEnum.InPerson.ToString();
        }

        public string? ValidateDates()
        {
            return BeginDate > EndDate
                ? "Begin date should be earlier than End Date"
                : BeginDate == EndDate && BeginTime > EndTime ? "Begin time should be earlier than End Date"
                : string.Empty;
        }

        public string? ValidateLocation()
        {
            return Category == MeetupCategoriesEnum.InPerson.ToString() || !string.IsNullOrWhiteSpace(Location)
                ? "Location is required for In-Person Meetup."
                : string.Empty;
        }

        public string? ValidateMeetupLink()
        {
            return Category == MeetupCategoriesEnum.Online.ToString() || !string.IsNullOrWhiteSpace(MeetupLink)
                ? "Meetup Link is required for Online Meetup."
                : string.Empty;
        }
    }
}
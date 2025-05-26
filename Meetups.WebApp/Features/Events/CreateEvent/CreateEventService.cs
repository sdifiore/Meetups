namespace Meetups.WebApp.Features.Events.CreateEvent
{
    public class CreateEventService
    {
        public CreateEventService()
        { }

        public string? ValidateEvent(EventViewModel eventViewModel)
        {
            if (eventViewModel == null)
            {
                return "Event cannot be null.";
            }

            string? errorMessage = string.Empty;

            errorMessage = eventViewModel.ValidateDates() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                return errorMessage;
            }

            errorMessage = eventViewModel.ValidateLocation() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                return errorMessage;
            }

            errorMessage = eventViewModel.ValidateMeetupLink() ?? string.Empty;
            return !string.IsNullOrWhiteSpace(errorMessage) ? errorMessage : string.Empty;
        }
    }
}
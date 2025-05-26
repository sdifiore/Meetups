using Meetups.WebApp.Data;
using Meetups.WebApp.Data.Entities;

using Microsoft.EntityFrameworkCore;

namespace Meetups.WebApp.Features.Events.CreateEvent
{
    public class CreateEventService
    {
        private readonly IDbContextFactory<ApplicationDbContext> contextFactory;

        public CreateEventService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            this.contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        public async Task CreateEventAsync(EventViewModel eventViewModel)
        {
            using var context = contextFactory.CreateDbContext();
            context.Events?.Add(new Event
            {
                Title = eventViewModel.Title,
                Description = eventViewModel.Description,
                BeginDate = eventViewModel.BeginDate,
                BeginTime = eventViewModel.BeginTime,
                EndDate = eventViewModel.EndDate,
                EndTime = eventViewModel.EndTime,
                //Location = eventViewModel.Location,
                MeetupLink = eventViewModel.MeetupLink,
                Category = eventViewModel.Category,
                Capacity = eventViewModel.Capacity,
                OrganizerId = eventViewModel.OrganizerId
            });
            await context.SaveChangesAsync(); // Will save everything new to the database
        }

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

            //errorMessage = eventViewModel.ValidateLocation() ?? string.Empty;
            //if (!string.IsNullOrWhiteSpace(errorMessage))
            //{
            //    return errorMessage;
            //}

            errorMessage = eventViewModel.ValidateMeetupLink() ?? string.Empty;
            return !string.IsNullOrWhiteSpace(errorMessage) ? errorMessage : string.Empty;
        }
    }
}
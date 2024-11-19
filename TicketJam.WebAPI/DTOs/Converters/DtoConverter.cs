using TicketJam.DAL.Model;

namespace TicketJam.WebAPI.DTOs.Converters
{
    public static class DtoConverter
    {
        public static EventDto ToDto(this DAL.Model.Event eventToConvert)
        {
            var EventDto = new EventDto();
            eventToConvert.CopyPropertiesTo(EventDto);
            return EventDto;
        }

        public static DAL.Model.Event FromDto(this EventDto eventDtoToConvert)
        {
            var Event = new DAL.Model.Event();
            eventDtoToConvert.CopyPropertiesTo(Event);
            return Event;
        }

        public static EventDtoForeignKeys ToDtoForeignKey(this DAL.Model.Event eventToConvert)
        {
            var EventDto = new EventDtoForeignKeys();
            eventToConvert.CopyPropertiesTo(EventDto);
            return EventDto;
        }

        public static DAL.Model.Event FromDto(this EventDtoForeignKeys eventDtoToConvert)
        {
            var Event = new DAL.Model.Event();
            eventDtoToConvert.CopyPropertiesTo(Event);
            return Event;
        }

        public static IEnumerable<EventDto> ToDtos(this IEnumerable<DAL.Model.Event> eventToConvert)
        {
            foreach (var Event in eventToConvert)
            {
                yield return Event.ToDto();
            }
        }

        public static IEnumerable<DAL.Model.Event> FromDtos(this IEnumerable<EventDto> eventDtosToConvert)
        {
            foreach (var eventDtos in eventDtosToConvert)
            {
                yield return eventDtos.FromDto();
            }
        }

        public static OrganizerDto ToDto(this DAL.Model.Organizer organizerToConvert)
        {
            var OrganizerDto = new OrganizerDto();
            organizerToConvert.CopyPropertiesTo(OrganizerDto);
            return OrganizerDto;
        }

        public static DAL.Model.Organizer FromDto(this OrganizerDto organizerDtoToConvert)
        {
            var Organizer = new DAL.Model.Organizer();
            organizerDtoToConvert.CopyPropertiesTo(Organizer);
            return Organizer;
        }

        public static VenueDto ToDto(this DAL.Model.Venue venueToConvert)
        {
            var venueDto = new VenueDto();
            venueToConvert.CopyPropertiesTo(venueDto);
            return venueDto;
        }

        public static DAL.Model.Venue FromDto(this VenueDto venueDtoToConvert)
        {
            var Venue = new DAL.Model.Venue();
            venueDtoToConvert.CopyPropertiesTo(Venue);
            return Venue;
        }

        public static IEnumerable<VenueDto> ToDtos(this IEnumerable<DAL.Model.Venue> venueToConvert)
        {
            foreach (var Venue in venueToConvert)
            {
                yield return Venue.ToDto();
            }
        }

        public static IEnumerable<DAL.Model.Venue> FromDtos(this IEnumerable<VenueDto> venueDtosToConvert)
        {
            foreach (var venueDtos in venueDtosToConvert)
            {
                yield return venueDtos.FromDto();
            }
        }

    }
}

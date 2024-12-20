﻿using TicketJam.DAL.Model;

namespace TicketJam.WebAPI.DTOs.Converters
{
    public static class DtoConverter
    {
        public static EventDto ToDto(this DAL.Model.Event eventToConvert)
        {
            var EventDto = new EventDto();
            eventToConvert.CopyPropertiesTo(EventDto);

            // Explicitly convert Venue if it exists
            if (eventToConvert.Venue != null)
            {
                EventDto.Venue = eventToConvert.Venue.ToDto();
            }
            if (eventToConvert.Venue != null)
            {
                EventDto.Venue.Address = eventToConvert.Venue.Address.ToDto();
            }

            return EventDto;
        }


        public static DAL.Model.Event FromDto(this EventDto eventDtoToConvert)
        {
            var Event = new DAL.Model.Event();
            eventDtoToConvert.CopyPropertiesTo(Event);

            // Explicitly convert Venue if it exists
            if (eventDtoToConvert.Venue != null)
            {
                Event.Venue = eventDtoToConvert.Venue.FromDto();
            }
            if (eventDtoToConvert.Venue.Address != null)
            {
                Event.Venue.Address = eventDtoToConvert.Venue.Address.FromDto();
            }

            return Event;
        }

        public static DAL.Model.Ticket FromDto(this TicketDto ticketDtoToConvert)
        {
            var Ticket = new DAL.Model.Ticket();
            ticketDtoToConvert.CopyPropertiesTo(Ticket);

            // Explicitly convert Venue if it exists
            if (ticketDtoToConvert != null)
            {
                Ticket.Section = ticketDtoToConvert.Section.FromDto();
            }
            if (ticketDtoToConvert.Event != null)
            {
                Ticket.Event = ticketDtoToConvert.Event.FromDto();
            }

            return Ticket;
        }

        public static TicketDto ToDto(this DAL.Model.Ticket ticketToConvert)
        {
            var ticketDto = new TicketDto();
            ticketToConvert.CopyPropertiesTo(ticketDto);

            // Explicitly convert Venue if it exists
            if (ticketToConvert.Section != null)
            {
                ticketDto.Section = ticketToConvert.Section.ToDto();
            }
            if (ticketToConvert.Event != null)
            {
                ticketDto.Event = ticketToConvert.Event.ToDto();
            }

            return ticketDto;
        }


        public static EventDtoForeignKeys ToDtoForeignKey(this DAL.Model.Event eventToConvert)
        {
            var EventDto = new EventDtoForeignKeys();
            eventToConvert.CopyPropertiesTo(EventDto);
            if (eventToConvert.TicketList != null && eventToConvert.TicketList.Count < 0)
            {
                //eventToConvert.TicketList<TicketDto>.FromDtos();
            }
            return EventDto;
        }

        public static SectionDto ToDto(this DAL.Model.Section SectionToConvert)
        {
            var SectionDto = new SectionDto();
            SectionToConvert.CopyPropertiesTo(SectionDto);
            return SectionDto;
        }

        public static DAL.Model.Event FromDto(this EventDtoForeignKeys eventDtoToConvert)
        {
            var Event = new DAL.Model.Event();
            eventDtoToConvert.CopyPropertiesTo(Event);
            return Event;
        }

        public static DAL.Model.Section FromDto(this SectionDtoForeignKeys SectionForeignKeysDtoToConvert)
        {
            var Section = new DAL.Model.Section();
            SectionForeignKeysDtoToConvert.CopyPropertiesTo(Section);
            return Section;
        }

        public static DAL.Model.Section FromDto(this SectionDto SectionDtoToConvert)
        {
            var Section = new DAL.Model.Section();
            SectionDtoToConvert.CopyPropertiesTo(Section);
            return Section;
        }

        public static IEnumerable<SectionDto> ToDtos(this IEnumerable<DAL.Model.Section> sectionToConvert)
        {
            foreach (var Section in sectionToConvert)
            {
                yield return Section.ToDto();
            }
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


        public static AddressDto ToDto(this DAL.Model.Address addressToConvert)
        {
            var addressDto = new AddressDto();
            addressToConvert.CopyPropertiesTo(addressDto);
            return addressDto;
        }

        public static DAL.Model.Address FromDto(this AddressDto addressDtoToConvert)
        {
            var Address = new DAL.Model.Address();
            addressDtoToConvert.CopyPropertiesTo(Address);
            return Address;
        }

        public static IEnumerable<AddressDto> ToDtos(this IEnumerable<DAL.Model.Address> addressToConvert)
        {
            foreach (var Address in addressToConvert)
            {
                yield return Address.ToDto();
            }
        }

        public static IEnumerable<DAL.Model.Address> FromDtos(this IEnumerable<AddressDto> addressDtosToConvert)
        {
            foreach (var addressDtos in addressDtosToConvert)
            {
                yield return addressDtos.FromDto();
            }
        }

        public static IEnumerable<DAL.Model.Ticket> FromDtos(this List<TicketDto> ticketDtosToConvert)
        {
            foreach (var ticketDto in ticketDtosToConvert)
            {
                yield return ticketDto.FromDto();
            }
        }

        public static DAL.Model.Customer FromDto(this CustomerDto CustomerDtoToConvert)
        {
            var Customer = new DAL.Model.Customer();
            CustomerDtoToConvert.CopyPropertiesTo(Customer);
            return Customer;
        }

        public static CustomerDto ToDto(this DAL.Model.Customer customerToConvert)
        {
            var CustomerDto = new CustomerDto();
            customerToConvert.CopyPropertiesTo(CustomerDto);
            return CustomerDto;
        }

        public static IEnumerable<OrderDto> ToDtos(this IEnumerable<DAL.Model.Order> ordersToConvert)
        {
            foreach (var Order in ordersToConvert)
            {
                yield return Order.ToDto();
            }
        }

        public static OrderDto ToDto(this DAL.Model.Order orderToConvert)
        {
            var orderDto = new OrderDto();
            orderToConvert.CopyPropertiesTo(orderDto);
            if (orderToConvert.OrderLines != null && orderToConvert.OrderLines.Count != 0)
            {
                orderDto.OrderLines = orderToConvert.OrderLines.ToDtos().ToList();
            }
            return orderDto;
        }

        public static DAL.Model.Order FromDto(this OrderDto orderDtoToConvert)
        {
            var order = new DAL.Model.Order();
            orderDtoToConvert.CopyPropertiesTo(order);

            if (orderDtoToConvert.OrderLines != null && orderDtoToConvert.OrderLines.Count != 0)
            {
                order.OrderLines = orderDtoToConvert.OrderLines.FromDtos().ToList();
            }

            return order;
        }

        public static DAL.Model.Ticket FromDto(this TicketDtoForeignKeys ticketDtoToConvert)
        {
            var Ticket = new DAL.Model.Ticket();
            ticketDtoToConvert.CopyPropertiesTo(Ticket);
            return Ticket;
        }

        public static IEnumerable<OrderLine> FromDtos(this IEnumerable<OrderLineDto> orderLinesToConvert)
        {
            foreach (var orderLinesDto in orderLinesToConvert)
            {
                yield return orderLinesDto.FromDto();
            }
        }

        public static DAL.Model.OrderLine FromDto(this OrderLineDto orderLineDtoToConvert)
        {
            var orderLine = new DAL.Model.OrderLine();
            orderLineDtoToConvert.CopyPropertiesTo(orderLine);
            return orderLine;
        }

        public static OrderLineDto ToDto(this DAL.Model.OrderLine orderLineToConvert)
        {
            var orderLineDto = new OrderLineDto();
            orderLineToConvert.CopyPropertiesTo(orderLineDto);
            return orderLineDto;
        }

        public static IEnumerable<OrderLineDto> ToDtos(this IEnumerable<OrderLine> orderLinesToConvert)
        {
            foreach (var orderLinesDto in orderLinesToConvert)
            {
                yield return orderLinesDto.ToDto();
            }
        }
    }
}

using System;

namespace Domain.Exceptions
{
	public class ArrivalDateBeforeDepartureDateException : Exception
    {
        public ArrivalDateBeforeDepartureDateException(Guid voyageId, DateTime departureDate, DateTime arrivalDate) : base("Arrival date cannot be earlier than departure date")
        {
        }
    }
}
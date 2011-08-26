using System;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Sourcing;

namespace Events
{
	public class VoyageCreatedEvent : SourcedEvent
	{
	    public Guid Id { get; private set; }

	    public float Capacity { get; private set; }

	    public float CapacityUsed { get; private set; }

	    public float CapacityLeft { get; private set; }

	    public DateTime DepartureDate { get; private set; }

	    public DateTime ArrivalDate { get; private set; }

		public float OverbookingCapacity { get; private set; }

	    public VoyageCreatedEvent(Guid id, float capacity, float capacityUsed, float capacityLeft, DateTime departureDate, DateTime arrivalDate, float overbookingCapacity)
	    {
	        Id = id;
	        Capacity = capacity;
	        CapacityUsed = capacityUsed;
	        CapacityLeft = capacityLeft;
	        DepartureDate = departureDate;
	        ArrivalDate = arrivalDate;
			OverbookingCapacity = overbookingCapacity;
	    }
	}
}

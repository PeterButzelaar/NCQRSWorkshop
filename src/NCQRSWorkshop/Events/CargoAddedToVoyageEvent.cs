using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing;

namespace Events
{
	public class CargoAddedToVoyageEvent : SourcedEvent
	{
		public Guid CargoId { get; set; }
		public Guid VoyageId { get; set; }
		public float CapacityUsed { get; set; }
		public float CapacityLeft { get; set; }
		public DateTime DepartureDate { get; set; }
		public DateTime ArrivalDate { get; set; }

	    public CargoAddedToVoyageEvent()
	    {
	    }

	    public CargoAddedToVoyageEvent(Guid cargoId, Guid voyageId, float capacityUsed, float capacityLeft, DateTime departureDate, DateTime arrivalDate)
		{
			CargoId = cargoId;
			VoyageId = voyageId;
			CapacityUsed = capacityUsed;
			CapacityLeft = capacityLeft;
			DepartureDate = departureDate;
			ArrivalDate = arrivalDate;
		}
	}
}

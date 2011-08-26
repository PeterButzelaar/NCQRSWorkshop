using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace ReadModel.Denormalizers
{
	public class CargoAddedToVoyageUpdateCapacityDenormalizer : IEventHandler<CargoAddedToVoyageEvent>
	{
		public void Handle(CargoAddedToVoyageEvent e)
		{
			// Opdracht 3k
			// Haal het juiste voyage object op aan de hand van e.VoyageId en update CapacityLeft en CapacityUsed
		}
	}
}

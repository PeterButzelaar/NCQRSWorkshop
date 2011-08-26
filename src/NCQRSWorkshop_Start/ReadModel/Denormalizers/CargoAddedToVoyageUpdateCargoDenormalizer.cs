using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace ReadModel.Denormalizers
{
	public class CargoAddedToVoyageUpdateCargoDenormalizer : IEventHandler<CargoAddedToVoyageEvent>
	{
		public void Handle(CargoAddedToVoyageEvent e)
		{
			// Opdracht 3m
			// Haal het juiste cargo object op aan de hand van e.CargoId en update VoyageId, DepartureDate en ArrivalDate
		}
	}
}

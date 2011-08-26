using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace ReadModel.Denormalizers
{
	public class CargoCreatedDenormalizer : IEventHandler<CargoCreatedEvent>
	{
		public void Handle(CargoCreatedEvent e)
		{
			// Opdracht 1j
			// Maak een nieuw ReadModel.Cargo object aan, vul de properties en sla deze op in de database
		}
	}
}

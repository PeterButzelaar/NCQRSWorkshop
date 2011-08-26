using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing;

namespace Events
{
	public class CargoCreatedEvent : SourcedEvent
	{
		public Guid Id { get; private set; }
		public string Origin { get; private set; }
		public string Destination { get; private set; }
		public float Weight { get; private set; }
		public float Size { get; private set; }

		public CargoCreatedEvent(Guid id, string origin, string destination, float weight, float size)
		{
			Id = id;
			Origin = origin;
			Destination = destination;
			Weight = weight;
			Size = size;
		}
	}
}

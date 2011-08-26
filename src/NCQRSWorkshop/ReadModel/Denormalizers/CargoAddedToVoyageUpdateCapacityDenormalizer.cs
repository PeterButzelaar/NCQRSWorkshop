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
			using (var context = new DataClassesDataContext())
			{
				var voyage = context.Voyages.Single(v => v.Id.Equals(e.VoyageId));
				voyage.CapacityLeft = e.CapacityLeft;
				voyage.CapacityUsed = e.CapacityUsed;

				context.SubmitChanges();
			}
		}
	}
}

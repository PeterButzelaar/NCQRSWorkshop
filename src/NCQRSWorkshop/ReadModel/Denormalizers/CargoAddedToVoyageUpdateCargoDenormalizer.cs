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
			using (var context = new DataClassesDataContext())
			{
				var cargo = context.Cargos.Single(c => c.Id.Equals(e.CargoId));
				cargo.VoyageId = e.VoyageId;
				cargo.DepartureDate = e.DepartureDate;
				cargo.ArrivalDate = e.ArrivalDate;

				context.SubmitChanges();
			}
		}
	}
}

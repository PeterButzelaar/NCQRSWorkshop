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
			using (var context = new DataClassesDataContext())
			{
				var cargo = new Cargo();
				cargo.Id = e.Id;
				cargo.Origin = e.Origin;
				cargo.Destination = e.Destination;
				cargo.Weight = e.Weight;
				cargo.Size = e.Size;

				context.Cargos.InsertOnSubmit(cargo);
				context.SubmitChanges();
			}
		}
	}
}

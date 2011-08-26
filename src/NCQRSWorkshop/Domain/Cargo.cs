using System;
using Events;
using Ncqrs.Domain;

namespace Domain
{
	public class Cargo : AggregateRootMappedByConvention
	{
		private string _origin;
		private string _destination;
		private float _weight;
		private float _size;

	    public float Size
	    {
	        get { return _size; }
	    }

		public Cargo()
		{
		}

	    public Cargo(Guid id, string origin, string destination, float weight, float size)
			: base(id)
		{
			var e = new CargoCreatedEvent(id, origin, destination, weight, size);

			ApplyEvent(e);
		}

	    protected void OnCargoCreated(CargoCreatedEvent e)
		{
			_origin = e.Origin;
			_destination = e.Destination;
			_weight = e.Weight;
			_size = e.Size;
		}
	}
}

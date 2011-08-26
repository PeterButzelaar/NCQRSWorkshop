using System;
using Events;
using Ncqrs.Domain;
using Domain.Exceptions;

namespace Domain
{
	public class Voyage : AggregateRootMappedByConvention
	{
		private float _capacity;
		private float _overbookingCapcity;
		private float _capacityUsed;
		private float _capacityLeft;
		private DateTime _departureDate;
		private DateTime _arrivalDate;

		protected Voyage()
		{
		}

		public Voyage(Guid id, float capacity, DateTime departuredate, DateTime arrivalDate)
			: base(id)
		{
			GuardThatArrivalDateIsAfterDeparturetDate(departuredate, arrivalDate);

			const float overbooking = 1.1f;
			var e = new VoyageCreatedEvent(id, capacity, 0, capacity, departuredate, arrivalDate, capacity * overbooking);

			ApplyEvent(e);
		}

		public void AddCargo(Cargo cargo)
		{
			if(cargo == null) throw new ArgumentNullException("cargo");

			GuardThatThereIsEnoughRoomLeft(cargo);

			ApplyEvent(new CargoAddedToVoyageEvent
			{
				CargoId = cargo.EventSourceId,
				VoyageId = EventSourceId,
				ArrivalDate = _arrivalDate,
				DepartureDate = _departureDate,
				CapacityUsed = _capacityUsed + cargo.Size,
				CapacityLeft = _capacityLeft - cargo.Size
			});
		}

		private void GuardThatArrivalDateIsAfterDeparturetDate(DateTime departureDate, DateTime arrivalDate)
		{
			if (departureDate.CompareTo(arrivalDate) == 1)
			{
				throw new ArrivalDateBeforeDepartureDateException(EventSourceId, departureDate, arrivalDate);
			}
		}
		/// <summary>
		/// Throws an <see cref="NotEnoughCapacityLeftForCargoException"/> when there is not enough
		/// room left for the specified cargo.
		/// </summary>
		/// <param name="cargo">The cargo to add to this <see cref="Voyage"/>.</param>
		/// <exception cref="ArgumentNullException">Thrown when cargo is null.</exception>
		/// <exception cref="NotEnoughCapacityLeftForCargoException">Thrown when there is not enough
		/// room for the cargo to be added to this voyage.</exception>
		private void GuardThatThereIsEnoughRoomLeft(Cargo cargo)
		{
			if(cargo == null) throw new ArgumentNullException("cargo");

			var capacityLeftIncludingOverbook = _overbookingCapcity - _capacityUsed;

			if (cargo.Size > capacityLeftIncludingOverbook)
			{
				throw new NotEnoughCapacityLeftForCargoException(EventSourceId, capacityLeftIncludingOverbook,
																  cargo.EventSourceId, cargo.Size);
			}
		}

		protected void OnVoyageCreated(VoyageCreatedEvent e)
		{
			_capacity = e.Capacity;
			_overbookingCapcity = e.OverbookingCapacity;
			_capacityUsed = e.CapacityUsed;
			_capacityLeft = e.CapacityLeft;
			_departureDate = e.DepartureDate;
			_arrivalDate = e.ArrivalDate;
		}

		protected void OnCargoAddedToVoyage(CargoAddedToVoyageEvent e)
		{
			_capacityUsed = e.CapacityUsed;
			_capacityLeft = e.CapacityLeft;
		}
	}
}
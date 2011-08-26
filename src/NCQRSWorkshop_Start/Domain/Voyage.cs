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
			// Opdracht 2b
			// Roep een nieuwe methode GuardThatArrivalDateIsAfterDeparturetDate aan die controleert of arrival date na departure date ligt.
			// Zo niet, dan wordt er een ArrivalDateBeforeDepartureDateException gegooid

			const float overbooking = 1.1f;
			var e = new VoyageCreatedEvent(id, capacity, 0, capacity, departuredate, arrivalDate, capacity * overbooking);

			ApplyEvent(e);
		}

		public void AddCargo(Cargo cargo)
		{
			if(cargo == null) throw new ArgumentNullException("cargo");

			// Opdracht 4c
			// Roep de methode GuardThatThereIsEnoughRoomLeft aan die controleert of een voyage nog genoeg capaciteit heeft voor de cargo
			// Zo niet, dan wordt er een NotEnoughtCapacityLeftForCargoException gegooid

			// Opdracht 3i
			// Maak een nieuw CargoAddedToVoyageEvent aan en vul hiervan de properties.
			// Gebruik vervolgens de ApplyEvent(..) methode om het event uit te voeren.
		}

		/// <summary>
		/// Throws an <see cref="NotEnoughtCapacityLeftForCargoException"/> when there is not enough
		/// room left for the specified cargo.
		/// </summary>
		/// <param name="cargo">The cargo to add to this <see cref="Voyage"/>.</param>
		/// <exception cref="ArgumentNullException">Thrown when cargo is null.</exception>
		/// <exception cref="NotEnoughtCapacityLeftForCargoException">Thrown when there is not enough
		/// room for the cargo to be added to this voyage.</exception>
		private void GuardThatThereIsEnoughRoomLeft(Cargo cargo)
		{
			if(cargo == null) throw new ArgumentNullException("cargo");

			// Controleer of er genoeg ruimte is door gebruik te maken van de variabelen _overbookingCapcity, _capacityUsed en cargo.Size
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

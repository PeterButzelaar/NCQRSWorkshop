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

		/// <summary>
		/// The size of the cargo
		/// </summary>
		public float Size
		{
			get { return _size; }
		}

		public Cargo()
		{
		}

		// Opdracht 1g
		// Voeg constructor toe die alle properties van het CreateNewCargoCommand accepteerd als parameters

	}
}
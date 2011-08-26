using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;

namespace Commands
{
	public class AddCargoToVoyageCommand : CommandBase
	{
		public Guid CargoId { get; set; }
		public Guid VoyageId { get; set; }
		public float CargoSize { get; set; }
	}
}

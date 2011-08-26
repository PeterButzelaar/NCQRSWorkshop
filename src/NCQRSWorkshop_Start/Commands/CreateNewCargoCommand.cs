using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;

namespace Commands
{
	public class CreateNewCargoCommand : CommandBase
	{
		public Guid Id { get; set; }
		public string Origin { get; set; }
		public string Destination { get; set; }
		public float Weight { get; set; }
		public float Size { get; set; }
	}
}

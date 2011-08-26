using Commands;
using Domain;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using System;

namespace CommandExecutors
{
	public class AddCargoToVoyageCommandExecutor : CommandExecutorBase<AddCargoToVoyageCommand>
	{
		protected override void ExecuteInContext(IUnitOfWorkContext context, AddCargoToVoyageCommand command)
		{
			var voyage = context.GetById <Voyage>(command.VoyageId);
			var cargo = context.GetById<Cargo>(command.CargoId);
			
			voyage.AddCargo(cargo);
			context.Accept();
		}
	}
}

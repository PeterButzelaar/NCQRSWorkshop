using Commands;
using Domain;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using System;

namespace CommandExecutors
{
	public class CreateNewCargoCommandExecutor : CommandExecutorBase<CreateNewCargoCommand>
	{
		protected override void ExecuteInContext(IUnitOfWorkContext context, CreateNewCargoCommand command)
		{
			var cargo = new Cargo(command.Id, command.Origin, command.Destination, command.Weight, command.Size);
			
			context.Accept();
		}
	}
}

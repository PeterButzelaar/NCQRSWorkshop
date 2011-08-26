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
			// Opdracht 1e
			// Maak een nieuw Cargo object aan en roep de Accept() methode van context aan
		}
	}
}

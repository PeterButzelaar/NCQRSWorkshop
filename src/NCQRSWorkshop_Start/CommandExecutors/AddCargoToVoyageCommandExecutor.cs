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
			// Opdracht 3e
			// Haal de voyage en cargo op met de methode context.GetById<..>(..)

			// Opdracht 3f
			// Voeg de cargo aan de voyage toe met <voyage object>.Add(..) en roep de Accept() methode van context aan
		}
	}
}

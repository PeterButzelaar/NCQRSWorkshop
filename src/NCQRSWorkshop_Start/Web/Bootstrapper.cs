using CommandExecutors;
using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Config.StructureMap;
using Ncqrs.Eventing.ServiceModel.Bus;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Storage.SQL;
using ReadModel.Denormalizers;
using System.Reflection;

namespace Web
{
	public static class Bootstrapper
	{
		public static void BootUp()
		{
			var cfg = new StructureMapConfiguration(i =>
			{
				i.For<ICommandService>().Use(InitializeCommandService());
				i.For<IEventStore>().Use(InitializeEventStore());
				i.For<IEventBus>().Use(InitializeEventBus());
			});

			NcqrsEnvironment.Configure(cfg);
		}

		private static ICommandService InitializeCommandService()
		{
			var service = new CommandService();
			service.RegisterExecutor(new CreateNewVoyageCommandExecutor());
			service.RegisterExecutor(new CreateNewCargoCommandExecutor());
			service.RegisterExecutor(new AddCargoToVoyageCommandExecutor());

			return service;
		}

		private static IEventStore InitializeEventStore()
		{
			var store = new MsSqlServerEventStore(@"Data Source=.\sqlexpress;Initial Catalog=NCQRSWorkshopEventStore;Integrated Security=True");
			return store;
		}

		private static IEventBus InitializeEventBus()
		{
			var bus = new InProcessEventBus();

			// 2 opties: registreer denormalizers stuk voor stuk of registreer de gehele assembly

			//bus.RegisterHandler(new VoyageCreatedDenormalizer());
			//bus.RegisterHandler(new CargoCreatedDenormalizer());
			//bus.RegisterHandler(new CargoAddedToVoyageUpdateCapacityDenormalizer());
			//bus.RegisterHandler(new CargoAddedToVoyageUpdateCargoDenormalizer());

			bus.RegisterAllHandlersInAssembly(Assembly.Load("ReadModel"));

			return bus;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Commands;
using ReadModel;
using Domain.Exceptions;

namespace Web.Controllers
{
	public class CargoController : Controller
	{
		public ActionResult Index()
		{
			using (var context = new DataClassesDataContext())
			{
				var cargos = context.Cargos.ToList();
				return View(cargos);
			}
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Cargo model)
		{
			if (ModelState.IsValid)
			{
				var id = Guid.NewGuid();
				try
				{
					CreateNewCargoCommand createCommand = new CreateNewCargoCommand
					{
						Id = id,
						Destination = model.Destination,
						Origin = model.Origin,
						Size = model.Size,
						Weight = model.Weight
					};
					MvcApplication.CommandService.Execute(createCommand);
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("CargoCreationFailed", ex);
					return View();
				}
				try
				{
					if (model.VoyageId != null)
					{
						var AddCargoToVoyageCommand = new AddCargoToVoyageCommand
						{
							CargoId = id,
							VoyageId = (Guid)model.VoyageId,
							CargoSize = model.Size,
						};

						MvcApplication.CommandService.Execute(AddCargoToVoyageCommand);
					}
				}
				catch (NotEnoughCapacityLeftForCargoException ex)
				{
					return RedirectToAction("CouldNotBeAddedToVoyage");
				}
			}
			return RedirectToAction("Index");
		}

		public ActionResult CouldNotBeAddedToVoyage()
		{
			return View();
		}
	}
}

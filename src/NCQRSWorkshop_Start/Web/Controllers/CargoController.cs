using System;
using System.Linq;
using System.Web.Mvc;
using ReadModel;
using Commands;
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
				var cargoId = Guid.NewGuid();
				try
				{
					// Opdracht 1c
					// Create new cargo command

					if (model.VoyageId != null)
					{
						// Opdracht 3c
						// Add cargo to voyage command
					}
				}
				catch (NotEnoughtCapacityLeftForCargoException)
				{
					return RedirectToAction("CouldNotBeAddedToVoyage");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("CargoCreationFailed", ex);
					return View();
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

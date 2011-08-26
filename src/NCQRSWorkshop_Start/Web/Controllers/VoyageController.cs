using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.Mvc;
using Commands;
using ReadModel;
using Domain.Exceptions;

namespace Web.Controllers
{
	public class VoyageController : Controller
	{
		public ActionResult Index()
		{
			using (var context = new DataClassesDataContext())
			{
				var voyages = context.Voyages.ToList();
				return View(voyages);
			}
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(CreateNewVoyageCommand command)
		{
			command.Id = Guid.NewGuid();
			try
			{
				MvcApplication.CommandService.Execute(command);
			}
			catch (ArrivalDateBeforeDepartureDateException ex)
			{
				ModelState.AddModelError("ArrivalDate", ex.Message);
				return View();
			}

			return View();
		}
	}
}

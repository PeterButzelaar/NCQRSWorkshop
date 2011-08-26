using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadModel;

namespace Web.Models
{
	public static class VoyageHelper
	{
		public static IEnumerable<SelectListItem> GetVoyageList()
		{
			using (var context = new DataClassesDataContext())
			{
				yield return new SelectListItem() { Selected = true, Text = string.Empty, Value = null };

				var result = context.Voyages.OrderBy(v => v.DepartureDate).ToList();
				foreach (var item in result)
				{
					string departureDate = item.DepartureDate == null ? "unknown" : ((DateTime)item.DepartureDate).ToString("dd-MM-yyyy");
					yield return new SelectListItem() { Selected = false, Text = "Departure: " + departureDate, Value = item.Id.ToString() };
				}
			}
		}
	}
}
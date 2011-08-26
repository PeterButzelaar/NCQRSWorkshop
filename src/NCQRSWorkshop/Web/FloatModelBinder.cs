using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace Web
{
	public class FloatModelBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			var modelState = new ModelState
			{
				Value = valueResult
			};
			object actualValue = null;
			try
			{
				actualValue = float.Parse(valueResult.AttemptedValue);
			}
			catch (FormatException e)
			{
				modelState.Errors.Add(e);
			}
			bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
			
			return actualValue; }
	}
}
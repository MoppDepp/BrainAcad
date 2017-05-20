namespace CarShop.WebApp.Infrastructure
{
    using System.IO;
    using System.Web.Mvc;

    using CarShop.Models.ViewModels;

    public class CarViewModelBinder : IModelBinder
    {
        public object BindModel(
            ControllerContext controllerContext, 
            ModelBindingContext bindingContext)
        {
            var model = new CarViewModel();
            using (var reader = new StreamReader(controllerContext.HttpContext.Request.InputStream))
            {
                var result = reader.ReadToEnd();
                var properties = result.Split('&');
                foreach (var property in properties)
                {
                    var propValue = property.Split('=');
                    if (propValue[0] == "Brand")
                    {
                        model.Brand = propValue[1];
                    }

                    if (propValue[0] == "Model")
                    {
                        model.Model = propValue[1];
                    }
                }
            }

            return model;
        }
    }
}
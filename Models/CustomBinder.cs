using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CricketCrudApi.Models
{
    public class CustomBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Query;
            var result = data.TryGetValue("cricketers", out var cricketer);
            if (result)
            {
                var array = cricketer.ToString().Split('|');

                bindingContext.Result=ModelBindingResult.Success(array);
            }

            return Task.CompletedTask;
        }
    }
}

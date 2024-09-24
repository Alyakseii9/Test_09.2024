using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace My_1_w.ModelBinders
{
    public class TestModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)  
        {
            throw new NotImplementedException();
        }
    }
}

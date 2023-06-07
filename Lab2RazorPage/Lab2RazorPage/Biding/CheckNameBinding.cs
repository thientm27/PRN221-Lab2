
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace Lab2RazorPage.Biding
{
    public class CheckNameBinding : IModelBinder
    {
        private readonly ILogger<CheckNameBinding> _logger;

        public CheckNameBinding(ILogger<CheckNameBinding> logger)
        {
            _logger = logger;
        }


        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentException(nameof(bindingContext));
            }
            
            // Get model name
            string modelName = bindingContext.ModelName;
            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            
            // set model state for the value bidi ng
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            string value = valueProviderResult.FirstValue;
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            var s = value.ToUpper();
            if (s.Contains("XXX"))
            {
                bindingContext.ModelState.TryAddModelError(modelName, "Cannot contain this pattern xxx");
                return Task.CompletedTask;
            }
            
            bindingContext.Result = ModelBindingResult.Success(s.Trim());
            
            return Task.CompletedTask;

        }
    }
}
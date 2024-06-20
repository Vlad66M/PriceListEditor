using Microsoft.AspNetCore.Mvc.ModelBinding;
using PriceListEditor.ViewModels;

namespace PriceListEditor.Helpers
{
    public class ValidationHelper
    {
        public void AddErrorMessagesToProduct(ModelStateDictionary modelState, CreateProductVM createProductVM)
        {
            foreach(var el in modelState)
            {
                modelState[el.Key]?.Errors.Clear();
            }
            if (string.IsNullOrEmpty(createProductVM.Name))
            {
                modelState.AddModelError("", "Не заполнено название товара");
            }
            if (createProductVM.Code is null)
            {
                modelState.AddModelError("", "Не указан код товара");
            }
            var featureErrors = modelState.Where(e => e.Key.Contains("Feature")).ToList();
            if(featureErrors.Any(e => e.Value.ValidationState == ModelValidationState.Invalid))
            {
                modelState.AddModelError("", "Не заполнены значения колонок");
            }
        }

        public void AddErrorMessagesToPriceList(ModelStateDictionary modelState, PriceListVM priceListVM)
        {
            foreach (var el in modelState)
            {
                modelState[el.Key]?.Errors.Clear();
            }
            modelState.AddModelError("", "Неверно заполнены поля");
            if (string.IsNullOrEmpty(priceListVM.Name))
            {
                modelState.AddModelError("", "Название прайс-листа не может быть пустым");
            }
            if (modelState.ErrorCount > 1 && !string.IsNullOrEmpty(priceListVM.Name))
            {
                modelState.AddModelError("", "Не выбран тип колонки");
            }
            
        }
    }
}

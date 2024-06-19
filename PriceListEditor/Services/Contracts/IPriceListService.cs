using PriceListEditor.ViewModels;

namespace PriceListEditor.Services.Contracts
{
    public interface IPriceListService
    {
        Task<string> CreatePriceList(PriceListVM priceListVM);
    }
}

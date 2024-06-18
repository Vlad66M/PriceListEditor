using PriceListEditor.ViewModels;

namespace PriceListEditor.Services.Contracts
{
    public interface IPriceListService
    {
        Task CreatePriceList(PriceListVM priceListVM);
    }
}

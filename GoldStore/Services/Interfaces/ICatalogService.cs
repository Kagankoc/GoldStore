using GoldStore.ViewModels.Catalog;

namespace GoldStore.Services.Interfaces
{
    public interface ICatalogService
    {
        PagedProductViewModel FetchProducts(string categorySlug, string brandSlug);
        int GetCurrentPage();
    }
}
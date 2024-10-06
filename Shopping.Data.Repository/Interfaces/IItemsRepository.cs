using Shopping.Core.HelperTypes;
using Shopping.Data.Models.PostModels;
using Shopping.Data.Models.ViewModel;

namespace Shopping.Data.Repository.Interfaces;

public interface IItemsRepository
{
    Task<ResultType<bool>> AddAsync(ItemsAddModel model);
    Task<ResultType<IEnumerable<ItemsViewModel>>> GetListAsync();
    Task<ResultType<bool>> RemoveAsync(int Id);
}
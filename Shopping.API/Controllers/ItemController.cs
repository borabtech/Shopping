using Microsoft.AspNetCore.Mvc;
using Shopping.Core.HelperTypes;
using Shopping.Data.Models.PostModels;
using Shopping.Data.Models.ViewModel;
using Shopping.Data.Repository.Interfaces;

namespace Shopping.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    internal readonly IItemsRepository _repository;
    public ItemController(IItemsRepository repository)
    {
        _repository = repository;
    }
    [HttpPost]
    public async Task<ResultType<bool>> Add(ItemsAddModel model)
    {
        return await _repository.AddAsync(model);
    }

    [HttpDelete]
    public async Task<ResultType<bool>> Remove(int Id)
    {
        return await _repository.RemoveAsync(Id);
    }

    [HttpGet]
    public async Task<ResultType<IEnumerable<ItemsViewModel>>> GetList()
    {
        return await _repository.GetListAsync();
    }
}
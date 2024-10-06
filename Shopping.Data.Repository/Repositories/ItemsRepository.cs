using Microsoft.EntityFrameworkCore;
using Shopping.Core.Errors;
using Shopping.Core.HelperTypes;
using Shopping.Data.Database;
using Shopping.Data.Models.PostModels;
using Shopping.Data.Models.ViewModel;
using Shopping.Data.Repository.Interfaces;

namespace Shopping.Data.Repository.Repositories;

public class ItemsRepository : BaseRepository, IItemsRepository
{
    public ItemsRepository(DataContext context): base(context)
    {
        
    }
    public async Task<ResultType<bool>> AddAsync(ItemsAddModel model)
    {
        bool check = await _context.Items.AnyAsync(x=>x.Name == model.Name);
        if (check) {
            return new ResultType<bool>
            {
                Status = Core.Enumerations.EnumStatusType.Error,
                Message = DomainErrors._001_RecordAlreadyExist
            };
        }

        await _context.Items.AddAsync(new Entity.Item { Name= model.Name });
        await _context.SaveChangesAsync().ConfigureAwait(false);

        return new ResultType<bool>
        {
            Status = Core.Enumerations.EnumStatusType.Success,
            Message = DomainErrors._000_OK
        };
    }

    public async Task<ResultType<IEnumerable<ItemsViewModel>>> GetListAsync()
    {
        var data = await _context.Items.OrderBy(x => x.Name)
            .Select(x => new ItemsViewModel
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToListAsync()
            .ConfigureAwait(false);


        return new ResultType<IEnumerable<ItemsViewModel>>
        {
            Data = data,
            Status = Core.Enumerations.EnumStatusType.Success,
            Message = DomainErrors._000_OK
        };
    }

    public async Task<ResultType<bool>> RemoveAsync(int Id)
    {
        var data = await _context.Items.FindAsync(Id).ConfigureAwait(false);
        if (data != null)
        {
            _context.Items.Remove(data);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return new ResultType<bool>
            {
                Status = Core.Enumerations.EnumStatusType.Success,
                Message = DomainErrors._000_OK
            };
        }

        return new ResultType<bool> { Status = Core.Enumerations.EnumStatusType.Error, Message = DomainErrors._002_RecordNotFound };
    }
}
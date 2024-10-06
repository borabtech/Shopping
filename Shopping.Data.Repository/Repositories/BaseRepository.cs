using Shopping.Data.Database;

namespace Shopping.Data.Repository.Repositories;

public class BaseRepository
{
    protected readonly DataContext _context;
    public BaseRepository(DataContext context)
    {
        _context = context;
    }
}
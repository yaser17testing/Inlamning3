


using Inlamning3.Contexts;
using Inlamning3.Entites;

namespace Inlamning3.Repository;

internal class AdressRepository : BaseRepository<AdressEntity>
{

    private readonly DataContext _context;
    public AdressRepository(DataContext context) : base(context)
    {

        _context = context;

    }


}

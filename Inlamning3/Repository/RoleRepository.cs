


using Inlamning3.Contexts;
using Inlamning3.Entites;

namespace Inlamning3.Repository;

internal class RoleRepository : BaseRepository<RoleEntity>
{

    private readonly DataContext _context;
    public RoleRepository(DataContext context) : base(context)
    {

        _context = context;

    }







}
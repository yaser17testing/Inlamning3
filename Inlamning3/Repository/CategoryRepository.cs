


using Inlamning3.Contexts;
using Inlamning3.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Inlamning3.Repository;

internal class CategoryRepository : BaseRepository<CategoryEntity>
{

    private readonly DataContext _context;


    public CategoryRepository(DataContext context) : base(context)
    {

        _context = context;

    }


    public override CategoryEntity GetOne(Expression<Func<CategoryEntity, bool>> expression)
    {

        var result = _context.Category.Include(i => i.Products).FirstOrDefault(expression);

        return result!;



    }


    public override IEnumerable<CategoryEntity> GetAll()
    {
        return _context.Category.Include(i => i.Products).ToList();
    }




}





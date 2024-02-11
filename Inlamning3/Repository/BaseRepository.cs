

using Inlamning3.Contexts;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Inlamning3.Repository;

public abstract class BaseRepository<Tentity> where Tentity : class
{
    private readonly DataContext _context;

    protected BaseRepository(DataContext context)
    {
        _context = context;
    }



    public virtual Tentity Create(Tentity entity)
    {

        try
        {
            _context.Set<Tentity>().Add(entity);
            _context.SaveChanges();
            return entity;

        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }
        return null!;
    }


    public virtual IEnumerable<Tentity> GetAll()
    {

        try
        {

            return _context.Set<Tentity>().ToList();
        }
        catch

             (Exception ex)
        { Debug.WriteLine("Error :: " + ex.Message); }
        return null!;


    }

    public virtual Tentity GetOne(Expression<Func<Tentity, bool>> expression)
    {

        try
        {

            var result = _context.Set<Tentity>().FirstOrDefault(expression);


            return result!;
        }
        catch

             (Exception ex)
        { Debug.WriteLine("Error :: " + ex.Message); }
        return null!;




    }


    public virtual Tentity Update(Expression<Func<Tentity, bool>> expression, Tentity entity)
    {

        try
        {

            var entityToUpdate = _context.Set<Tentity>().FirstOrDefault(expression);

          
                
                _context.Entry(entityToUpdate!).CurrentValues.SetValues(entity);
                _context.SaveChanges();



                return entityToUpdate!;

            


        }
        catch(Exception ex)

             
        { Debug.WriteLine("Error :: " + ex.Message); }
        return null!;



    }


    public virtual bool Delete(Expression<Func<Tentity, bool>> predicate)
    {
        try
        {

            var entity = _context.Set<Tentity>().FirstOrDefault(predicate);

            if (entity != null)
            {

                _context.Set<Tentity>().Remove(entity);
                _context.SaveChanges();
                return true;

            }


        }
        catch

             (Exception ex)
        { Debug.WriteLine("Error :: " + ex.Message); }
        return false!;



    }


    public virtual bool Exists(Expression<Func<Tentity, bool>> predicate)
    {

        try
        {





            return _context.Set<Tentity>().Any(predicate);




        }
        catch

             (Exception ex)
        { Debug.WriteLine("Error :: " + ex.Message); }
        return false!;

    }
}
;

    



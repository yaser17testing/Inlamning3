

using Inlamning3.Entites;
using Microsoft.EntityFrameworkCore;

namespace Inlamning3.Contexts;

public partial class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public virtual DbSet<CustomerEntity> Customers { get; set; }

    public virtual DbSet<AdressEntity> Adresses { get; set; }

    public virtual DbSet<RoleEntity> Roles { get; set; }

    public virtual DbSet<OrderEntity> Order { get; set; }

    public virtual DbSet<ProductEntity> Products { get; set; }

    public virtual DbSet<CategoryEntity> Category { get; set; }




}


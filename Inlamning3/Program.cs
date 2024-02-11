using Inlamning3.Contexts;
using Inlamning3.Repository;
using Inlamning3.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Inlamning3;

public class Program
{
    static void Main(string[] args)
    {

        var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\Inlamning3\Inlamning3\data\local_database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));

                services.AddScoped<AdressRepository>();
                services.AddScoped<CustomerRepository>();
                services.AddScoped<CategoryRepository>();
                services.AddScoped<OrderRepository>();
                services.AddScoped<RoleRepository>();
                services.AddScoped<ProductRepository>();


                services.AddScoped<AdressService>();
                services.AddScoped<Cu_Ad_Ro_Or_Service>();
                services.AddScoped<CategoryAndProductService>();
                services.AddScoped<OrderService>();
                services.AddScoped<RoleService>();
                






            }).Build();
    }

}
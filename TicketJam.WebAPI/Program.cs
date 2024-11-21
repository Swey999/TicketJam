
using System.Security.Principal;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;

namespace TicketJam.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //string connectionString = builder.Configuration.GetConnectionString("DBConnectionString") ?? throw new Exception("Connectionstring not found");
            
            string connectionString = builder.Configuration.GetConnectionString("DBConnectionString");
            builder.Services.AddScoped<IDAO<Event>>(provider => new EventDAO(connectionString));
            builder.Services.AddScoped<IEventDAO>(provider => new EventDAO(connectionString));
            builder.Services.AddScoped<IDAO<Order>>(provider => new OrderDAO(connectionString));
            builder.Services.AddScoped<IDAO<Ticket>>(provider => new TicketDAO(connectionString));
            builder.Services.AddScoped<ICustomerDAO>(provider => new CustomerDAO(connectionString));
            builder.Services.AddScoped<IDAO<Customer>>(provider => new CustomerDAO(connectionString));
            builder.Services.AddScoped<IDAO<Venue>>(provider => new VenueDAO(connectionString));
            builder.Services.AddScoped<IDAO<Section>>(provider => new SectionDAO(connectionString));
            builder.Services.AddScoped<ISectionDAO>(provider => new SectionDAO(connectionString));



            builder.Services.AddSingleton<IDAO<Venue>>(provider => new VenueDAO(connectionString));
            builder.Services.AddSingleton<IOrganizerDAO>(provider => new OrganizerDAO(connectionString));

            //builder.Services.AddSingleton<IDAO<Event>>((_) => new EventDAO(connectionString));
            //builder.Services.AddSingleton<IDAO<Order>>((_) => new OrderDAO(connectionString));
            //builder.Services.AddSingleton<IDAO<Ticket>>((_) => new TicketDAO(connectionString));
            //builder.Services.AddSingleton<IDAO<Customer>>((_) => new CustomerDAO(connectionString));
            //builder.Services.AddSingleton<IDAO<Venue>>((_) => new VenueDAO(connectionString));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

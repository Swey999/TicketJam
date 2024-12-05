
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
            string connectionString = builder.Configuration.GetConnectionString("DBConnectionString");
            builder.Services.AddSingleton<IDAO<Event>>(provider => new EventDAO(connectionString));
            builder.Services.AddSingleton<IEventDAO>(provider => new EventDAO(connectionString));
            builder.Services.AddSingleton<IDAO<Order>>(provider => new OrderDAO(connectionString));
            builder.Services.AddSingleton<IOrderDAO>(provider => new OrderDAO(connectionString));
            builder.Services.AddSingleton<ITicketDAO>(provider => new TicketDAO(connectionString));
            builder.Services.AddSingleton<IDAO<Ticket>>(provider => new TicketDAO(connectionString));
            builder.Services.AddSingleton<ICustomerDAO>(provider => new CustomerDAO(connectionString));
            builder.Services.AddSingleton<IDAO<Customer>>(provider => new CustomerDAO(connectionString));
            builder.Services.AddSingleton<IDAO<Venue>>(provider => new VenueDAO(connectionString));
            builder.Services.AddSingleton<IOrganizerDAO>(provider => new OrganizerDAO(connectionString));
            builder.Services.AddSingleton<ITicketDAO>(provider => new TicketDAO(connectionString));
            builder.Services.AddSingleton<ISectionDAO>(provider => new SectionDAO(connectionString));
            builder.Services.AddSingleton<IDAO<Section>>(provider => new SectionDAO(connectionString));

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

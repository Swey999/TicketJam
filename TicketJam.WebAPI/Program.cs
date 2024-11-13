
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

            string connectionString = builder.Configuration.GetConnectionString("DBConnectionString") ?? throw new Exception("Connectionstring not found");

            builder.Services.AddSingleton<IDAO<Event>>((_) => new EventDAO(connectionString));
            builder.Services.AddSingleton<IDAO<Order>>((_) => new OrderDAO(connectionString));
            builder.Services.AddSingleton<IDAO<Ticket>>((_) => new TicketDAO(connectionString));
            builder.Services.AddSingleton<IDAO<Customer>>((_) => new CustomerDAO(connectionString));
            builder.Services.AddSingleton<IDAO<Venue>>((_) => new VenueDAO(connectionString));
            builder.Services.AddSingleton<IDAO<Section>>((_) => new SectionDAO(connectionString));
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

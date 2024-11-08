
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

            builder.Services.AddSingleton<IEventDAO>((_) => new EventDAO(connectionString));
            builder.Services.AddSingleton<IDAO<Order>>((_) => new OrderDAO(connectionString));

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

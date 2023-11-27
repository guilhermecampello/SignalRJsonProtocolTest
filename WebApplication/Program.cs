namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
                options.MaximumReceiveMessageSize = 1_000_000;
            })
                .AddJsonProtocol();

            var app = builder.Build();

            app.MapHub<ChatHub>("/hubs/chat");

            app.MapControllers();

            app.Run("http://localhost:5000");
        }
    }
}

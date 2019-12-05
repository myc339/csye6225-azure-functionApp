//
//[assembly: WebJobsStartup(typeof(Startup))]
//namespace JsonPlaceHolderDependencyInjection
//{
//    public class Startup : IWebJobsStartup
//    {
//        public Startup()
//        {
//            // Initialize serilog logger
//            Log.Logger = new LoggerConfiguration()
//                     .WriteTo.Console(Serilog.Events.LogEventLevel.Debug)
//                     .MinimumLevel.Debug()
//                     .Enrich.FromLogContext()
//                     .CreateLogger();
//        }
//
//        public void Configure(IWebJobsBuilder builder)
//        {
//            ConfigureServices(builder.Services).BuildServiceProvider(true);
//        }
//
//        private IServiceCollection ConfigureServices(IServiceCollection services)
//        {
//            services
//                .AddLogging(loggingBuilder =>
//                    loggingBuilder.AddSerilog(dispose: true)
//                )
//                .AddTransient<IJsonPlaceholderClient, JsonPlaceholderClient>(client =>
//                    new JsonPlaceholderClient(Environment.GetEnvironmentVariable("BaseAddress"))
//                )
//                .AddTransient<IJsonPlaceholderService, JsonPlaceholderService>();
//
//            return services;
//        }
//    }
//}
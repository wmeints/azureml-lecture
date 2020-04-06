using System.Threading.Tasks;
using CustomerChurn.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerChurn.Client
{
    public class Program {
        public static async Task Main(string[] args) 
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddTransient<IDataService, DataService>();
            builder.Services.AddTransient<IChurnModel, ChurnModel>();

            await builder.Build().RunAsync();
        }
    }
}
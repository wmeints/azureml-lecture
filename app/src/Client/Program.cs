using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace CustomerChurn.Client
{
    public class Program {
        public static async Task Main(string[] args) 
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            
            await builder.Build().RunAsync();
        }
    }
}
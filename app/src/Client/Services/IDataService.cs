using System.Threading.Tasks;
using CustomerChurn.Shared;

namespace CustomerChurn.Client.Services
{
    public interface IDataService
    {
        Task<CustomerViewModel> GetCustomerAsync(string id);
        Task<PagedResultSet<CustomerViewModel>> GetCustomersAsync(int pageIndex);
    }
}
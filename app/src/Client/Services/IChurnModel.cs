using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerChurn.Shared;

namespace CustomerChurn.Client.Services
{
    public interface IChurnModel
    {
        public Task<IEnumerable<decimal>> Predict(CustomerViewModel viewModel);
    }
}
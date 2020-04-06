using System.Linq;
using System.Threading.Tasks;
using CustomerChurn.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerChurn.Server.Controllers
{
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomersController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [Route("/api/customers/")]
        public async Task<PagedResultSet<Customer>> Index(int page = 0)
        {
            var results = await _applicationDbContext.Customers
                .OrderBy(x => x.Id)
                .Skip(page * 20)
                .Take(20)
                .ToListAsync();

            var totalItemCount = await _applicationDbContext.Customers.CountAsync();

            return new PagedResultSet<Customer>
            {
                Items= results,
                TotalItems = totalItemCount,
                PageIndex = page,
                PageSize = 20
            };
        }

        [Route("/api/customers/{id}")]
        public async Task<ActionResult<Customer>> Details(string id)
        {
            var result = await _applicationDbContext.Customers
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return NotFound(new { message = "Object not found"});
            }

            return Ok(result);
        }
    }
}
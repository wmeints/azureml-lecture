using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomerChurn.Server.Data;
using CustomerChurn.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerChurn.Server.Controllers
{
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public CustomersController(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        [Route("/api/customers/")]
        public async Task<PagedResultSet<CustomerViewModel>> Index(int page = 0)
        {
            var results = await _applicationDbContext.Customers
                .OrderBy(x => x.Id)
                .Skip(page * 20)
                .Take(20)
                .ToListAsync();

            var totalItemCount = await _applicationDbContext.Customers.CountAsync();

            return new PagedResultSet<CustomerViewModel>
            {
                Items = results.Select(x => _mapper.Map<CustomerViewModel>(x)).ToList(),
                TotalPages = (int)Math.Ceiling(totalItemCount / 20.0),
                PageIndex = page,
                PageSize = 20
            };
        }

        [Route("/api/customers/{id}")]
        public async Task<ActionResult<CustomerViewModel>> Details(string id)
        {
            var result = await _applicationDbContext.Customers
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return NotFound(new { message = "Object not found"});
            }

            return Ok(_mapper.Map<CustomerViewModel>(result));
        }
    }
}
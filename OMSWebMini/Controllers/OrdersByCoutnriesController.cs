using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMSWebMini.Data;
using OMSWebMini.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMSWebMini.Controllers
{
	[ApiController]
	public class OrdersByCoutnriesController : ControllerBase
	{
		private readonly NorthwindContext _context;
		public OrdersByCoutnriesController(NorthwindContext context)
		{
			_context = context;
		}
		
		[HttpGet]
		[Route("api/[controller]/Get")]
		public async Task<ActionResult<IEnumerable<OrdersByCountry>>> Get()
		{
			return await _context.OrdersByCountries.ToListAsync();
		}
	}
}

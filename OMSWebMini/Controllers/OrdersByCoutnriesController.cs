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
		[Route("api/[controller]/GetOrdersByCountry")]
		public async Task<ActionResult<IEnumerable<OrdersByCountry>>> GetOrdersByCountry()
		{
			return await _context.OrdersByCountries.ToListAsync();
		}
		
		[HttpGet]
		[Route("api/[controller]/GetSalesByCategories")]
		public async Task<ActionResult<IEnumerable<SalesByCategories>>> GetSalesByCategories()
		{
			return await _context.SalesByCategories.ToListAsync();
		}

	}
}

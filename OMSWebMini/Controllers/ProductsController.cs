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
	public class ProductsController : ControllerBase
	{
		private readonly NorthwindContext _context;
		public ProductsController(NorthwindContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Route("api/[controller]/ProductAsync")]
		public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
		{
			return await _context.Products.ToListAsync();
		}

		[HttpGet]
		[Route("api/[controller]/product_with_ID")]
		public async Task<ActionResult<Product>> GetProductByID(int id)
		{
			var product = await _context.Products.FindAsync(id);
			if (product == null)
			{
				return NotFound();
			}
			else
			{
				return new Product
				{
					ProductId = product.ProductId,
					CategoryId = product.CategoryId,
					ProductName = product.ProductName,
				};
			}
		}


		[HttpPost]
		[Route("api/[controller]/PostProduct")]
		public async Task<ActionResult<Product>> PostProduct(Product product)
		{
			_context.Products.Add(product);
			UpdateProductsByCategories(product);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(GetProduct),
				new
				{
					id = product.ProductId,
				}, product);
		}

		private async Task UpdateProductsByCategories(Product product)
		{
			var product1 = await _context.ProductsByCategories
				.Where(p => p.CategoryName == product.Category.CategoryName)
				.FirstOrDefaultAsync();
			if (product1 != null)
			{
				product1.ProductsCount++;
			}
			else
			{
				ProductsByCategories pbc = new ProductsByCategories
				{
					CategoryName = product.Category.CategoryName,
					ProductsCount = 1
				};
				_context.ProductsByCategories.Add(pbc);
			}
		}

	}
}

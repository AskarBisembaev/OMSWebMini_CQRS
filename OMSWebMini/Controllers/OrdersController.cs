using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMSWebMini.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OMSWebMini.Models;

namespace OMSWebMini.Controllers
{
	//api
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly NorthwindContext _context;
		public OrdersController(NorthwindContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Route("api/[controller]/GetOrdersAsync")]
		public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
		{
			return await _context.Orders.Select(o => new Order
			{
				OrderId = o.OrderId,
				//ShipCountry = o.Customer.Country
				//OrderDate = o.OrderDate,
				//CustomerId = o.CustomerId,
				//EmployeeId = o.EmployeeId
			}).ToListAsync();
		}

		[HttpGet]
		[Route("api/[controller]/GetOrdersWithID")]
		public async Task<ActionResult<Order>> GetOrder(int id)
		{
			var order = await _context.Orders

			   .Where(o => o.OrderId == id)

			   .FirstOrDefaultAsync();

			if (order == null) return NotFound();

			return order;
		}

		[HttpPost]
		[Route("api/[controller]/PostOrder")]
		public async Task<ActionResult<Order>> PostOrder(Order order)
		{
			var transaction = await _context.Database.BeginTransactionAsync();
			try
			{
				_context.Orders.Add(order);
				UpdateOrdersByCountriesCount(order);
				UpdateSalesByCategory(order);
				UpdateSalesByCountries(order);
				await _context.SaveChangesAsync();

				transaction.CommitAsync();
			}
			catch (Exception)
			{
				transaction.Rollback();
			}

			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(GetOrder),
			new
			{
				id = order.OrderId,
			}
			, order);
		}

		private async Task UpdateSalesByCountries(Order order)
		{
			var query = order.OrderDetails
				 .GroupBy(c => c.Order.Customer.Country)
				 .Select(c => new SalesByCountries
				 {
					 CountryName = c.Key,
					 Sales = c.Sum(c => c.UnitPrice * c.Quantity)
				 });
			foreach (var sbc in query)
			{
				var SalesByCountry = await _context.SalesByCountries
					.Where(c => c.CountryName == sbc.CountryName)
					.FirstOrDefaultAsync();
				if (SalesByCountry != null)
				{
					SalesByCountry.Sales = sbc.Sales;
				}
				else
				{
					SalesByCountries newsbc = new SalesByCountries
					{
						CountryName = sbc.CountryName,
						Sales = sbc.Sales
					};
					_context.SalesByCountries.Add(newsbc);
				}
			}
		}

		private async Task UpdateSalesByCategory(Order order)
		{
			var query = order.OrderDetails
				.GroupBy(c => c.Product.Category.CategoryName)
				.Select(c => new SalesByCategories
				{
					CategoryName = c.Key,
					Sales = c.Sum(c => c.UnitPrice * c.Quantity)
				});

			foreach (var sbc in query)
			{
				var SalesByCategory = await _context.SalesByCategories
					.Where(c => c.CategoryName == sbc.CategoryName)
					.FirstOrDefaultAsync();

				if (SalesByCategory != null)
				{
					SalesByCategory.Sales += sbc.Sales;
				}
				else
				{
					SalesByCategories newsbc = new SalesByCategories
					{
						CategoryName = sbc.CategoryName,
						Sales = sbc.Sales
					};
					_context.SalesByCategories.Add(newsbc);
				}
			}
		}

		private async Task UpdateOrdersByCountriesCount(Order order)
		{
			var OrdersByCountry = await _context.OrdersByCountries
				.Where(o => o.CountryName == order.Customer.Country)
				.FirstOrDefaultAsync();
			if (OrdersByCountry != null)
			{
				OrdersByCountry.OrdersCount++;
			}
			else
			{
				OrdersByCountry obc = new OrdersByCountry
				{
					CountryName = order.Customer.Country,
					OrdersCount = 1
				};
				_context.OrdersByCountries.Add(obc);
			}
		}

		[HttpPut]
		[Route("api/[controller]/PutOrder")]
		public async Task<IActionResult> PutOrder(int id, Order item)
		{
			if (id != item.OrderId)
			{
				return BadRequest();
			}
			_context.Entry(item).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return NoContent();
		}




		[HttpDelete]
		[Route("api/[controller]/DeleteOrder")]
		public async Task<IActionResult> DeleteOrder(int id)
		{
			var order = await _context.Orders.FindAsync(id);

			if (order == null)
			{
				return NotFound();
			}

			using (var transaction = _context.Database.BeginTransaction())
			{
				try
				{
					var details = _context.OrderDetails.Where(o => order.OrderId == id);
					_context.OrderDetails.RemoveRange(details);
					_context.Orders.Remove(order);
					await _context.SaveChangesAsync();
					await transaction.CommitAsync();
				}
				catch (Exception)
				{
					await transaction.RollbackAsync();
				}
			}

			return NoContent();
		}

		[HttpDelete]
		[Route("api/[controller]/DeleteOrders")]
		public async Task<IActionResult> DeleteOrdersRange(int[] range)
		{
			List<Order> orders = new List<Order>();
			List<OrderDetail> details = new List<OrderDetail>();

			foreach (int id in range)
			{
				var order = await _context.Orders.FindAsync(id);
				if (order != null) orders.Add(order);
			}

			if (orders.Count == 0) return NotFound();

			foreach (var item in orders)
			{
				var detail = _context.OrderDetails.Where(o => o.OrderId == item.OrderId) as OrderDetail;
				if (detail != null) details.Add(detail);
			}

			using (var transaction = _context.Database.BeginTransaction())
			{
				try
				{
					if (details.Count != 0) _context.OrderDetails.RemoveRange(details);
					_context.Orders.RemoveRange(orders);
					await transaction.CommitAsync();
				}
				catch (Exception)
				{
					await transaction.RollbackAsync();
				}
				await _context.SaveChangesAsync();
			}
			return NoContent();
		}
		private bool OrderExists(int id)
		{
			return _context.Orders.Any(e => e.OrderId == id);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Storage_Ovn11.Models;

namespace Storage_Ovn11.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Storage_Ovn11Context _context;

        public ProductsController(Storage_Ovn11Context context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,OrderDate,Category,Shelf,Count,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,OrderDate,Category,Shelf,Count,Description")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }















        


        // GET: Products/Summary
        public async Task<IActionResult> Summary()
        {
            var sum = 0;

            var products = await _context.Product.ToListAsync();

            IEnumerable<ProductViewModel> summary = new List<ProductViewModel>();

            summary = products.Select((a) =>
            {
                sum = sum + a.Price;
                return new ProductViewModel()
                {
                    Name = a.Name,
                    Count = a.Count,
                    Price = a.Price,
                    Sum = sum
                };
            });

            return View(summary);
        }

        // GET: Products/Electronics
        public IActionResult Electronics()
        {
            var model = _context.Product.Where(a => a.Category == "Electronics").ToList();
            return View(model);
        }

        // GET: Products/Electronics
        public IActionResult OutOfStock()
        {
            var model = _context.Product.Where(i => i.Count < 1).ToList();
            return View(model);
        }



        private List<SelectListItem> GetProducts(DbSet<Product> products)
        {
            return products.Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }).ToList();
        }

        private List<SelectListItem> GetCategories(DbSet<Product> products)
        {
            var res = new Dictionary<string, int>();

            var categories = products.GroupBy(a => a.Category).Select(
                b => new SelectListItem { Text = b.Key.ToString() }).ToList();

            var i = 0;
            categories.ForEach(a => a.Value = (i++).ToString());
            return categories;
        }

        // GET: Products/SearchView
        public IActionResult SearchView()
        {
            var model = new ProductSearchViewModel();
            model.ProductsResult = new List<Product>();
            model.Categories = GetCategories(_context.Product);

            model.Products = GetProducts(_context.Product);
            return View(model);
        }

        // POST: Products/SearchView
        [HttpPost, ActionName("SearchView")]
        [ValidateAntiForgeryToken]
        public IActionResult SearchView(ProductSearchViewModel productSearch)
        {
            if (ModelState.IsValid)
            {
                var categories = GetCategories(_context.Product);
                var category = categories.FirstOrDefault(b => b.Value == productSearch.CategoryId.ToString());

                var productSearchString = productSearch.SearchString;
                var products = GetProducts(_context.Product);
                var prod = products.FirstOrDefault(a => a.Value == productSearchString);

                var productItems = _context.Product;

                IQueryable<Product> res = productItems.Select((a) => a);
                if (prod != null)
                {
                    res = res.Where(a => a.Id.ToString() == prod.Value);
                }
                if (category != null)
                {
                    res = res.Where(a => a.Category == category.Text);
                }

                var result = new ProductSearchViewModel();
                result.ProductsResult = res.ToList();
                result.Categories = categories;
                result.Products = products;
                return View(result);
            }
            else
            {
                var res = new ProductSearchViewModel();
                res.ProductsResult = new List<Product>();
                res.Categories = GetCategories(_context.Product);
                res.Products = GetProducts(_context.Product);
                return View(res);
            }

            //return View(null);
        }
    }
}

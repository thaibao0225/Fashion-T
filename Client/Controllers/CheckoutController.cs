using Client.Data;
using Client.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Client.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly ApplicationDbContext _context;
        private ProductsService _products;
        private CartService _cartService;

        public CheckoutController(ILogger<CheckoutController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _products = new ProductsService(context);
            _cartService = new CartService(context);

        }

        // GET: CheckoutController
        [Route("/checkout")]
        [HttpGet("{couponCode}")]
        public async Task<ActionResult> Index(string couponCode)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            ViewBag.CountProductInCart = 0;
            if (userId.Any())
            {
                string cartId = await _cartService.GetCartId(userId.ToString());
                ViewBag.CountProductInCart = _cartService.CountProductInCart(cartId);
            }

            return View();
        }

        // GET: CheckoutController/Details/5
        public ActionResult Details(int id)
        {

            
            return View();
        }

        // GET: CheckoutController/Create
        public ActionResult Create()
        {
            return RedirectToAction(nameof(Index));
        }

        // POST: CheckoutController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                
                

                // Caculator
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckoutController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckoutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckoutController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckoutController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

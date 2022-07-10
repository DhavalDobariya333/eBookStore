using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly CartRepository _cartRepository = new CartRepository();


        //[HttpGet]
        //[Route("list")]
        //public IActionResult GetCartItem(string keyword)
        //{
        //    List<Cart> carts =  _cartRepository.GetCartItemsList(keyword);
        //    IEnumerable<CartModel> cartModel = carts.Select(c => new CartModel(c));
        //    return Ok(cartModel);
        //}
        [HttpGet]
        [Route("list")]
        public IActionResult GetCartItems(int UserId, int pageIndex = 1, int pageSize = 10)
        {
            ListResponse<Cart> carts = _cartRepository.GetCartItems(UserId, pageIndex, pageSize);
            ListResponse<GetCartModel> cartModels = new ListResponse<GetCartModel>()
            {
                Records = carts.Records.Select(c => new GetCartModel(c.Id, c.Userid, new BookModel(c.Book), c.Quantity)).ToList(),
                TotalRecords = carts.TotalRecords
            };
            return Ok(cartModels);
        }

        //[HttpPost]
        //[Route("add")]
        //[ProducesResponseType(typeof(CartModel), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        //public IActionResult AddCart(CartModel model)
        //{
        //    if (model == null)
        //        return BadRequest();

        //    Cart cart = new Cart()
        //    {
        //        Id = model.Id,
        //        Quantity = 1,
        //        Bookid = model.Bookid,
        //        Userid = model.Userid,
        //    };
        //    cart = _cartRepository.AddCart(cart);

        //    CartModel cartmodel = new CartModel(cart);

        //    return Ok(cartmodel);
        //}


        [HttpPost]
        [Route("add")]
        public ActionResult<CartModel> AddCart(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = 1,
                Bookid = model.Bookid,
                Userid = model.Userid
            };
            cart = _cartRepository.AddCart(cart);
            if (cart == null)
            {
                return StatusCode(500);
            }
            return new CartModel(cart);
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(CartModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateCart(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = model.Quantity,
                Bookid = model.Bookid,
                Userid = model.Userid,
            };
            cart = _cartRepository.UpdateCart(cart);

            return Ok(new CartModel(cart));
        }

        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public IActionResult DeleteCart(int id)
        {
            if (id == 0)
                return BadRequest("id is null");

            var response = _cartRepository.DeleteCart(id);
            return Ok(response);
        }


    }
}

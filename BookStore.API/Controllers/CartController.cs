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
    [Route("cart")]
    public class CartController : Controller
    {
        private readonly CartRepository _cartRepository = new CartRepository();

        [HttpGet]
        [Route("list")]
        public IActionResult GetCartItem(string keyword)
        {
            List<Cart> carts =  _cartRepository.GetCartItems(keyword);
            IEnumerable<CartModel> cartModel = carts.Select(c => new CartModel(c));
            return Ok(cartModel);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(CartModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddCart(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = 1,
                Bookid = model.Bookid,
                Userid = model.Userid,
            };
            cart = _cartRepository.AddCart(cart);

            CartModel cartmodel = new CartModel(cart);

            return Ok(cartmodel);
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

            CartModel cartmodel = new CartModel(cart);
            return Ok(cartmodel);
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

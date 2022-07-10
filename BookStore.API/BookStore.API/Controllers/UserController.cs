using Microsoft.AspNetCore.Mvc;
using BookStore.Repository;
using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookStore_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        UserRepository _repository = new UserRepository();
        
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_repository.GetUsers());
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel model)
        {
            User user = _repository.Login(model);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
        
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterModel model)
        {
            User user = _repository.Register(model);
            if (user == null)
                return BadRequest();

            return Ok(user);
        }

        //private readonly RoleRepository _roleRepository = new RoleRepository();

        //[HttpGet]
        //[Route("roles")]
        //public IActionResult GetRoles(string keyword)
        //{
        //    List<Role> roles = _roleRepository.GetRoles(keyword);
        //    IEnumerable<RoleModel> roleModel = roles.Select(c => new RoleModel(c));
        //    return Ok(roleModel);
        //}
    }
}

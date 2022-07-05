using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleRepository _roleRepository = new RoleRepository();

        [HttpGet]
        [Route("list")]
        public IActionResult GetRoles(string keyword)
        {
            List<Role> roles = _roleRepository.GetRoles(keyword);
            IEnumerable<RoleModel> roleModel = roles.Select(c => new RoleModel(c));
            return Ok(roleModel);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(RoleModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddRole(RoleModel model)
        {
            if (model == null)
                return BadRequest();

            Role role = new Role()
            {
                Id = model.Id,
                Name = model.Name,
            };
            role = _roleRepository.AddRole(role);

            RoleModel rolemodel = new RoleModel(role);

            return Ok(rolemodel);
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(RoleModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateRole(RoleModel model)
        {
            if (model == null)
                return BadRequest();

            Role role = new Role()
            {
                Id = model.Id,
                Name = model.Name,
            };
            role = _roleRepository.UpdateRole(role);

            RoleModel rolemodel = new RoleModel(role);
            return Ok(rolemodel);
        }

        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public IActionResult DeleteRole(int id)
        {
            if (id == 0)
                return BadRequest("Id is null");

            var response = _roleRepository.DeleteRole(id);
            return Ok(response);
        }
    }
}

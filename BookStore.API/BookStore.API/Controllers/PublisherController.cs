using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace BookStore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        PublisherRepository _publisherRepository = new PublisherRepository();

        [Route("list")]
        [HttpGet]
        [ProducesResponseType(typeof(ListResponse<PublisherModel>), (int)HttpStatusCode.OK)]
        public IActionResult GetPublishers(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {
            var publishers = _publisherRepository.GetPublishers(pageIndex, pageSize, keyword);
            ListResponse<PublisherModel> listResponse = new ListResponse<PublisherModel>()
            {
                Records = publishers.Records.Select(c => new PublisherModel(c)).ToList(),
                TotalRecords = publishers.TotalRecords,
            };

            return Ok(listResponse);
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(PublisherModel), (int)HttpStatusCode.OK)]
        public IActionResult GetPublishers(int id)
        {
            var category = _publisherRepository.GetPublisher(id);
            PublisherModel categoryModel = new PublisherModel(category);

            return Ok(categoryModel);
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(PublisherModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddPublishers(PublisherModel model)
        {
            if (model == null)
                return BadRequest("Model is null");

            Publisher category = new Publisher()
            {
                Id = model.Id,
                Name = model.Name,
            };

            var response = _publisherRepository.AddPublisher(category);
            PublisherModel categoryModel = new PublisherModel(response);

            return Ok(categoryModel);
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType(typeof(PublisherModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdatePublishers(PublisherModel model)
        {
            if (model == null)
                return BadRequest("Model is null");

            Publisher category = new Publisher()
            {
                Id = model.Id,
                Name = model.Name,
            };

            var response = _publisherRepository.UpdatePublisher(category);
            PublisherModel categoryModel = new PublisherModel(response);

            return Ok(categoryModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public IActionResult DeletePublishers(int id)
        {
            if (id == 0)
                return BadRequest("id is null");

            var response = _publisherRepository.DeletePublisher(id);
            return Ok(response);
        }

    }
}

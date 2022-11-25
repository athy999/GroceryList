using GroceryListBackEnd.Helpers;
using GroceryListBackEnd.Interface;
using GroceryListBackEnd.Models;
using GroceryListBackEnd.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryList.Controllers
{
    [Route("v1/api/GroceryList")]
    [ApiController]
    public class GroceryListController : ControllerBase
    {
        private readonly IGroceryItemService GroceryItemService;

        public GroceryListController()
        {
            GroceryItemService = new GroceryItemService();
        }

        // GET: api/<GroceryListController>
        [HttpGet]
        public ActionResult GetAll([FromQuery] string? keywords,
                                   [FromQuery] int pageNumber,
                                   [FromQuery] int pageSize)
        {
            var query = GroceryItemService.Get(keywords);
            var pagination = new Pagination();
            pagination.PageSize = pageSize;
            pagination.PageNumber = pageNumber;
            pagination.TotalCount = query.Count();

            var items = PageResult<GroceryItem>.ToPagedResult(pagination, query);
            var res = new PageResult<GroceryItem>(pagination, items);
            return Ok(res);
        }

        // GET api/<GroceryListController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var res = GroceryItemService.GetById(id);
            if (res == null) return BadRequest("Item not exist");
            return Ok(res);
        }

        // POST api/<GroceryListController>
        //return new item ID
        [HttpPost]
        public ActionResult Post([FromBody] GroceryItem itemNew)
        {
            var res = GroceryItemService.Post(itemNew);
            if (res == 0) return BadRequest("Item add fail");
            return Ok(res);
        }

        // PUT api/<GroceryListController>
        //return 1 for success, msg for failure
        [HttpPut]
        public ActionResult Put([FromBody] GroceryItem itemUpdate)
        {
            var res = GroceryItemService.Put(itemUpdate);
            if (res == 0) return BadRequest("Cannot find item or name is empty");
            var item = GroceryItemService.GetById(res);
            return Ok(item);
        }

        // DELETE api/<GroceryListController>/5
        //return 1 for sucess, 0 for fail
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var res = GroceryItemService.Delete(id);
            if (res == 0) return BadRequest("Cannot find item to delete");
            return Ok(res);
        }
    }
}

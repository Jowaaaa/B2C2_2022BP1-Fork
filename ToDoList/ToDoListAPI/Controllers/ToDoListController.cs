using Microsoft.AspNetCore.Mvc;
using ToDoListModel.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        // GET: api/<ToDoListController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await ToDoTask.ReadAll();
            return Ok(items);
        }

        // GET api/<ToDoListController>/5
        [HttpGet("{id}")]
        public ToDoTask Get(int id)
        {
            return ToDoTask.Read(id).Result; //Result voert async uit

            
        }

        // POST api/<ToDoListController>
        [HttpPost]
        public void Post([FromBody] string description)
        {
            ToDoTask newTask = new ToDoTask(description);
            newTask.Create();
        }

        // PUT api/<ToDoListController>/5
        [HttpPut("{idToFinish}")]
        public void Put(int idToFinish, [FromBody] string value)
        {
            var finishTask = ToDoTask.Read(idToFinish).Result;

            finishTask.FinishTask();
        }

        // DELETE api/<ToDoListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleteTask = ToDoTask.Read(id).Result;
            deleteTask.Delete();
        }
    }
}

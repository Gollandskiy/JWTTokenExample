using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace JWTTokenExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private static List<string> _todos = new List<string>();

        [HttpGet]
        [Authorize] // Требуется аутентификация
        public ActionResult<IEnumerable<string>> Get()
        {
            return _todos;
        }

        [HttpGet("{id}")]
        [Authorize] // Требуется аутентификация
        public ActionResult<string> Get(int id)
        {
            if (id >= 0 && id < _todos.Count)
            {
                return _todos[id];
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize] // Требуется аутентификация
        public ActionResult Post([FromBody] string todo)
        {
            _todos.Add(todo);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize] // Требуется аутентификация
        public ActionResult Put(int id, [FromBody] string todo)
        {
            if (id >= 0 && id < _todos.Count)
            {
                _todos[id] = todo;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [Authorize] // Требуется аутентификация
        public ActionResult Delete(int id)
        {
            if (id >= 0 && id < _todos.Count)
            {
                _todos.RemoveAt(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
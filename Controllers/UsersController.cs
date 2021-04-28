using InexikaTaskServer.BusinessLogic;
using InexikaTaskServer.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InexikaTaskServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly ITaskworkLogic _tw;
        public UsersController(ITaskworkLogic taskwork)
        {
            _tw = taskwork;
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(int id)
        {
            return _tw.GetUser(id);
        }
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            return _tw.GetUsers();
        }
    }
}

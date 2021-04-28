using InexikaTaskServer.BusinessLogic;
using InexikaTaskServer.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InexikaTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorktasksController : ControllerBase
    {
        private readonly ITaskworkLogic _tw;
        public WorktasksController(ITaskworkLogic taskworkLogic)
        {
            _tw = taskworkLogic;
        }
        [HttpGet("{id}")]
        public ActionResult<WorktaskDto> GetTask(string id, int userId)
        {
            var task = _tw.GetWorktaskById(id, userId);
            if (task != null)
            {
                return task;
            }

            return NoContent();
        }
        [HttpGet]
        public ActionResult<IEnumerable<WorktaskDto>> GetTasks(int? userId, string textToSearch)
        {
            if (userId != null) {
                return _tw.GetWorktasks((int)userId, textToSearch);
            }

            return Unauthorized();
        }
        [HttpPost]
        public ActionResult CreateTask(WorktaskDto worktaskDto)
        {
            var result = _tw.CreateWorktask(worktaskDto);

            return result ? Ok() : ValidationProblem("Значение ID должно быть уникальным");
        }
        [HttpPut]
        public void UpdateWorktask(WorktaskDto worktaskDto)
        {
            _tw.UpdateWorktask(worktaskDto);
        }
        [HttpDelete("{id}")]
        public void DeleteWorktask(string id)
        {
            _tw.DeleteWorktask(id);
        }
        [HttpPost]
        public void CreateComment(CommentDto commentDto)
        {
            _tw.CreateComment(commentDto);
        }
        //public WorktasksController(WorktaskDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Worktasks
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Worktask>>> GetWorktasks()
        //{

        //    return await _context.Worktasks.ToListAsync();
        //}

        // GET: api/Worktasks/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Worktask>> GetWorktask(int id)
        //{
        //    var worktask = await _context.Worktasks.FindAsync(id);

        //    if (worktask == null)
        //    {
        //        return NotFound();
        //    }

        //    return worktask;
        //}

        //// PUT: api/Worktasks/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutWorktask(int id, Worktask worktask)
        //{
        //    if (id != worktask.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(worktask).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!WorktaskExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Worktasks
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public void CreateTask()
        ////public async Task<ActionResult<Worktask>> PostWorktask(Worktask worktask)
        ////{
        ////    _context.Worktasks.Add(worktask);
        ////    try
        ////    {
        ////        await _context.SaveChangesAsync();
        ////    }
        ////    catch (DbUpdateException)
        ////    {
        ////        if (WorktaskExists(worktask.ID))
        ////        {
        ////            return Conflict();
        ////        }
        ////        else
        ////        {
        ////            throw;
        ////        }
        ////    }

        ////    return CreatedAtAction(nameof(GetWorktask), new { id = worktask.ID }, worktask);
        ////}

        //// DELETE: api/Worktasks/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteWorktask(int id)
        //{
        //    var worktask = await _context.Worktasks.FindAsync(id);
        //    if (worktask == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Worktasks.Remove(worktask);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool WorktaskExists(int id)
        //{
        //    return _context.Worktasks.Any(e => e.ID == id);
        //}
    }
}

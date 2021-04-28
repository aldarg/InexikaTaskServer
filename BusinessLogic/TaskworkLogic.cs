using InexikaTaskServer.DataAccess;
using InexikaTaskServer.Contracts;
using InexikaTaskServer.DataAccess.Repository;
using InexikaTaskServer.DataAccess.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace InexikaTaskServer.BusinessLogic
{
    public class TaskworkLogic : ITaskworkLogic
    {
        private readonly WorktaskDbContext _db;
        public TaskworkLogic(WorktaskDbContext db)
        {
            _db = db;
        }
        public UserDto GetUser(int id)
        {
            var uow = new UnitOfWork(_db);
            var employeeRepo = uow.GetRepository<IEmployeeRepository>();
            var employee = employeeRepo.GetById(id);

            return employee.ToUserDto();
        }
        public List<UserDto> GetUsers()
        {
            var uow = new UnitOfWork(_db);
            var employeeRepo = uow.GetRepository<IEmployeeRepository>();
            var employees = employeeRepo.GetAllWithRoles();

            var result = employees.Select(e => e.ToUserDto()).ToList();

            return result;
        }
        public WorktaskDto GetWorktaskById(string id, int userId)
        {
            var uow = new UnitOfWork(_db);
            var worktaskRepo = uow.GetRepository<IWorktaskRepository>();
            var accessRepo = uow.GetRepository<IStatusAccessRepository>();
            var employeeRepo = uow.GetRepository<IEmployeeRepository>();

            var employee = employeeRepo.GetById(userId);
            var worktask = worktaskRepo.GetWorktaskWithAccesses(id, employee);

            return worktask.ToWorktaskDto();
        }
        public List<WorktaskDto> GetWorktasks(int userId, string textToSearch)
        {
            var uow = new UnitOfWork(_db);
            var worktaskRepo = uow.GetRepository<IWorktaskRepository>();
            var employeeRepo = uow.GetRepository<IEmployeeRepository>();
            var accessRepo = uow.GetRepository<IStatusAccessRepository>();

            var employee = employeeRepo.GetById(userId);
            var accesses = accessRepo.GetAccesses(employee.RoleID, new string[] { "Read" });
            var worktasks = worktaskRepo.GetAllWorktasks(employee, accesses, textToSearch);

            var result = worktasks.Select(wt => wt.ToWorktaskDto()).ToList();

            return result;
        }
        public bool CreateWorktask(WorktaskDto worktaskDto)
        {
            var uow = new UnitOfWork(_db);
            var worktaskRepo = uow.GetRepository<IWorktaskRepository>();
            var worktask = worktaskDto.FromWorktaskDto();
            if (worktask.StatusId == null)
            {
                worktask.StatusId = "Created";
            }
            var isAdded = worktaskRepo.CreateTask(worktask);

            if (!isAdded)
            {
                return false;
            }
            
            uow.Save();
            return true;
        }
        public void UpdateWorktask(WorktaskDto worktaskDto)
        {
            var uow = new UnitOfWork(_db);
            var worktaskRepo = uow.GetRepository<IWorktaskRepository>();
            var worktask = worktaskDto.FromWorktaskDto();
            var worktaskRecord = worktaskRepo.GetTaskById(worktask.ID);
            if (worktaskRecord != null)
            {
                worktaskRecord.EditorId = worktask.EditorId;
                worktaskRecord.StatusId = worktask.StatusId;
                worktaskRecord.UpdateDate = worktask.UpdateDate;
                worktaskRecord.Subject = worktask.Subject;
                worktaskRecord.Text = worktask.Text;
            }
            uow.Save();
        }
        public void DeleteWorktask(string id)
        {
            var uow = new UnitOfWork(_db);
            var worktaskRepo = uow.GetRepository<IWorktaskRepository>();
            worktaskRepo.DeleteTask(id);
            uow.Save();
        }
        public void CreateComment(CommentDto commentDto)
        {
            var uow = new UnitOfWork(_db);
            var commentRepo = uow.GetRepository<ICommentRepository>();
            commentRepo.Create(commentDto.FromCommentDto());
            uow.Save();
        }
    }
}

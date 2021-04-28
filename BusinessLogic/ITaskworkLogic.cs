using InexikaTaskServer.Contracts;
using System.Collections.Generic;

namespace InexikaTaskServer.BusinessLogic
{
    public interface ITaskworkLogic
    {
        UserDto GetUser(int id);
        List<UserDto> GetUsers();
        WorktaskDto GetWorktaskById(string id, int userId);
        List<WorktaskDto> GetWorktasks(int userId, string find);
        bool CreateWorktask(WorktaskDto worktaskDto);
        void UpdateWorktask(WorktaskDto worktaskDto);
        void DeleteWorktask(string id);
        void CreateComment(CommentDto commentDto);
    }
}

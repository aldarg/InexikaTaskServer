using InexikaTaskServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InexikaTaskServer.Contracts
{
    public static class MappingExtensions
    {
        public static UserDto ToUserDto(this Employee employee)
        {
            return new UserDto
            {
                Id = employee.EmployeeId,
                Name = employee.FIO,
                Role = employee.Role.Name,
                CanCreate = employee.Role.StatusAccesses.Any(a => a.AccessType.Name == "Create"),
            };
        }
        public static WorktaskDto ToWorktaskDto(this Worktask worktask)
        {
            return new WorktaskDto
            {
                TaskId = worktask.ID,
                StatusId = worktask.StatusId,
                StatusName = worktask.Status.Name,
                Subject = worktask.Subject,
                Text = worktask.Text,
                AuthorId = worktask.AuthorId,
                AuthorName = worktask.Author.FIO,
                EditorId = worktask.EditorId,
                EditorName = worktask.Editor.FIO,
                CreateDate = worktask.CreateDate.ToString("yyyy-MM-dd"),
                UpdateDate = worktask.UpdateDate.ToString("yyyy-MM-dd"),
                CommentCount = worktask.Comments.Count,
                CanBeDeleted = worktask.Status.WorktaskAccesses.Any(a => a.AccessType.Name == "Delete"),
                CanBeEdited = worktask.Status.WorktaskAccesses.Any(a => a.AccessType.Name == "Edit"),
                CanTransitToStatuses = worktask.Status.FromStatusRoutes
                    .Select(r => new Transition { Status = r.ToStatusId, NeedComment = r.NeedComment }).ToArray(),
                Comments = worktask.Comments.Select(c => c.ToCommentDto()).ToArray(),
            };
        }
        public static Worktask FromWorktaskDto(this WorktaskDto worktaskDto)
        {
            return new Worktask
            {
                ID = worktaskDto.TaskId,
                StatusId = worktaskDto.StatusId,
                Subject = worktaskDto.Subject,
                Text = worktaskDto.Text,
                AuthorId = worktaskDto.AuthorId,
                EditorId = worktaskDto.EditorId == 0 ? worktaskDto.AuthorId : worktaskDto.EditorId,
                CreateDate = worktaskDto.CreateDate == null ? DateTime.Now : DateTime.Parse(worktaskDto.CreateDate),
                UpdateDate = DateTime.Now,
            };
        }
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.ID,
                AuthorId = comment.AuthorId,
                AuthorName = comment.Author.FIO,
                CreateDate = comment.CreateDate.ToString("dd-MM-yyyy"),
                Text = comment.Text,
            };
        }
        public static Comment FromCommentDto(this CommentDto commentDto)
        {
            return new Comment
            {
                ID = commentDto.Id,
                AuthorId = commentDto.AuthorId,
                Text = commentDto.Text,
                CreateDate = commentDto.CreateDate == null ? DateTime.Now : DateTime.Parse(commentDto.CreateDate),
                WorktaskId = commentDto.TaskId,
            };
        }
    }
}

using InexikaTaskServer.Models;
using System;
using System.Linq;

namespace InexikaTaskServer.DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(WorktaskDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Worktasks.Any())
            {
                return;
            }

            var roles = new Role[]
            {
                new Role
                {
                    Name="Оператор"
                },
                new Role
                {
                    Name="Менеджер",
                },
                new Role
                {
                    Name="Исполнитель",
                },
                new Role
                {
                    Name="Администратор",
                },
            };

            context.Roles.AddRange(roles);
            context.SaveChanges();

            var employees = new Employee[]
            {
                new Employee{FIO="Петров Петр", RoleID=1},
                new Employee{FIO="Иванов Иван", RoleID=2},
                new Employee{FIO="Сергеев Сергей", RoleID=3},
                new Employee{FIO="Дмитриев Дмитрий", RoleID=4}
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();

            var statuses = new Status[]
            {
                new Status{ID="New", Name="Новая"},
                new Status{ID="Created", Name="Черновик"},
                new Status{ID="Completed", Name="Выполнено"},
                new Status{ID="Accepted", Name="В обработке"},
                new Status{ID="Clarified", Name="На согласовании"},
                new Status{ID="Declined", Name="Отклонено"}
            };

            context.WorktaskStatuses.AddRange(statuses);
            context.SaveChanges();

            var routes = new StatusRoute[]
            {
                new StatusRoute{FromStatusId="Created", ToStatusId="Accepted"},
                new StatusRoute{FromStatusId="Created", ToStatusId="Declined",NeedComment=true},
                new StatusRoute{FromStatusId="Accepted", ToStatusId="Completed"},
                new StatusRoute{FromStatusId="Accepted", ToStatusId="Clarified",NeedComment=true},
            };

            context.StatusRoutes.AddRange(routes);
            context.SaveChanges();

            var tasks = new Worktask[]
            {
                new Worktask
                {
                    ID = "1",
                    StatusId = "Created",
                    Subject = "test",
                    Text = "test",
                    AuthorId = 1,
                    EditorId = 1,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                },
                new Worktask
                {
                    ID = "2",
                    StatusId = "Completed",
                    Subject = "test",
                    Text = "test",
                    AuthorId = 1,
                    EditorId = 1,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                },
                new Worktask
                {
                    ID = "3",
                    StatusId = "Accepted",
                    Subject = "test",
                    Text = "test",
                    AuthorId = 1,
                    EditorId = 1,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                },
                new Worktask
                {
                    ID = "4",
                    StatusId = "Declined",
                    Subject = "test",
                    Text = "test",
                    AuthorId = 1,
                    EditorId = 1,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                },
            };
            context.Worktasks.AddRange(tasks);
            context.SaveChanges();

            var accessTypes = new AccessType[]
            {
                new AccessType {Name="Create"},
                new AccessType {Name="Read"},
                new AccessType {Name="Edit"},
                new AccessType {Name="Delete"},
            };

            context.AccessTypes.AddRange(accessTypes);
            context.SaveChanges();

            var accesses = new StatusAccess[]
            {
                new StatusAccess
                {
                    RoleID=1,
                    AccessTypeId=accessTypes.Single(a => a.Name == "Create").ID,
                    OnlyAuthored=false,
                    StatusId=statuses.Single(o => o.ID == "New").ID,
                },
                new StatusAccess
                {
                    RoleID=1,
                    AccessTypeId=accessTypes.Single(a => a.Name == "Read").ID,
                    OnlyAuthored=true,
                    StatusId=statuses.Single(o => o.ID == "Created").ID,
                },
                new StatusAccess
                {
                    RoleID=2,
                    AccessTypeId=accessTypes.Single(a => a.Name == "Read").ID,
                    OnlyAuthored=false,
                    StatusId=statuses.Single(o => o.ID == "Created").ID,
                },
                new StatusAccess
                {
                    RoleID=2,
                    AccessTypeId=accessTypes.Single(a => a.Name == "Read").ID,
                    OnlyAuthored=false,
                    StatusId=statuses.Single(o => o.ID == "Clarified").ID,
                },
                new StatusAccess
                {
                    RoleID=2,
                    AccessTypeId=accessTypes.Single(a => a.Name == "Edit").ID,
                    OnlyAuthored=false,
                    StatusId=statuses.Single(o => o.ID == "Created").ID,
                },
                new StatusAccess
                {
                    RoleID=3,
                    AccessTypeId=accessTypes.Single(a => a.Name == "Read").ID,
                    OnlyAuthored=false,
                    StatusId=statuses.Single(o => o.ID == "Accepted").ID,
                },
                new StatusAccess
                {
                    RoleID=4,
                    AccessTypeId=accessTypes.Single(a => a.Name == "Read").ID,
                    OnlyAuthored=false,
                    StatusId=statuses.Single(o => o.ID == "Accepted").ID,
                },
                new StatusAccess
                {
                    RoleID=4,
                    AccessTypeId=accessTypes.Single(a => a.Name == "Read").ID,
                    OnlyAuthored=false,
                    StatusId=statuses.Single(o => o.ID == "Declined").ID,
                },
                new StatusAccess
                {
                    RoleID=4,
                    AccessTypeId=accessTypes.Single(a => a.Name == "Read").ID,
                    OnlyAuthored=false,
                    StatusId=statuses.Single(o => o.ID == "Completed").ID,
                },
                new StatusAccess
                {
                    RoleID=4,
                    AccessTypeId=accessTypes.Single(a => a.Name == "Read").ID,
                    OnlyAuthored=false,
                    StatusId=statuses.Single(o => o.ID == "Clarified").ID,
                },
                new StatusAccess
                {
                    RoleID=4,
                    AccessTypeId=accessTypes.Single(a => a.Name == "Read").ID,
                    OnlyAuthored=false,
                    StatusId=statuses.Single(o => o.ID == "Created").ID,
                },
                new StatusAccess
                {
                    RoleID=1,
                    AccessTypeId=accessTypes.Single(a => a.Name == "Edit").ID,
                    OnlyAuthored=true,
                    StatusId=statuses.Single(o => o.ID == "Created").ID,
                },
                new StatusAccess
                {
                    RoleID=4,
                    AccessTypeId=accessTypes.Single(a => a.Name == "Delete").ID,
                    OnlyAuthored=false,
                    StatusId=statuses.Single(o => o.ID == "Completed").ID,
                },
                new StatusAccess
                {
                    RoleID=4,
                    AccessTypeId=accessTypes.Single(a => a.Name == "Delete").ID,
                    OnlyAuthored=false,
                    StatusId=statuses.Single(o => o.ID == "Declined").ID,
                },
            };

            context.WorktaskAccesses.AddRange(accesses);
            context.SaveChanges();

            var routeAccesses = new StatusRouteAccess[]
            {
                new StatusRouteAccess
                {
                    RoleId = roles.Single(r => r.Name == "Менеджер").ID,
                    StatusRouteId = 3,
                },
                new StatusRouteAccess
                {
                    RoleId = roles.Single(r => r.Name == "Менеджер").ID,
                    StatusRouteId = 4,
                },
                new StatusRouteAccess
                {
                    RoleId = roles.Single(r => r.Name == "Исполнитель").ID,
                    StatusRouteId = 1,
                },
                new StatusRouteAccess
                {
                    RoleId = roles.Single(r => r.Name == "Исполнитель").ID,
                    StatusRouteId = 2,
                },
            };

            context.StatusRouteAccesses.AddRange(routeAccesses);
            context.SaveChanges();

            var comments = new Comment[]
            {
                new Comment {AuthorId=1,CreateDate=DateTime.Now, Text="bla", WorktaskId="1"},
                new Comment {AuthorId=2,CreateDate=DateTime.Now, Text="bla", WorktaskId="1"},
                new Comment {AuthorId=3,CreateDate=DateTime.Now, Text="bla", WorktaskId="2"},
                new Comment {AuthorId=4,CreateDate=DateTime.Now, Text="bla", WorktaskId="3"},
            };

            context.Comments.AddRange(comments);
            context.SaveChanges();
        }
    }
}
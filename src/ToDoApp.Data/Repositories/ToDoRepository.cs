using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;
using ToDoApp.Domain.Repositories;
using Dapper;

namespace ToDoApp.Data.Repositories
{
    internal class ToDoRepository : RepositoryBase, IToDoRepository
    {
        public ToDoRepository(IConfigurationRoot configuration) : base(configuration)
        {
        }

        public ToDo Create(ToDo todo)
        {
            todo.Id = connection.QueryFirst<int>("exec todo_sp_create @Text, @IsCompleted", todo);
            return todo;
        }

        public bool Delete(int id)
        {
            var affectedRows = connection.Execute("exec todo_sp_delete @Id", new { Id = id });
            return affectedRows > 0;
        }

        public ToDo GetById(int id)
        {
            var result = connection.QueryFirstOrDefault<ToDo>("exec todo_sp_get @Id", new { Id = id });
            return result;
        }

        public IEnumerable<ToDo> List(ToDoFilter filter)
        {
            var result = connection.Query<ToDo>("exec todo_sp_list @Id, @Text, @IsCompleted", filter);
            return result;
        }

        public bool Update(ToDo todo)
        {
           var affectedRows = connection.Execute("exec todo_sp_update @Id, @Text, @IsCompleted", todo);
           return affectedRows > 0;
        }
    }
}

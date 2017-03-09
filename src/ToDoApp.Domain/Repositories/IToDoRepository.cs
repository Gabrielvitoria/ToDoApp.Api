using System.Collections.Generic;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;

namespace ToDoApp.Domain.Repositories
{
    public interface IToDoRepository
    {
        ToDo Create(ToDo todo);
        IEnumerable<ToDo> List(ToDoFilter filter);
        ToDo GetById(int id);
        bool Update(ToDo todo);
        bool Delete(int id);
    }
}

using System.Collections.Generic;
using ToDoApp.AppServices.Dtos;

namespace ToDoApp.AppServices.Interfaces
{
    public interface IToDoAppService
    {
        ToDoDto Create(ToDoDto todo);
        IEnumerable<ToDoDto> List(ToDoFilterDto filter);
        ToDoDto GetById(int id);
        bool Update(ToDoDto todo);
        bool Delete(int id);
    }
}

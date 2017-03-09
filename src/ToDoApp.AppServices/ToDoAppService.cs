using System.Collections.Generic;
using ToDoApp.AppServices.Dtos;
using ToDoApp.AppServices.Interfaces;
using ToDoApp.AppServices.Extensions;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;
using ToDoApp.DomainServices.Interfaces;

namespace ToDoApp.AppServices
{
    public class ToDoAppService : IToDoAppService
    {
        private readonly IToDoDomainService service;

        public ToDoAppService(IToDoDomainService service)
        {
            this.service = service;
        }
        public ToDoDto Create(ToDoDto todo)
        {
            var result = service.Create(todo.MapTo<ToDo>());
            return result.MapTo<ToDoDto>();
        }

        public bool Delete(int id)
        {
            return service.Delete(id);
        }

        public ToDoDto GetById(int id)
        {
            return service.GetById(id).MapTo<ToDoDto>();
        }

        public IEnumerable<ToDoDto> List(ToDoFilterDto filter)
        {
            return service.List(filter.MapTo<ToDoFilter>()).EnumerableTo<ToDoDto>();
        }

        public bool Update(ToDoDto todo)
        {
            return service.Update(todo.MapTo<ToDo>());
        }
    }
}

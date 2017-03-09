using System.Collections.Generic;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;
using ToDoApp.Domain.Repositories;
using ToDoApp.DomainServices.Interfaces;

namespace ToDoApp.DomainServices
{
    public class ToDoDomainService : IToDoDomainService
    {
        private readonly IToDoRepository repository;

        public ToDoDomainService(IToDoRepository repository)
        {
            this.repository = repository;
        }
        public ToDo Create(ToDo todo)
        {
            return repository.Create(todo);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public ToDo GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<ToDo> List(ToDoFilter filter)
        {
            return repository.List(filter);
        }

        public bool Update(ToDo todo)
        {
            return repository.Update(todo);
        }
    }
}

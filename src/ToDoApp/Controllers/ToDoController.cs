using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.AppServices.Dtos;
using ToDoApp.AppServices.Interfaces;
using ToDoApp.Extensions;
using ToDoApp.Validators;
using System;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private readonly IToDoAppService appService;
        private readonly ToDoValidator validator;

        public ToDoController(IToDoAppService appService, ToDoValidator validator)
        {
            this.appService = appService;
            this.validator = validator;
        }
        // GET: api/ToDo
        [HttpGet]
        public Results.GenericResult<IEnumerable<ToDoDto>> Get([FromQuery]ToDoFilterDto filter)
        {
            var result = new Results.GenericResult<IEnumerable<ToDoDto>>();

            try
            {
                result.Result = appService.List(filter);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }
            return result;
        }

        // GET api/ToDo/5
        [HttpGet("{id}")]
        public Results.GenericResult<ToDoDto> Get(int id)
        {
            var result = new Results.GenericResult<ToDoDto>();

            try
            {
                result.Result = appService.GetById(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }
            return result;
        }

        // POST api/ToDo
        [HttpPost]
        public Results.GenericResult<ToDoDto> Post([FromBody]ToDoDto model)
        {
            var result = new Results.GenericResult<ToDoDto>();

            var validatorResult = validator.Validate(model);
            if (validatorResult.IsValid)
            {
                try
                {
                    result.Result = appService.Create(model);
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Errors = new string[] { ex.Message };
                }
            }
            else
                result.Errors = validatorResult.GetErrors();

            return result; 
        }

        // PUT api/ToDo/5
        [HttpPut("{id}")]
        public Results.GenericResult Put(int id, [FromBody]ToDoDto model)
        {
            var result = new Results.GenericResult();

            var validatorResult = validator.Validate(model);
            if (validatorResult.IsValid)
            {
                try
                {
                    result.Success = appService.Update(model);
                    if (!result.Success)
                        throw new Exception($"Todo {id} can't be updated");
                }
                catch (Exception ex)
                {
                    result.Errors = new string[] { ex.Message };
                }
            }
            else
                result.Errors = validatorResult.GetErrors();

            return result;
        }

        // DELETE api/ToDo/5
        [HttpDelete("{id}")]
        public Results.GenericResult Delete(int id)
        {
            var result = new Results.GenericResult();
            try
            {
                result.Success = appService.Delete(id);
                if (!result.Success)
                    throw new Exception($"Todo {id} can't be deleted");
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }
    }
}

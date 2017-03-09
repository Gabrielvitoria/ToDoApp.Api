using System;
using System.Collections.Generic;
using ToDoApp.Data.Repositories;
using ToDoApp.Domain.Repositories;

namespace ToDoApp.Data.IoC
{
    public static class Module
    {
        public static Dictionary<Type,Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>();

            dic.Add(typeof(IToDoRepository), typeof(ToDoRepository));

            return dic;
        }
    }
}

using System;
using System.Collections.Generic;
using ToDoApp.AppServices.Interfaces;

namespace ToDoApp.AppServices.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>();

            dic.Add(typeof(IToDoAppService), typeof(ToDoAppService));

            return dic;
        }
    }
}

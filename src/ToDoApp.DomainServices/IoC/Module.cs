using System;
using System.Collections.Generic;
using ToDoApp.DomainServices.Interfaces;

namespace ToDoApp.DomainServices.IoC
{
    public class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>();

            dic.Add(typeof(IToDoDomainService), typeof(ToDoDomainService));

            return dic;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Filters
{
    public class ToDoFilter
    {
        public int? Id { get; set; }
        public string Text { get; set; }
        public bool isCompleted { get; set; }
    }
}

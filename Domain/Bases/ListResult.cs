using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication13.Domain.Bases
{
    public class ListResult<T>
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
    }
}

using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class ResponseResult<T> : IResponseResult<T>
    {
        public long Count { get; set; } 
        public string Message { get; set; } 
        public string SearchCriteria { get; set; }
        public T Results { get; set; }
    }
}

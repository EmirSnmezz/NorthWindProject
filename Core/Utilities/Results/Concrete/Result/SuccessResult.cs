using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete.Result
{
    public class SuccessResult : IResult
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}

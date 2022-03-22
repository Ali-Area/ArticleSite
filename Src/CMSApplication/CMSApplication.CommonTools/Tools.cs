using CMSApplication.CommonTools.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApplication.CommonTools
{
    public static class Tools
    {
        public static ResultDto<T> ReturnResult<T>(bool isSuccess, string message, T data)
        {
            return new ResultDto<T>()
            {
                IsSuccess = isSuccess,
                Message = message,
                Data = data
            };
        }

        public static ResultDto ReturnResult(bool isSuccess, string message)
        {
            return new ResultDto()
            {
                IsSuccess = isSuccess,
                Message = message
            };
        }
    }
}

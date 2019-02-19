using System;

namespace Common.Standard
{
    public class Result
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public Result() { }
        public Result(int code, string msg)
        {
            this.Code = code;
            this.Message = msg;
        }

        public Result(int code)
        {
            this.Code = code;
            this.Message = Enum.GetName(typeof(Status), code);
        }
    }
    public class ResultData : Result
    {
        public object Data { get; set; }

        public ResultData() { }
        /// <summary>
        /// 返回带数据的结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        public ResultData(int code, string msg, object data)
        {
            this.Code = code;
            this.Message = msg;
            this.Data = data;
        }

        public ResultData(int code, object data)
        {
            this.Code = code;
            this.Message = Enum.GetName(typeof(Status), code);
            this.Data = data;
        }
    }
    public class PagingResult : ResultData
    {
        public int Total { get; set; }

        public PagingResult(int code, string msg, object data, int total)
        {
            this.Code = code;
            this.Message = msg;
            this.Data = data;
            this.Total = total;
        }
    }
    /// <summary>
    /// 错误码枚举
    /// </summary>
    public enum Status
    {
        ServerError = -1,
        Fail = -2,
        Success = 0,
        TokenExpired = 100,
        ParameterInvalid = 101
    }
}

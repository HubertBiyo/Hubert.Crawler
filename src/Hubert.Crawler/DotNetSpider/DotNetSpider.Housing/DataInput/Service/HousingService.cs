using Common.Log;
using Common.Standard;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetSpider.Housing.DataInput.Service
{
  public  class HousingService
    {
        public Result AddHousingPrice(Housing model)
        {
            try
            {
                if (model == null)
                    return new Result((int)Status.ParameterInvalid, "参数错误");
                var result = Data.DataProviders.HousingDataProvider.AddHousingPrice(model);
                if (result)
                    return new Result((int)Status.Success, "创建成功");
                return new Result((int)Status.Fail, "创建失败");
            }
            catch (Exception ex)
            {
                Logger.Error("InsertGraceful is error", GetType(), ex);
                return new Result((int)Status.ServerError, "服务器异常");
            }
        }

        private HousingService() { }
        public static HousingService Instance { get; } = new HousingService();
    }
}

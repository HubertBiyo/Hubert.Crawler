using Common.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetSpider.Housing.DataInput.Data
{
    public class DataProviders
    {
        internal static string MainConnectionString_ReadOnly
        {
            get
            {
                string connectionString = ConfigHelper.GetString("AppSettings:MysqlConnectionString:ConnectionString");
                return connectionString;
            }
        }

        internal static string MainConnectionString_ReadWrite
        {
            get
            {
                string connectionString = ConfigHelper.GetString("AppSettings:MysqlConnectionString:ConnectionString");
                return connectionString;
            }
        }

        public static IHousingDataProvider HousingDataProvider
        {
            get { return Get<IHousingDataProvider, HousingDataProvider>(); }
        }
        private static U Get<T, U>()
           where T : IDataProvider
           where U : IDataProvider
        {
            Type internalType = typeof(T);
            Type classType = typeof(U);
            U instance;
            lock (_instanceDic)
            {
                if (_instanceDic.ContainsKey(internalType))
                {
                    instance = (U)_instanceDic[internalType];
                }
                else
                {
                    instance = (U)Activator.CreateInstance(classType);
                    _instanceDic.Add(internalType, instance);
                }
            }
            return instance;
        }
        static DataProviders()
        {
            _instanceDic = new Dictionary<Type, object>();
        }
        private static readonly Dictionary<Type, object> _instanceDic;
    }
}

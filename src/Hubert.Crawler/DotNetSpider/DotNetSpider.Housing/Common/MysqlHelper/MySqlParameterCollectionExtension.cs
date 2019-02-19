using MySql.Data.MySqlClient;
using System;

namespace Common.MysqlHelper
{
    public static class MySqlParameterCollectionExtension
    {
        public static void AddWithNullableValue(this MySqlParameterCollection collection, string parameterName, object value)
        {
            if (value == null)
            {
                collection.AddWithValue(parameterName, DBNull.Value);
                return;
            }

            var type = value.GetType();
            var defaultValue = type.IsValueType ? Activator.CreateInstance(type) : null;
            collection.AddWithValue(parameterName, value.Equals(defaultValue) ? DBNull.Value : value);
        }
    }
}

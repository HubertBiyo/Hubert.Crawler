using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Common.MysqlHelper
{
    public class MysqlExecutor : IDisposable
    {
        public int ExecuteNonQuery(MySqlCommand cmd, string connectionString)
        {
            return (int)CommandExecute(cmd, connectionString, CommandExecuteType.NonQuery);
        }

        public MySqlDataReader ExecuteReader(MySqlCommand cmd, string connectionString)
        {
            return (MySqlDataReader)CommandExecute(cmd, connectionString, CommandExecuteType.DataReader);
        }

        public TValue ExecuteScalar<TValue>(MySqlCommand cmd, string connectionString)
        {
            object result = CommandExecute(cmd, connectionString, CommandExecuteType.Scalar);
            if (result == DBNull.Value)
            {
                result = null;
            }

            //先尝试强制类型转换，如果遇到值类型失败了，则尝试用 Convert 转换，如果再失败则正常抛出异常
            try
            {
                return (TValue)result;
            }
            catch
            {
                return (TValue)Convert.ChangeType(result, typeof(TValue));
            }
        }

        #region Close & Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    Close();
                }
                _isDisposed = true;
            }
        }

        public void Close()
        {
            if (_currentSqlDataReader != null)
            {
                _currentSqlDataReader.Close();
                _currentSqlDataReader.Dispose();
                _currentSqlDataReader = null;
            }

            if (_currentSqlCommand != null)
            {
                _currentSqlCommand.Dispose();
                _currentSqlCommand = null;
            }

            if (_currentSqlConnection != null)
            {
                _currentSqlConnection.Close();
                _currentSqlConnection.Dispose();
                _currentSqlConnection = null;
            }
        }

        #endregion

        #region Private

        private object CommandExecute(MySqlCommand cmd, string cs, CommandExecuteType type)
        {
            object result;
            _currentSqlCommand = cmd;
            _currentSqlConnection = SetSqlConnection(cmd, cs);

            _currentSqlConnection.Open();

            switch (type)
            {
                case CommandExecuteType.DataReader:
                    _currentSqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    result = _currentSqlDataReader;
                    break;
                case CommandExecuteType.NonQuery:
                    result = cmd.ExecuteNonQuery();
                    break;
                case CommandExecuteType.Scalar:
                    result = cmd.ExecuteScalar();
                    break;
                default:
                    result = null;
                    break;
            }

            if (type != CommandExecuteType.DataReader)
            {
                _currentSqlCommand.Dispose();
                _currentSqlCommand = null;

                _currentSqlConnection.Close();
                _currentSqlConnection.Dispose();
                _currentSqlConnection = null;
            }

            return result;
        }

        private static MySqlConnection SetSqlConnection(MySqlCommand cmd, string cs)
        {
            MySqlConnection connection = new MySqlConnection(cs);
            cmd.Connection = connection;
            return connection;
        }

        private bool _isDisposed;
        private MySqlCommand _currentSqlCommand;
        private MySqlDataReader _currentSqlDataReader;
        private MySqlConnection _currentSqlConnection;

        private enum CommandExecuteType
        {
            NonQuery = 1,
            Scalar = 2,
            DataReader = 3
        }

        #endregion


    }
}

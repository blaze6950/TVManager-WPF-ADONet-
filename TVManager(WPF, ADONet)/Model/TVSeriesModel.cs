using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TVManager_WPF__ADONet_.Model
{
    class TVSeriesModel : IDisposable
    {
        private String _connectionString;
        private String _factoryName;
        private DbProviderFactory _factory;
        private DbConnection _connection;

        public TVSeriesModel()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TVSeriesCS"].ConnectionString;
            _factoryName = ConfigurationManager.ConnectionStrings["TVSeriesCS"].ProviderName;

            _factory = DbProviderFactories.GetFactory(_factoryName);
            _connection = _factory.CreateConnection();
            try
            {
                _connection.Open();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
            }
        }        

        public List<TVSeries> GetTVSeriesList(Filters filters)
        {
            List<TVSeries> newList = new List<TVSeries>();
            DbDataReader reader = null;
            if (!filters.IsContainsAnyFilter())
            {
                try
                {
                    DbCommand command = _factory.CreateCommand();
                    command.Connection = _connection;

                    command.CommandText = "SELECT Id, Image, TVSeriesTable.Name, YearOfIssue FROM TVSeriesTable";

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        newList.Add(new TVSeries((int)reader["Id"], (String)reader["Image"], (String)reader["Name"], (int)reader["YearOfIssue"]));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
                }
                finally
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
            }
            else
            {

            }
            return newList;
        }

        public List<String> GetGenreList()
        {
            List<String> newList = new List<string>();
            DbDataReader reader = null;
            try
            {
                DbCommand command = _factory.CreateCommand();
                command.Connection = _connection;

                command.CommandText = "SELECT * FROM Genres";

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    newList.Add((String)reader["Name"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
            }
            return newList;
        }

        public List<String> GetChannelList()
        {
            List<String> newList = new List<string>();
            DbDataReader reader = null;
            try
            {
                DbCommand command = _factory.CreateCommand();
                command.Connection = _connection;

                command.CommandText = "SELECT * FROM Channels";

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    newList.Add((String)reader["Name"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
            }
            return newList;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}

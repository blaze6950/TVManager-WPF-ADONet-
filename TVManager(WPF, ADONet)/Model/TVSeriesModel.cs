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
            _connection.ConnectionString = _connectionString;
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
            try
            {
                reader = BuildCommand(filters);
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

        private DbDataReader BuildCommand(Filters filters)
        {
            DbCommand command = _factory.CreateCommand();
            command.Connection = _connection;
            if (filters.IsContainsAnyFilter())
            {
                StringBuilder stringBuilder = new StringBuilder("SELECT TVSeriesTable.Id, TVSeriesTable.Image, TVSeriesTable.Name FROM TVSeriesTable JOIN Channels ON TVSeriesTable.Channel_Id = Channels.Id JOIN TVSeriesGenres ON TVSeriesTable.Id = TVSeriesGenres.TVSeries_Id JOIN Genres ON Genres.Id = TVSeriesGenres.Genre_Id WHERE ");

                if (filters.FilterGenre.IsContainsAnyFilter())
                {
                    stringBuilder.Insert(stringBuilder.Length, "Genres.Name IN (" + filters.FilterGenre.ToString() + ")");
                }

                if (filters.FilterChannel.IsContainsAnyFilter())
                {
                    stringBuilder.Insert(stringBuilder.Length, ", Channels.Name IN (" + filters.FilterChannel.ToString() + ")");
                }

                if (filters.FilterYear.IsContainsAnyFilter())
                {
                    stringBuilder.Insert(stringBuilder.Length, ", YearOfIssue IN (" + filters.FilterYear.ToString() + ")");
                }

                command.CommandText = stringBuilder.ToString();

                return command.ExecuteReader();
            }
            command.CommandText = "SELECT Id, Image, TVSeriesTable.Name, YearOfIssue FROM TVSeriesTable";
            return command.ExecuteReader();
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

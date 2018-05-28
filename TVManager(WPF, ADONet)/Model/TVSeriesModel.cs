using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TVManager_WPF__ADONet_.Model
{
    public class TVSeriesModel : IDisposable
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
                reader = BuildCommand(filters, null);
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

        public List<TVSeries> GetTVSeriesList(String name)
        {
            List<TVSeries> newList = new List<TVSeries>();
            DbDataReader reader = null;
            try
            {
                DbCommand command = _factory.CreateCommand();
                command.Connection = _connection;
                command.CommandText = "SELECT Id, Image, TVSeriesTable.Name, YearOfIssue FROM TVSeriesTable WHERE Name LIKE '%" + name + "%'";
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
            return newList;
        }

        public List<TVSeries> GetTVSeriesList(Filters filters, String name)
        {
            List<TVSeries> newList = new List<TVSeries>();
            DbDataReader reader = null;
            try
            {
                reader = BuildCommand(filters, name);
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

        public void UpdateGenre(String oldGenre, String newGenre)
        {
            DbCommand command = _factory.CreateCommand();
            command.Connection = _connection;

            command.CommandText = $"SELECT Id FROM Genres WHERE Name = '{oldGenre}'";
            int Id = -1;
            try
            {
                Id = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
            }

            command.CommandText = $"UPDATE Genres SET Name = '{newGenre}' WHERE Id = '{Id}'";
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
            }
        }

        public void RemoveGenre(String genre)
        {
            DbCommand command = _factory.CreateCommand();
            command.Connection = _connection;

            command.CommandText = $"SELECT Id FROM Genres WHERE Name = '{genre}'";
            int Id = -1;
            try
            {
                Id = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
            }

            command.CommandText = $"DELETE FROM Genres WHERE Id = '{Id}'";

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
            }
        }

        public void AddGenre(String newGenre)
        {
            DbCommand command = _factory.CreateCommand();
            command.Connection = _connection;

            command.CommandText = $"INSERT INTO Genres VALUES ('{newGenre}')";
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
            }
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

        public void UpdateChannel(String oldChannel, String newChannel)
        {
            DbCommand command = _factory.CreateCommand();
            command.Connection = _connection;

            command.CommandText = $"SELECT Id FROM Channels WHERE Name = '{oldChannel}'";
            int Id = -1;
            try
            {
                Id = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
            }

            command.CommandText = $"UPDATE Channels SET Name = '{newChannel}' WHERE Id = '{Id}'";
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
            }
        }

        public void RemoveChannel(String channel)
        {
            DbCommand command = _factory.CreateCommand();
            command.Connection = _connection;

            command.CommandText = $"SELECT Id FROM Channels WHERE Name = '{channel}'";
            int Id = -1;
            try
            {
                Id = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
            }

            command.CommandText = $"DELETE FROM Channels WHERE Id = '{Id}'";

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
            }
        }

        public void AddChannel(String newChannel)
        {
            DbCommand command = _factory.CreateCommand();
            command.Connection = _connection;

            command.CommandText = $"INSERT INTO Channels VALUES ('{newChannel}')";
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
            }
        }

        private DbDataReader BuildCommand(Filters filters, String name)
        {
            DbCommand command = _factory.CreateCommand();
            command.Connection = _connection;
            if (filters != null && filters.IsContainsAnyFilter() || name != null)
            {
                StringBuilder stringBuilder = new StringBuilder("SELECT TVSeriesTable.Id, TVSeriesTable.Image, TVSeriesTable.Name, TVSeriesTable.YearOfIssue FROM TVSeriesTable JOIN Channels ON TVSeriesTable.Channel_Id = Channels.Id LEFT JOIN TVSeriesGenres ON TVSeriesTable.Id = TVSeriesGenres.TVSeries_Id LEFT JOIN Genres ON Genres.Id = TVSeriesGenres.Genre_Id WHERE ");

                if (filters.FilterGenre.IsContainsAnyFilter())
                {
                    stringBuilder.Insert(stringBuilder.Length, "Genres.Name IN (" + filters.FilterGenre.ToString() + ")");
                }

                if (filters.FilterChannel.IsContainsAnyFilter())
                {
                    if (filters.FilterGenre.IsContainsAnyFilter())
                    {
                        stringBuilder.Insert(stringBuilder.Length, "AND Channels.Name IN (" + filters.FilterChannel.ToString() + ")");
                    }
                    else
                    {
                        stringBuilder.Insert(stringBuilder.Length, "Channels.Name IN (" + filters.FilterChannel.ToString() + ")");
                    }
                }

                if (filters.FilterYear.IsContainsAnyFilter())
                {
                    if (filters.FilterChannel.IsContainsAnyFilter() || filters.FilterGenre.IsContainsAnyFilter())
                    {
                        stringBuilder.Insert(stringBuilder.Length, "AND YearOfIssue IN (" + filters.FilterYear.ToString() + ")");
                    }
                    else
                    {
                        stringBuilder.Insert(stringBuilder.Length, "YearOfIssue >= (" + filters.FilterYear.FilterItemList[0].Item + ") AND YearOfIssue <= (" + filters.FilterYear.FilterItemList[1].Item + ")");
                    }
                }

                if (name != null)
                {
                    if (filters.FilterChannel.IsContainsAnyFilter() || filters.FilterGenre.IsContainsAnyFilter() || filters.FilterYear.IsContainsAnyFilter())
                    {
                        stringBuilder.Insert(stringBuilder.Length, "AND TVSeriesTable.Name LIKE '%" + name + "%'");
                    }
                    else
                    {
                        stringBuilder.Insert(stringBuilder.Length, "TVSeriesTable.Name LIKE '%" + name + "%'");
                    }
                }

                stringBuilder.Insert(stringBuilder.Length, " GROUP BY TVSeriesTable.Id, TVSeriesTable.Image, TVSeriesTable.Name, TVSeriesTable.YearOfIssue");
                command.CommandText = stringBuilder.ToString();

                return command.ExecuteReader();
            }
            command.CommandText = "SELECT Id, Image, TVSeriesTable.Name, YearOfIssue FROM TVSeriesTable";
            return command.ExecuteReader();
        }

        public void RemoveTvSeriesItem(TVSeries item)
        {
            try
            {
                DbCommand command = _factory.CreateCommand();
                command.Connection = _connection;
                command.CommandText = "DELETE FROM TVSeriesTable WHERE Id = @Id";
                DbParameter idParameter = _factory.CreateParameter();
                SqlParameter firstNameParam = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 15);
                idParameter.ParameterName = "@Id";
                idParameter.DbType = System.Data.DbType.Int32;
                idParameter.Value = item.Id;
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
            }           
        }

        public void AddTVSeriesItem(TVSeriesExtended item)
        {
            DbCommand command = _factory.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"INSERT INTO TVSeriesTable VALUES('{item.Name}', '{item.Image}', '{item.Year}', '{item.NumberOfSeasons}', '{item.Description}', (SELECT Id FROM Channels WHERE Name = '{item.Channel}'))";
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
            }

            command.CommandText = $"(SELECT Id FROM TVSeriesTable WHERE Name = '{item.Name}' AND Image = '{item.Image}' AND YearOfIssue = '{item.Year}' AND Seasons = '{item.NumberOfSeasons}')";
            DbDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item.Id = (Int32) reader["Id"];
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

            if (item.GenreList.Count > 0)
            {
                StringBuilder stringBuilder = new StringBuilder("INSERT INTO TVSeriesGenres VALUES");
                int size = stringBuilder.Length;
                foreach (var genre in item.GenreList)
                {
                    if (stringBuilder.Length <= size)
                    {
                        stringBuilder.Insert(stringBuilder.Length,
                            $"({item.Id}, (SELECT Id FROM Genres WHERE Name = '{genre}'))");
                    }
                    else
                    {
                        stringBuilder.Insert(stringBuilder.Length, $", ({item.Id}, (SELECT Id FROM Genres WHERE Name = '{genre}'))");
                    }
                }
                command.CommandText = stringBuilder.ToString();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ooops", MessageBoxButton.OK);
                }
            }
        }

        public TVSeriesExtended GetExtendedTVSeriesItem(TVSeries item)
        {
            TVSeriesExtended res = null;
            DbCommand command = _factory.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"SELECT TVSeriesTable.Id, TVSeriesTable.Image, TVSeriesTable.Name, TVSeriesTable.Seasons, TVSeriesTable.YearOfIssue, TVSeriesTable.Desription, Channels.Name as 'Channel' FROM TVSeriesTable JOIN Channels ON TVSeriesTable.Channel_Id = Channels.Id WHERE TVSeriesTable.Id = {item.Id}";
            DbDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = new TVSeriesExtended((String) reader["Desription"], (String) reader["Channel"],
                        new List<string>(), (int?) reader["Seasons"], (int) reader["Id"], (String) reader["Image"],
                        (String) reader["Name"], (int?) reader["YearOfIssue"]);
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
            
            command.CommandText = $"SELECT Genres.Name FROM Genres JOIN TVSeriesGenres ON Genres.Id = TVSeriesGenres.Genre_Id WHERE TVSeriesGenres.TVSeries_Id = {item.Id}";

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res.GenreList.Add((String) reader["Name"]);
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

            return res;
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

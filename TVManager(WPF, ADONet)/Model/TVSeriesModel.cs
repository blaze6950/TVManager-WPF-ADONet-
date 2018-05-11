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
            _connectionString = ConfigurationManager.ConnectionStrings["LibraryCS"].ConnectionString;
            _factoryName = ConfigurationManager.ConnectionStrings["LibraryCS"].ProviderName;

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

        public void Dispose()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public List<TVSeries> GetTVSeriesList(Filters filters)
        {
            List<TVSeries> newList = new List<TVSeries>();

            return newList;
        }
    }
}

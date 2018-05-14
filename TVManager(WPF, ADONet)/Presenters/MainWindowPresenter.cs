using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TVManager_WPF__ADONet_.Model;
using TVManager_WPF__ADONet_.Model.Filter;
using TVManager_WPF__ADONet_.Views;
using TVManager_WPF__ADONet_.Views.Filter;

namespace TVManager_WPF__ADONet_.Presenters
{
    class MainWindowPresenter : IPresenterMainWindow
    {
        private Filters _filters;
        private IViewMainWindow _view;
        private TVSeriesModel _model;
        public MainWindowPresenter(IViewMainWindow view)
        {
            _model = new TVSeriesModel();
            _view = view;
            InitializeFilters();
            LoadList();            
        }

        private void InitializeFilters()
        {
            _filters = new Filters();
            var genreList = _model.GetGenreList();
            foreach (String item in genreList)
            {
                _filters.FilterGenre.AddFilterItem(new FilterItem(item, false));
            }
            var channelList = _model.GetChannelList();
            foreach (String item in channelList)
            {
                _filters.FilterChannel.AddFilterItem(new FilterItem(item, false));
            }
            SetFilterListAtView();
        }

        private void SetFilterListAtView()
        {
            _view.ListBoxGenres.ItemsSource = _filters.FilterGenre.FilterItemList;
            _view.ListBoxChannels.ItemsSource = _filters.FilterChannel.FilterItemList;
        }

        public void LoadList()
        {
            List<TVSeries> TVSeriesList = _model.GetTVSeriesList(_filters);
            _view.ListTvSeries.ItemsSource = TVSeriesList;
        }        

        public void ButtonFind_Click()
        {
            List<TVSeries> TVSeriesList = _model.GetTVSeriesList(_view.ComboBoxFind.Text);
            _view.ListTvSeries.ItemsSource = TVSeriesList;
        }

        public void ButtonNew_Click()
        {
            throw new NotImplementedException();
        }

        public void ComboBoxFind_TextInput(string findText)
        {
            throw new NotImplementedException();
        }
    }
}

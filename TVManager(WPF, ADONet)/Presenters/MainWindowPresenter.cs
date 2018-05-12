using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVManager_WPF__ADONet_.Model;
using TVManager_WPF__ADONet_.Model.Filter;
using TVManager_WPF__ADONet_.Views;

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
            LoadList();
            InitializeFilters();
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
            
        }

        public void LoadList()
        {
            throw new NotImplementedException();
        }
    }
}

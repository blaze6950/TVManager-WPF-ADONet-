using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVManager_WPF__ADONet_.Model;
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
            //_filters.FilterGenre;
        }

        public void LoadList()
        {
            throw new NotImplementedException();
        }
    }
}

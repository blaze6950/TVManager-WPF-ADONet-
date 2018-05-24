using TVManager_WPF__ADONet_.Model;

namespace TVManager_WPF__ADONet_.Presenters
{
    public class TVSeriesWindowPresenter : IPresenterTVSeriesWindow
    {
        private TVSeriesModel _model;
        private TVSeriesWindow _view;
        private TVSeriesExtended _TVSeriesExtended;

        public TVSeriesWindowPresenter(TVSeriesModel model, TVSeriesWindow view, TVSeriesWindowMode mode, TVSeriesExtended TVSeriesItem)
        {
            _model = model;
            _view = view;
            _TVSeriesExtended = TVSeriesItem;
            InitializeView(mode);
        }

        private void InitializeView(TVSeriesWindowMode mode)
        {
            switch (mode)
            {
                case TVSeriesWindowMode.View:
                    InitializeViewModeView();
                    break;
                case TVSeriesWindowMode.New:
                    InitializeViewModeNew();
                    break;
                case TVSeriesWindowMode.Edit:
                    InitializeViewModeEdit();
                    break;
            }
        }

        private void InitializeViewModeEdit()
        {
            throw new System.NotImplementedException();
        }

        private void InitializeViewModeNew()
        {
            throw new System.NotImplementedException();
        }

        private void InitializeViewModeView()
        {
            throw new System.NotImplementedException();
        }
    }
}
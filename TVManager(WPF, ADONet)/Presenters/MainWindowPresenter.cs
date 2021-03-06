﻿using System;
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
            String name = _view.ComboBoxFind.Text;
            if (name.Length == 0)
            {
                name = null;
            }
            List<TVSeries> TVSeriesList = _model.GetTVSeriesList(_filters, name);
            _view.ListTvSeries.ItemsSource = TVSeriesList;
        }        

        public void ButtonFind_Click()
        {
            LoadList();
        }

        public void ButtonNew_Click()
        {
            TVSeriesWindow tvSeriesWindow = new TVSeriesWindow(null, TVSeriesWindowMode.New, _model);
            tvSeriesWindow.ShowDialog();
            LoadList();
        }

        public void ButtonEdit_Click(TVSeries item)
        {
            TVSeriesExtended tvSeriesExtended = _model.GetExtendedTVSeriesItem(item);
            TVSeriesWindow tvSeriesWindow = new TVSeriesWindow(tvSeriesExtended, TVSeriesWindowMode.Edit, _model);
            tvSeriesWindow.ShowDialog();
            LoadList();
        }

        public void ComboBoxFind_TextInput(string findText)
        {
            if (findText.Length > 0)
            {
                List<TVSeries> TVSeriesList = _model.GetTVSeriesList(findText);
                if (TVSeriesList.Count > 0)
                {
                    _view.ComboBoxFind.Items.Clear();
                }
                foreach (TVSeries item in TVSeriesList)
                {
                    _view.ComboBoxFind.Items.Add(item.Name);
                }
                _view.ComboBoxFind.IsDropDownOpen = true;
            }
        }

        public void ListViewItemRemove(TVSeries item)
        {
            _model.RemoveTvSeriesItem(item);
            LoadList();
        }

        public void ListViewMouseDoubleClick(TVSeries item)
        {
            TVSeriesExtended tvSeriesExtended = _model.GetExtendedTVSeriesItem(item);
            TVSeriesWindow tvSeriesWindow = new TVSeriesWindow(tvSeriesExtended, TVSeriesWindowMode.View, _model);
            tvSeriesWindow.ShowDialog();
        }

        public void GenresMenu_Click()
        {
            GenresWindow genresWindow = new GenresWindow(_model);
            genresWindow.ShowDialog();
        }

        public void ChannelsMenu_Click()
        {
            ChannelsWindow channelsWindow = new ChannelsWindow(_model);
            channelsWindow.ShowDialog();
        }

        public void Year_Changed(int startYear, int endYear)
        {
            _filters.FilterYear.FilterItemList.Clear();
            _filters.FilterYear.FilterItemList.Add(new FilterItem(startYear.ToString(), true));
            _filters.FilterYear.FilterItemList.Add(new FilterItem(endYear.ToString(), true));
            LoadList();
        }

        public void ResetYearFilter()
        {
            _filters.FilterYear.FilterItemList.Clear();
            LoadList();
        }
    }
}

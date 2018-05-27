﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TVManager_WPF__ADONet_.Model;
using TVManager_WPF__ADONet_.Views;

namespace TVManager_WPF__ADONet_.Presenters
{
    public class TVSeriesWindowPresenter : IPresenterTVSeriesWindow
    {
        private TVSeriesModel _model;
        private IViewTVSeriesWindow _view;
        private TVSeriesExtended _TVSeriesExtended;
        private TVSeriesWindowMode _mode;

        public TVSeriesWindowPresenter(TVSeriesModel model, IViewTVSeriesWindow view, TVSeriesWindowMode mode, TVSeriesExtended TVSeriesItem)
        {
            _model = model;
            _view = view;
            _TVSeriesExtended = TVSeriesItem;
            _mode = mode;
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
            EnableElemntsInView();
            LoadInfoFromTVSeriesItem();
        }

        private void InitializeViewModeNew()
        {
            EnableElemntsInView();
            LoadChannels();
            LoadGenres();
        }

        private void InitializeViewModeView()
        {
            _view.ButtonsOkCancel.Visibility = Visibility.Hidden;
            LoadInfoFromTVSeriesItem();
        }

        private void EnableElemntsInView()
        {
            _view.NameTVSeries.IsEnabled = true;
            _view.Channel.IsEnabled = true;
            _view.Genre.IsEnabled = true;
            _view.Description.IsEnabled = true;
            _view.ImageTVSeries.IsEnabled = true;
            _view.Year.IsEnabled = true;
            _view.NumberOfSeasons.IsEnabled = true;
            _view.ButtonsOkCancel.Visibility = Visibility.Visible;
        }

        // ReSharper disable once InconsistentNaming
        private void LoadInfoFromTVSeriesItem()
        {
            _view.NameTVSeries.Text = _TVSeriesExtended.Name;
            LoadChannels();
            LoadGenres();
            _view.Description.Text = _TVSeriesExtended.Description;
            _view.ImageTVSeries.Source = new BitmapImage(new Uri(_TVSeriesExtended.Image));
            _view.Year.Text = _TVSeriesExtended.Year.ToString();
            _view.NumberOfSeasons.Text = _TVSeriesExtended.NumberOfSeasons.ToString();
        }

        private void LoadChannels()
        {
            List<String> channelList = _model.GetChannelList();
            _view.Channel.ItemsSource = channelList;
            if (_TVSeriesExtended != null)
            {
                _view.Channel.Text = _TVSeriesExtended.Channel;
            }
        }

        private void LoadGenres()
        {
            List<String> genreList = _model.GetGenreList();
            CheckBox checkBox;
            foreach (var genre in genreList)
            {
                checkBox = new CheckBox();
                checkBox.Content = genre;
                if (_TVSeriesExtended != null)
                {
                    foreach (var genreItem in _TVSeriesExtended.GenreList)
                    {
                        if (genre.Equals(genreItem))
                        {
                            checkBox.IsChecked = true;
                            break;
                        }
                    }
                }
                _view.Genre.Items.Add(checkBox);
            }
        }

        public void OkeyButtonClick()
        {
            switch (_mode)
            {
                case TVSeriesWindowMode.View:
                    _view.CloseWindow();
                    break;
                case TVSeriesWindowMode.New:
                    AddNewTVSeries();
                    break;
                case TVSeriesWindowMode.Edit:
                    InitializeViewModeEdit();
                    break;
            }
        }

        private void AddNewTVSeries()
        {
            _TVSeriesExtended = new TVSeriesExtended();
            _TVSeriesExtended.Name = _view.NameTVSeries.Text;
            _TVSeriesExtended.Image = (_view.ImageTVSeries.Source as BitmapImage).UriSource.AbsolutePath;
            _TVSeriesExtended.Year = Int32.Parse(_view.Year.Text);
            _TVSeriesExtended.NumberOfSeasons = Int32.Parse(_view.NumberOfSeasons.Text);
            _TVSeriesExtended.Description = _view.Description.Text;
            _TVSeriesExtended.Channel = _view.Channel.Text;
            foreach (object genre in _view.Genre.Items)
            {
                if (genre is CheckBox && ((CheckBox)genre).IsChecked == true)
                {
                    _TVSeriesExtended.GenreList.Add((String)((CheckBox)genre).Content);
                }
            }
            _model.AddTVSeriesItem(_TVSeriesExtended);
            _view.CloseWindow();
        }

        public void CancelButtonClick()
        {
            throw new NotImplementedException();
        }
    }
}
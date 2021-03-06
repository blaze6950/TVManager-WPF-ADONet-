﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using TVManager_WPF__ADONet_.Model;
using TVManager_WPF__ADONet_.Presenters;
using TVManager_WPF__ADONet_.Views;

namespace TVManager_WPF__ADONet_
{
    /// <summary>
    /// Interaction logic for TVSeriesWindow.xaml
    /// </summary>
    public partial class TVSeriesWindow : Window, IViewTVSeriesWindow
    {
        private IPresenterTVSeriesWindow _presenter;


        public Image ImageTVSeries { get => Image; set => Image = value; }
        public TextBox NameTVSeries { get => NameTB; set => NameTB = value; }
        public ComboBox Channel { get => ChannelTB; set => ChannelTB = value; }
        public ListBox Genre { get => GenreTB; set => GenreTB = value; }
        public TextBox Year { get => YearTB; set => YearTB = value; }
        public TextBox NumberOfSeasons { get => SeasonsTB; set => SeasonsTB = value; }
        public TextBox Description { get => DescriptionTB; set => DescriptionTB = value; }
        public Grid ButtonsOkCancel { get => GridButtonsOkCancel; set => GridButtonsOkCancel = value; }
        public Grid ChannelsField { get => ChannelField; set => ChannelField = value; }

        public void CloseWindow()
        {
            this.Close();
        }
        

        // ReSharper disable once InconsistentNaming
        public TVSeriesWindow(TVSeriesExtended TVSeriesItem, TVSeriesWindowMode mode, TVSeriesModel model)
        {
            InitializeComponent();
            _presenter = new TVSeriesWindowPresenter(model, this, mode, TVSeriesItem);
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Cancel?", "Are u sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                _presenter.CancelButtonClick();
            }
        }

        private void ButtonOkey_OnClick(object sender, RoutedEventArgs e)
        {
            if (CheckFileds())
            {
                _presenter.OkeyButtonClick();
            }
            else
            {
                MessageBox.Show("Fill all fields and fill correct values!", "Ooops", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private bool CheckFileds()
        {
            int buf;
            if (NameTVSeries.Text.Length <= 0)
            {
                return false;
            }
            if (Channel.Text.Length <= 0)
            {
                return false;
            }
            if (YearTB.Text.Length > 0 && !Int32.TryParse(YearTB.Text, out buf))
            {
                return false;
            }
            if (NumberOfSeasons.Text.Length > 0 && !Int32.TryParse(NumberOfSeasons.Text, out buf))
            {
                return false;
            }
            return true;
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    Image.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Something go wrong... Try choose another picture! " + exception.Message, "Ooops", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }

        private void ButtonAddChannel_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

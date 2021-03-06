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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TVManager_WPF__ADONet_.Model;
using TVManager_WPF__ADONet_.Presenters;
using TVManager_WPF__ADONet_.Views;
using TVManager_WPF__ADONet_.Views.Filter;

namespace TVManager_WPF__ADONet_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewMainWindow
    {
        IPresenterMainWindow _presenter;

        ListBox IViewMainWindow.ListBoxGenres { get => ListBoxGenres; set => ListBoxGenres = value; }
        ListBox IViewMainWindow.ListBoxChannels { get => ListBoxChannels; set => ListBoxChannels = value; }
        ComboBox IViewMainWindow.ComboBoxFind { get => ComboBoxFind; set => ComboBoxFind = value; }
        ListView IViewMainWindow.ListTvSeries { get => ListTvSeries; set => ListTvSeries = value; }

        public MainWindow()
        {
            InitializeComponent();            
            _presenter = new MainWindowPresenter(this);
        }        

        private void MyListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _presenter.ListViewMouseDoubleClick((TVSeries)((ListView)sender).SelectedItem);
        }

        private void CheckBoxFilter_StateChanged(object sender, RoutedEventArgs e)
        {            
            _presenter.LoadList();
        }        

        private void ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            _presenter.ButtonFind_Click();
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            _presenter.ButtonNew_Click();
        }        

        private void ListBox_Selected(object sender, RoutedEventArgs e)
        {
            //ListBox listBox = (ListBox)sender;
            //((IFilterItem)listBox.SelectedItem).Value = !((IFilterItem)listBox.SelectedItem).Value;
            //////////////////////
        }

        private void ButtonListViewItemEdit_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TVSeries item = (TVSeries)button.DataContext; 
            _presenter.ButtonEdit_Click(item);
        }

        private void ButtonListViewItemRemove_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TVSeries item = (TVSeries)button.DataContext;
            MessageBoxResult res = MessageBox.Show($"Delete \"{item.Name}\"", "Are you sure?", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (res == MessageBoxResult.OK)
            {
                _presenter.ListViewItemRemove(item);
            }
        }

        private void ComboBoxFind_TextInput(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonFind_Click(null, null);
            }            
            _presenter.ComboBoxFind_TextInput(ComboBoxFind.Text);
        }

        private void MenuItemFilters_Click(object sender, RoutedEventArgs e)
        {
            if (MenuItemFilters.IsChecked)
            {
                FiltersPanel.Visibility = Visibility.Visible;
            }
            else
            {
                FiltersPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void MenuItemGenres_OnClick(object sender, RoutedEventArgs e)
        {
            _presenter.GenresMenu_Click();
        }

        private void MenuItemChannels_OnClick(object sender, RoutedEventArgs e)
        {
            _presenter.ChannelsMenu_Click();
        }

        private void TextBoxStartYear_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (Int32.TryParse(TextBoxStartYear.Text, out var startYear))
            {
                if (Int32.TryParse(TextBoxEndYear.Text, out var endYear))
                {
                    if (startYear > endYear)
                    {
                        endYear = startYear;
                        TextBoxEndYear.Text = endYear.ToString();
                    }
                }
                else
                {
                    endYear = startYear;
                    TextBoxEndYear.Text = endYear.ToString();
                }
                if (endYear > 1800 && startYear > 1800)
                {
                    _presenter.Year_Changed(endYear, startYear);
                }
            }
        }

        private void TextBoxEndYear_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (Int32.TryParse(TextBoxEndYear.Text, out var endYear))
            {
                if (Int32.TryParse(TextBoxStartYear.Text, out var startYear))
                {
                    if (startYear > endYear)
                    {
                        startYear = endYear;
                        TextBoxStartYear.Text = startYear.ToString();
                    }
                }
                else
                {
                    startYear = endYear;
                    TextBoxStartYear.Text = startYear.ToString();
                }
                if (endYear > 1800 && startYear > 1800)
                {
                    _presenter.Year_Changed(startYear, endYear);
                }
            }
        }

        private void ButtonResetYearFilter_OnClick(object sender, RoutedEventArgs e)
        {
            TextBoxStartYear.Text = "";
            TextBoxEndYear.Text = "";
            _presenter.ResetYearFilter();
        }
    }
}

using System;
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
using TVManager_WPF__ADONet_.Model;

namespace TVManager_WPF__ADONet_
{
    /// <summary>
    /// Interaction logic for GenresWindow.xaml
    /// </summary>
    public partial class GenresWindow : Window
    {
        private TVSeriesModel _model;
        private bool isEditing = false;

        public GenresWindow(TVSeriesModel model)
        {
            InitializeComponent();
            _model = model;
            LoadGenresList();
        }

        private void LoadGenresList()
        {
            ListViewGenres.ItemsSource = _model.GetGenreList();
        }

        private void ButtonListViewItemEdit_Click(object sender, RoutedEventArgs e)
        {
            isEditing = true;
            ListViewGenres.SelectedItem = ((Button)sender).DataContext;
            ListViewGenres.IsEnabled = false;
            TextBox.Text = (String)((Button)sender).DataContext;
            ButtonAddUpdate.Content = "Next...";
        }

        private void ButtonListViewItemRemove_Click(object sender, RoutedEventArgs e)
        {
            String item = (String)((Button)sender).DataContext;
            var res = MessageBox.Show("Delete this channel?", "Are u sure?", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                _model.RemoveGenre(item);
                LoadGenresList();
            }
        }

        private void ButtonAddUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            if (isEditing)
            {
                var res = MessageBox.Show("Update this genre?", "Are u sure?", MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    _model.UpdateGenre((String)ListViewGenres.SelectedItem, TextBox.Text);
                }
                ButtonAddUpdate.Content = "Add";
                ListViewGenres.IsEnabled = true;
            }
            else
            {
                _model.AddGenre(TextBox.Text);
            }
            isEditing = false;
            LoadGenresList();
            TextBox.Text = "";
        }
    }
}

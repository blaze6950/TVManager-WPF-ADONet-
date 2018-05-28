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
    /// Interaction logic for ChannelsWindow.xaml
    /// </summary>
    public partial class ChannelsWindow : Window
    {
        private TVSeriesModel _model;
        private bool isEditing = false;

        public ChannelsWindow(TVSeriesModel model)
        {
            InitializeComponent();
            _model = model;
            LoadChannelList();
        }

        private void LoadChannelList()
        {
            ListViewChannels.ItemsSource = _model.GetChannelList();
        }

        private void ButtonListViewItemEdit_Click(object sender, RoutedEventArgs e)
        {
            isEditing = true;
            ListViewChannels.SelectedItem = ((Button) sender).DataContext;
            ListViewChannels.IsEnabled = false;
            TextBox.Text = (String) ((Button) sender).DataContext;
            ButtonAddUpdate.Content = "Next...";
        }

        private void ButtonListViewItemRemove_Click(object sender, RoutedEventArgs e)
        {
            String item = (String)((Button) sender).DataContext;
            _model.RemoveChannel(item);
        }

        private void ButtonAddUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            if (isEditing)
            {
                var res = MessageBox.Show("Update this channel?", "Are u sure?", MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {

                }
                ButtonAddUpdate.Content = "Add";
                ListViewChannels.IsEnabled = true;

                _model.UpdateChannel((String) ListViewChannels.SelectedItem, TextBox.Text);
            }
            else
            {
                _model.AddChannel(TextBox.Text);
            }
            isEditing = false;
            LoadChannelList();
        }
    }
}

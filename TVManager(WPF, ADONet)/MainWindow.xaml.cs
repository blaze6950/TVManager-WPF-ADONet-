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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TVManager_WPF__ADONet_.Presenters;
using TVManager_WPF__ADONet_.Views;

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

        private void CheckBoxGenre_Checked(object sender, RoutedEventArgs e)
        {
            _presenter.CheckBoxGenre_Checked((String)(((CheckBox)sender).Content));
        }

        private void CheckBoxChannel_Checked(object sender, RoutedEventArgs e)
        {
            _presenter.CheckBoxChannel_Checked((String)(((CheckBox)sender).Content));
        }

        private void ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            _presenter.ButtonFind_Click();
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            _presenter.ButtonNew_Click();
        }

        private void ComboBoxFind_TextInput(object sender, TextCompositionEventArgs e)
        {
            _presenter.ComboBoxFind_TextInput((String)(((CheckBox)sender).Content));
        }
    }
}

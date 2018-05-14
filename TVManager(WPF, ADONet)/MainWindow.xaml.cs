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
            //ConfigListView();
            _presenter = new MainWindowPresenter(this);
        }

        //private void ConfigListView()
        //{
        //    GridView myGridView = new GridView();
        //    myGridView.AllowsColumnReorder = true;
        //    myGridView.ColumnHeaderToolTip = "Authors Information";

        //    GridViewColumn gvc;

        //    gvc = new GridViewColumn();
        //    gvc.DisplayMemberBinding = new Binding("Image");
        //    gvc.Header = "Image";
        //    DataTemplate dataTemplate = new DataTemplate();
        //    dataTemplate.
        //    gvc.CellTemplate = new Image();
        //    gvc.Width = 100;
        //    myGridView.Columns.Add(gvc);

        //    gvc = new GridViewColumn();
        //    gvc.DisplayMemberBinding = new Binding("Name");
        //    gvc.Header = "Name";
        //    gvc.Width = 100;
        //    myGridView.Columns.Add(gvc);

        //    gvc = new GridViewColumn();
        //    gvc.DisplayMemberBinding = new Binding("Year");
        //    gvc.Header = "Year";
        //    gvc.Width = 50;
        //    myGridView.Columns.Add(gvc);

        //    gvc = new GridViewColumn();
        //    gvc.DisplayMemberBinding = new Binding("");
        //    gvc.Header = "";
        //    gvc.Width = 50;
        //    myGridView.Columns.Add(gvc);

        //    gvc = new GridViewColumn();
        //    gvc.DisplayMemberBinding = new Binding("");
        //    gvc.Header = "";
        //    gvc.Width = 50;
        //    myGridView.Columns.Add(gvc);

        //    ListTvSeries.View = myGridView;
        //    ListTvSeries.MouseDoubleClick += MyListView_MouseDoubleClick;
        //}

        private void MyListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CheckBoxGenre_Checked(object sender, RoutedEventArgs e)
        {
            _presenter.CheckBoxGenre_Checked((String)(((CheckBox)sender).Content));
        }

        private void CheckBoxChannel_Checked(object sender, RoutedEventArgs e)
        {
            _presenter.CheckBoxChannel_Checked((String)(((CheckBox)sender).Content));
        }

        private void CheckBoxChannel_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBoxGenre_Unchecked(object sender, RoutedEventArgs e)
        {

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

        private void ListBox_Selected(object sender, RoutedEventArgs e)
        {
            //ListBox listBox = (ListBox)sender;
            //((IFilterItem)listBox.SelectedItem).Value = !((IFilterItem)listBox.SelectedItem).Value;
            //////////////////////
        }

        private void ButtonListViewItemEdit_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ListViewItem listviewItem = (ListViewItem)button.Parent; 
        }

        private void ButtonListViewItemRemove_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ListViewItem listviewItem = (ListViewItem)button.Parent;
        }        
    }
}

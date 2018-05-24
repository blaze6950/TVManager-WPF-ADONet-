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
        public TextBox Channel { get => ChannelTB; set => ChannelTB = value; }
        public TextBox Genre { get => GenreTB; set => GenreTB = value; }
        public TextBox Year { get => YearTB; set => YearTB = value; }
        public TextBox NumberOfSeasons { get => SeasonsTB; set => SeasonsTB = value; }
        public TextBox Description { get => DescriptionTB; set => DescriptionTB = value; }
        public Grid ButtonsOkCancel { get => GridButtonsOkCancel; set => GridButtonsOkCancel = value; }


        public TVSeriesWindow(TVSeriesExtended TVSeriesItem, TVSeriesWindowMode mode, TVSeriesModel model)
        {
            InitializeComponent();
            _presenter = new TVSeriesWindowPresenter(model, this, mode, TVSeriesItem);
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonOkey_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

﻿using System.Windows.Controls;

namespace TVManager_WPF__ADONet_.Views
{
    public interface IViewTVSeriesWindow
    {
        Image ImageTVSeries { get; set; }
        TextBox NameTVSeries { get; set; }
        ComboBox Channel { get; set; }
        ListBox Genre { get; set; }
        TextBox Year { get; set; }
        TextBox NumberOfSeasons { get; set; }
        TextBox Description { get; set; }
        Grid ButtonsOkCancel { get; set; }
        void CloseWindow();
        Grid ChannelsField { get; set; }
    }
}
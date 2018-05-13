using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TVManager_WPF__ADONet_.Views
{
    interface IViewMainWindow
    {
        ListBox ListBoxGenres { get; set; }
        ListBox ListBoxChannels { get; set; }
        ComboBox ComboBoxFind { get; set; }
        ListView ListTvSeries { get; set; }
    }
}

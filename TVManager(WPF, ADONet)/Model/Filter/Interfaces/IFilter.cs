using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVManager_WPF__ADONet_.Views.Filter
{
    interface IFilter
    {
        List<IFilterItem> FilterItemList { get; set; }
        void AddFilterItem(IFilterItem filterItem);
        void RemoveFilterItem(IFilterItem filterItem);
        IFilterItem GetFilterItem(int index);
    }
}

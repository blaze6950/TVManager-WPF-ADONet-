using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVManager_WPF__ADONet_.Views.Filter.FilterChannel
{
    class FilterChannel : IFilter
    {
        private List<IFilterItem> _filterItemList;

        public FilterChannel()
        {
            _filterItemList = new List<IFilterItem>();
        }

        public List<IFilterItem> FilterItemList { get => _filterItemList; set => _filterItemList = value; }

        public void AddFilterItem(IFilterItem filterItem)
        {
            if (filterItem != null)
            {
                _filterItemList.Add(filterItem);
            }
        }

        public IFilterItem GetFilterItem(int index)
        {
            return _filterItemList[index];
        }

        public void RemoveFilterItem(IFilterItem filterItem)
        {
            if (filterItem != null)
            {
                bool res = _filterItemList.Remove(filterItem);
                if (!res)
                {
                    IFilterItem newFilterItem = null;
                    foreach (IFilterItem item in _filterItemList)
                    {
                        if (item.Item == filterItem.Item)
                        {
                            newFilterItem = item;
                            break;
                        }
                    }
                    if (newFilterItem != null)
                    {
                        _filterItemList.Remove(newFilterItem);
                    }
                }
            }
        }
    }
}

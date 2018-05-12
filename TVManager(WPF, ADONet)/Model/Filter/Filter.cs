using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVManager_WPF__ADONet_.Views.Filter;

namespace TVManager_WPF__ADONet_.Model.Filter
{
    class FilterA : IFilter
    {
        protected List<IFilterItem> _filterItemList;

        public FilterA()
        {
            _filterItemList = new List<IFilterItem>();
        }

        public List<IFilterItem> FilterItemList { get => _filterItemList; set => _filterItemList = value; }

        public virtual void AddFilterItem(IFilterItem filterItem)
        {
            if (filterItem != null)
            {
                _filterItemList.Add(filterItem);
            }
        }

        public virtual void RemoveFilterItem(IFilterItem filterItem)
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

        public virtual IFilterItem GetFilterItem(int index)
        {
            return _filterItemList[index];
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (IFilterItem item in _filterItemList)
            {
                if (item.Value == true)
                {
                    stringBuilder.AppendLine(item.Item);
                }
            }
            return stringBuilder.ToString();
        }

        public virtual bool IsContainsAnyFilter()
        {
            foreach (IFilterItem item in _filterItemList)
            {
                if (item.Value == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

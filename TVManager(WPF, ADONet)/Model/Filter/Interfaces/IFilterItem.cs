﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVManager_WPF__ADONet_.Views.Filter
{
    public interface IFilterItem
    {
        String Item { get; set; }
        bool Value { get; set; }
    }
}

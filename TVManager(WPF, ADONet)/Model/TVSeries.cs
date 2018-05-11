using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVManager_WPF__ADONet_.Model
{
    class TVSeries
    {
        private int _id;
        private String _image;
        private String _name;
        private int _year;

        public TVSeries()
        {
        }

        public TVSeries(int id, string image, string name, int year)
        {
            _id = id;
            _image = image;
            _name = name;
            _year = year;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVManager_WPF__ADONet_.Model
{
    class TVSeries
    {
        protected int _id;
        protected String _image;
        protected String _name;
        protected int _year;



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

        public int Id { get => _id; set => _id = value; }
        public string Image { get => _image; set => _image = value; }
        public string Name { get => _name; set => _name = value; }
        public int Year { get => _year; set => _year = value; }
    }
}

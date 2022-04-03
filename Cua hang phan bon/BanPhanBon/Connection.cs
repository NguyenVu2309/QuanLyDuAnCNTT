using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanPhanBon
{
    class Connection
    {
        String cn_str = @"Data Source = DESKTOP-HCDNRDL\SQLEXPRESS; Initial Catalog = PhanBon; User Id = sa; Password = 123456";
        public String ketnoi
        {
            get
            {
                return cn_str;
            }
        }

        public Connection() { }
    }
}

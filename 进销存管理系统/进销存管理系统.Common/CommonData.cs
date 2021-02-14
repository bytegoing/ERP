using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using 进销存管理系统.Models;

namespace 进销存管理系统.Common
{
    public class CommonData
    {
        public static User nowLoginUser;
        public static Tuple<string, string> buffer2str = new Tuple<string, string>("", "");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace 辅助库
{
    public class 类XML转化
    {
        public static void 类转XML(string fileName, Type classtype, object obj)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory  + fileName;
            if (File.Exists(path)) { File.Delete(path); }
            FileStream fs = null;
            fs = new FileStream(path, FileMode.OpenOrCreate);
            XmlSerializer xs = new XmlSerializer(classtype);
            xs.Serialize(fs, obj);
            fs.Close();
        }

        public static object XML转类(string fileName, Type classtype)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory  + fileName;
            FileStream fs = null;
            fs = new FileStream(path, FileMode.OpenOrCreate);
            XmlSerializer xs = new XmlSerializer(classtype);
            object o = xs.Deserialize(fs);
            fs.Close();
            return o;
        }
    }
}

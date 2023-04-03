using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{
    public class Params
    {
        private string recourcesFolder;

        public Params()
        {
            var ind = Directory.GetCurrentDirectory().ToString()
                .IndexOf("bin", StringComparison.Ordinal);

            string binFolder =
                Directory.GetCurrentDirectory().ToString().Substring(0, ind).ToString();
            recourcesFolder = binFolder + "recources\\";
        }
        public string GetRecourceFolder()
        {
            return recourcesFolder;
        }
    }
}

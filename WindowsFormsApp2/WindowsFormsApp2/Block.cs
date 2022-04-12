using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Block
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int FunctionInBlock { get; set; }
        public List<string> blockData { get; set; }
        public Block()
        {

        }

    }

}

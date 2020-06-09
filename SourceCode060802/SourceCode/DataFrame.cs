using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HID_PnP_Demo
{
    public class DataFrame
    {
        public UInt16 Index
        {
            get;
            set;
        }

        public Byte[] Data
        {
            get;
            set;
        }
    }
}

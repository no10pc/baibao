using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using baibao.Model;

namespace baibao.Common
{
    public class TransferMessage
    {
        public Menulist msg_menuitem { get; set; }
        public string msg_string { get; set; }
        public object msg_object { get; set; }
    }
}

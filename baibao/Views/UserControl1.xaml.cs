using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Text;

namespace baibao
{
    public partial class UserControl1 : UserControl
    {
        string strings = string.Empty;
        public UserControl1(List<string> list)
        {
            InitializeComponent();
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<!DOCTYPE html>");
            sb.Append(@"<html> ");
            sb.Append(@"<head> ");
            sb.Append(@"<title>Page Title</title> ");
            sb.Append(@"<meta name='viewport' content='width=device-width, initial-scale=1'>");
            sb.Append(@"<meta charset='utf-8'>");
            sb.Append(@"<link rel='stylesheet' href='http://tg.homeun.com/js/jquery.mobile-1.0.1.css' />");
            sb.Append(@"<script src='http://tg.homeun.com/js/jquery.js'></script>");
            sb.Append(@"<script src='http://tg.homeun.com/js/jquery.mobile-1.0.1.js'></script>");
            sb.Append(@"</head> ");
            sb.Append(@"<body style='backgournd:black;'> ");
            sb.Append(@"<ul data-role='listview' class='ui-listview'>");
            foreach (string str in list)
            {
                sb.Append(@"<li class='ui-li ui-li-static ui-body-c'>" + str + "</li>  ");
            }
            sb.Append(@"</ul>                             ");
            sb.Append(@"</body>");
            sb.Append(@"</html>");
            webBrowser1.NavigateToString(Unicode2HTML(sb.ToString()));
        }
        public string Unicode2HTML(string HTML)
        {
            StringBuilder str = new StringBuilder();
            char c;
            for (int i = 0; i < HTML.Length; i++)
            {
                c = HTML[i];
                if (Convert.ToInt32(c) > 127)
                {
                    str.Append("&#" + Convert.ToInt32(c) + ";");
                }
                else
                {
                    str.Append(c);
                }
            }
            return str.ToString();
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.CloseMeAsPopup();
            
        }

        
    }
}

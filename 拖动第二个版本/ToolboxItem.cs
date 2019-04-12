using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace 拖动第二个版本
{
    public class ToolboxItem : ContentControl
    {
     
        static ToolboxItem()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ToolboxItem), new FrameworkPropertyMetadata(typeof(ToolboxItem)));
        }
    }
}

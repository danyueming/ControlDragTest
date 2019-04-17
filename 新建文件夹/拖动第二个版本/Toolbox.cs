using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace 拖动第二个版本
{
    /// <summary>
    /// 工具箱，集合类
    /// </summary>
   public class Toolbox: ItemsControl
    {

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ToolboxItem();
        }

    
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return (item is ToolboxItem);
        }
    }
}

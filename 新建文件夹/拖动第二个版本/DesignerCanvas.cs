using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;

namespace 拖动第二个版本
{
    public class DesignerCanvas : Canvas
    {
        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
            DragObject dragObject = e.Data.GetData(typeof(DragObject)) as DragObject;
            if (dragObject != null && !String.IsNullOrEmpty(dragObject.Xaml))
            {

                Object content = XamlReader.Load(XmlReader.Create(new StringReader(dragObject.Xaml)));
                Point position = e.GetPosition(this);
                if (content != null)
                {
                    var testbtn = content as ImageButton;
                    this.Children.Add(testbtn);
                    Canvas.SetLeft(testbtn, position.X);
                    Canvas.SetTop(testbtn, position.Y);

                }

                e.Handled = true;
            }
        }
    }

    /// <summary>
    /// 拖动的数据
    /// </summary>
    public class DragObject
    {
        // Xaml string that represents the serialized content
        public String Xaml { get; set; }
    }
}

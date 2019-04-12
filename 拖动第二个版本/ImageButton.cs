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
    public class ImageButton : Button
    {
        public static readonly DependencyProperty ImgSourceProperty = DependencyProperty.Register
           ("ImgSource", typeof(ImageSource), typeof(ImageButton), null);

        public ImageSource ImgSource
        {
            get { return (ImageSource)GetValue(ImgSourceProperty); }
            set { SetValue(ImgSourceProperty, value); }
        }

        private Point? dragStartPoint = null;//拖拽的起点

        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);
            this.dragStartPoint = new Point?(e.GetPosition(this));
        }

        /// <summary>
        /// 按住左键移动
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                this.dragStartPoint = null;
            }
            bool result = this.Parent.GetType() == typeof(DesignerCanvas);
            if (this.dragStartPoint.HasValue && !result)
            {
                string xamlString = XamlWriter.Save(this);
                DragObject dataObject = new DragObject();
                dataObject.Xaml = xamlString;
                DragDrop.DoDragDrop(this, dataObject, DragDropEffects.Copy);
                e.Handled = true;
            }
        }

    }
}

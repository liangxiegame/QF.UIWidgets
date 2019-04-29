using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public class DefaultTextStyleBuilder
    {
        private Widget mChild;
        private TextStyle mStyle;
        private TextAlign? mTextAlign; 

        public DefaultTextStyleBuilder(Widget child)
        {
            mChild = child;
        }

        public DefaultTextStyleBuilder TextStyle(TextStyle style)
        {
            mStyle = style;
            return this;
        }

        public DefaultTextStyleBuilder TextAlignLeft()
        {
            mTextAlign = TextAlign.left;
            return this;
        }


        public DefaultTextStyle EndDefaultTextStyle()
        {
            return new DefaultTextStyle(child:mChild,style:mStyle,textAlign:mTextAlign);
        }
    }
}
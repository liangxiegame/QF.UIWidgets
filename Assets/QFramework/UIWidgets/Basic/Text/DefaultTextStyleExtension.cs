using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public static class DefaultTextStyleExtension
    {
        public static DefaultTextStyle DefaultTextStyle(this Widget self,TextStyle style,TextAlign textAlign)
        {
            return new DefaultTextStyle(child: self,style:style,textAlign:textAlign);
        }
        
        public static DefaultTextStyleBuilder DefaultTextStyle(this Widget self)
        {
            return new DefaultTextStyleBuilder(self);
        }
    }
}
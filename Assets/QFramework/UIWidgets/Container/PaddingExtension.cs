using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public static class PaddingExtension
    {
        public static Padding Padding(this Widget self, EdgeInsets padding)
        {
            return new Padding(child: self, padding: padding);
        }
    }
}
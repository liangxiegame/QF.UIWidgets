using System;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public class IconButtonBuilder : ButtonBuilder<IconButtonBuilder>
    {
        [Obsolete]
        public override IconButtonBuilder Child(Widget child)
        {
            throw new NotImplementedException();
        }

        public IconButtonBuilder Icon(Icon icon)
        {
            mChild = icon;
            return this;
        }

        public IconButton EndIconButton()
        {
            return new IconButton(
                icon: mChild,
                onPressed: mOnPressed,
                color: mColor,
                highlightColor: mHighlightColor,
                splashColor: mSplashColor,
                padding: mPadding
            );
        }
    }
}
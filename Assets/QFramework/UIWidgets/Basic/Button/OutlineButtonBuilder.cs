using Unity.UIWidgets.material;

namespace QFramework.UIWidgets
{
    public class OutlineButtonBuilder : ButtonBuilder<OutlineButtonBuilder>
    {
        public OutlineButton EndOutlineButton()
        {
            return new OutlineButton(
                child: mChild,
                onPressed: mOnPressed,
                textColor:mTextColor,
                disabledTextColor:mDisabledTextColor,
                color:mColor,
                highlightColor:mHighlightColor,
                splashColor:mSplashColor,
                padding:mPadding,
                shape:mShape
                );
        }
    }
}
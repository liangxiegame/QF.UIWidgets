using Unity.UIWidgets.material;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public class RaisedButtonBuilder : ButtonBuilder<RaisedButtonBuilder>
    {
        public RaisedButton EndRaisedButton()
        {
            return new RaisedButton(
                child: mChild,
                onPressed: mOnPressed,
                textColor: mTextColor,
                disabledTextColor: mDisabledTextColor,
                color: mColor,
                disabledColor: mDisabledColor,
                highlightColor: mHighlightColor,
                splashColor: mSplashColor,
                colorBrightness: mColorBrightness,
                padding: mPadding,
                shape: mShape
            );
        }
    }
}
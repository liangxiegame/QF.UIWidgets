using Unity.UIWidgets.material;

namespace QFramework.UIWidgets
{
    public class FlatButtonBuilder : ButtonBuilder<FlatButtonBuilder>
    {
        public FlatButton EndFlatButton()
        {
            
            return new FlatButton(
                child: mChild,
                onPressed: mOnPressed,
                textColor:mTextColor,
                disabledTextColor:mDisabledTextColor,
                color:mColor,
                disabledColor:mDisabledColor,
                highlightColor:mHighlightColor,
                splashColor:mSplashColor,
                colorBrightness:mColorBrightness,
                padding:mPadding,
                shape:mShape
                );
        }
    }
}
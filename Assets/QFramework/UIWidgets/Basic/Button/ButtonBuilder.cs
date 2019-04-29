using Unity.UIWidgets.painting;
using Unity.UIWidgets.service;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public class ButtonBuilder<T> where T : ButtonBuilder<T>
    {
        protected Widget       mChild { get; set; }
        protected VoidCallback mOnPressed = null;
        
        protected Color mTextColor {get;set;} //按钮文字颜色
        protected Color mDisabledTextColor {get;set;} //按钮禁用时的文字颜色
        protected Color mColor {get;set;} //按钮背景颜色
        protected Color mDisabledColor {get;set;}//按钮禁用时的背景颜色
        protected Color mHighlightColor {get;set;} //按钮按下时的背景颜色
        protected Color mSplashColor {get;set;} //点击时，水波动画中水波的颜色
        protected Brightness? mColorBrightness {get;set;}//按钮主题，默认是浅色主题 
        protected EdgeInsets mPadding {get;set;} //按钮的填充
        protected ShapeBorder mShape {get;set;} //外形


        public T TextColor(Color textColor)
        {
            mTextColor = textColor;
            return this as T;
            
        }

        public T DisabledTextColor(Color color)
        {
            mDisabledTextColor = color;
            return this as T;
        }


        public T Color(Color color)
        {
            mColor = color;
            return this as T;
        }


        public T DisabledColor(Color color)
        {
            mDisabledColor = color;
            return this as T;
        }

        public T HighlightColor(Color color)
        {
            mHighlightColor = color;
            return this as T;
        }

        public T SplashColor(Color color)
        {
            mSplashColor = color;
            return this as T;
        }


        public T ColorBrightness(Brightness brightness)
        {
            mColorBrightness = brightness;
            return this as T;
        }

        public T Padding(EdgeInsets padding)
        {
            mPadding = padding; 
            return this as T;
        }

        public T Shape(ShapeBorder shapeBorder)
        {

            mShape = shapeBorder;
            return this as T;
        } 

        public virtual T Child(Widget child)
        {
            mChild = child;
            return this as T;
        }

        public  T OnPressed(VoidCallback onPressed)
        {
            mOnPressed = onPressed;
            return this as T;
        }
    }
}
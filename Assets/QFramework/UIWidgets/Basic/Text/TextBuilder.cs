using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine.Networking;

namespace QFramework.UIWidgets
{
    public class TextBuilder
    {
        private string mData     { get; set; }

        private TextStyleBuilder mStyleBuilder { get; set; } = new TextStyleBuilder();



        public static TextBuilder GetBuilder()
        {
            return new TextBuilder();
        }

        public TextBuilder Data(string data)
        {
            mData = data;
            return this;
        }

        public TextBuilder FontSize(float fontSize)
        {
            mStyleBuilder.FontSize(fontSize);
            return this;
        }

        public TextBuilder FontBold()
        {
            mStyleBuilder.FontWeight = FontWeight.bold;
            return this;
        }

        public Text EndText()
        {
            return new Text(
                data: mData,
                textAlign: mTextAlign,
                maxLines: mMaxLines,
                style: mStyleBuilder.Build(),
                overflow: mTextOverflow,
                textScaleFactor: mScaleFactor);

        }

        private TextAlign? mTextAlign;

        public TextBuilder TextAlignCenter()
        {

            mTextAlign = TextAlign.center;
            return this;
        }

        private int? mMaxLines;
        
        public TextBuilder MaxLines(int line)
        {
            mMaxLines = line;    
            return this;
        }

        private TextOverflow? mTextOverflow;
        
        public TextBuilder OverflowEllipsis()
        {
            mTextOverflow = TextOverflow.ellipsis;
            return this;
        }
        
        public TextBuilder OverflowFade()
        {
            mTextOverflow = TextOverflow.fade;
            return this;
        }
        
        public TextBuilder OverflowClip()
        {
            mTextOverflow = TextOverflow.clip;
            return this;
        }

        private float? mScaleFactor;
        
        public TextBuilder TextScaleFactor(float scaleFactor)
        {
            mScaleFactor = scaleFactor;    
            return this;
        }

        public TextBuilder FontColor(Color color)
        {
            mStyleBuilder.Color = color;
            return this;
        }

        public TextBuilder Height(float height)
        {
            mStyleBuilder.Height = height;
            return this;
        }

        public TextBuilder FontFamily(string fontFamily)
        {
            mStyleBuilder.FontFamily = fontFamily;
            return this;
        }

        public TextBuilder BackgroundColor(Color bgColor)
        {
            mStyleBuilder.BackgroundPaint = new Paint()
            {
                color = bgColor
            };
            return this;
        }

        public TextBuilder Underline()
        {
            mStyleBuilder.TextDecoration = TextDecoration.underline;
            return this;
        }

        public TextBuilder DecorationStyleSolid()
        {
            mStyleBuilder.TextDecorationStyle = TextDecorationStyle.solid;
            return this;
        }

        public TextBuilder Inherit(bool inherit)
        {
            mStyleBuilder.Inherit = inherit;
            return this;
        }
    }
}
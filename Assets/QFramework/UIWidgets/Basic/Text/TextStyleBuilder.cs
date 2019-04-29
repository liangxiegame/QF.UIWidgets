using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;

namespace QFramework.UIWidgets
{
    public class TextStyleBuilder
    {
        private float? mFontSize { get; set; }

        public FontWeight FontWeight { get; set; }
            
        public Color Color { get; set; }
            
        public float? Height { get; set; }
            
        public string FontFamily { get; set; }
            
        public Paint BackgroundPaint { get; set; }
            
        public TextDecoration TextDecoration { get; set; }
            
        public TextDecorationStyle? TextDecorationStyle { get; set; }
        public bool Inherit { get; set; } = true;

        public TextStyle Build()
        {
            return new TextStyle(
                fontSize:mFontSize,
                fontWeight:FontWeight,
                color:Color,
                height:Height,
                fontFamily:FontFamily,
                background:BackgroundPaint,
                decoration:TextDecoration,
                decorationStyle:TextDecorationStyle,
                inherit:Inherit);
        }
        
        public TextStyle EndTextStyle()
        {
            return Build();
        }


        public TextStyleBuilder FontColor(Color color)
        {
            Color = color;
            return this;
        }
        
        public TextStyleBuilder FontSize(float fontSize)
        {
            mFontSize = fontSize;
            return this;
        }
    }
}
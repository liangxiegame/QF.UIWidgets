using System;
using System.Collections.Generic;
using Unity.UIWidgets.gestures;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;

namespace QFramework.UIWidgets
{
    public class TextSpanBuilder
    {
        private List<TextSpan> mChildren = new List<TextSpan>();
        
        private TextStyleBuilder mStyleBuilder = new TextStyleBuilder();

        private GestureRecognizer mRecognizer = null;
        
        private string mText;
        public TextSpanBuilder Child(TextSpan child)
        {
            mChildren.Add(child);
            return this;
        }

        public TextSpanBuilder Text(string text)
        {
            mText = text;
            return this;
        }

        public TextSpanBuilder OnTap(GestureTapCallback onTapCallback)
        {
            mRecognizer = new TapGestureRecognizer()
            {
                onTap = onTapCallback
            };
            return this;
        }


        public TextSpanBuilder FontColor(Color color)
        {
            mStyleBuilder.Color = color;
            return this;
        }

        public TextSpan EndTextSpan()
        {
            return new TextSpan(
                style: mStyleBuilder.Build(),
                text: mText,
                children: mChildren,
                recognizer:mRecognizer);
        }
    }
}
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public static partial class QF
    {
        public static WrapBuilder Wrap => new WrapBuilder();
    }

    public class WrapBuilder : LayoutBuilder<WrapBuilder>
    {
        
        private WrapCrossAlignment mCrossAxisAlignment = WrapCrossAlignment.start;
        private VerticalDirection  mVerticalDirection  = VerticalDirection.down;
        private TextDirection?     mTextDirection      = null;
        private WrapAlignment mAlignment = WrapAlignment.start;
        private float mSpacing = 0.0f;
        private WrapAlignment mRunAlignment = WrapAlignment.start;
        private float mRunSpacing = 0.0f;
            
        public WrapBuilder TextDirectionRTL()
        {
            mTextDirection = TextDirection.rtl;
            return this;
        }


        public WrapBuilder AlignmentCenter()
        {
            mAlignment = WrapAlignment.center;
            return this;
        }
        
        public WrapBuilder AlignmentEnd()
        {
            mAlignment = WrapAlignment.end;
            return this;
        }

        public WrapBuilder VerticalDirectionUp()
        {
            mVerticalDirection = VerticalDirection.up;
            return this;
        }

        public WrapBuilder WrapCrossAlignmentStart()
        {
            mCrossAxisAlignment = WrapCrossAlignment.start;
            return this;
        }

        public WrapBuilder WrapCrossAlignmentCenter()
        {
            mCrossAxisAlignment = WrapCrossAlignment.center;
            return this;
        }

        public Wrap EndWrap()
        {
            return new Wrap(
                children: mChildren,
                crossAxisAlignment: mCrossAxisAlignment,
                alignment: mAlignment,
                spacing: mSpacing,
                runAlignment: mRunAlignment,
                runSpacing: mRunSpacing,
                verticalDirection: mVerticalDirection,
                textDirection: mTextDirection
            );
        }

        public WrapBuilder Spacing(float spacing)
        {
            mSpacing = spacing;
            return this;
        }

        public WrapBuilder RunSpacing(float runSpacing)
        {
            mRunSpacing = runSpacing;
            return this;
        }
    }
}
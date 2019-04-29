using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public static partial class QF
    {
        public static StackBuilder Stack => new StackBuilder();
    }

    public class StackBuilder : LayoutBuilder<StackBuilder>
    {
        private Alignment mAlignment = null;
        private StackFit  mFit       = StackFit.loose;

        public StackBuilder AlignmentCenter()
        {
            mAlignment = Alignment.center;
            return this;
        }


        public StackBuilder FitExpand()
        {
            mFit = StackFit.expand;
            return this;
        }

        public Stack EndStack()
        {
            return new Stack(
                children: mChildren,
                alignment: mAlignment,
                fit: mFit
            );
        }
    }
}
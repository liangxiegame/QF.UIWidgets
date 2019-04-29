using Unity.UIWidgets.rendering;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public static partial class QF
    {
        public static ConstrainedBoxBuilder ConstrainedBox => new ConstrainedBoxBuilder();
    }

    public static class PositionedExtension
    {
        public static Positioned Positioned(this Widget self, float? left = null, float? top = null,
            float? right = null, float? bottom = null, float? width = null, float? height = null)
        {
            return new Positioned(child: self,
                left: left,
                top: top,
                right: right,
                bottom: bottom,
                width: width,
                height: height
            );
        }
    }

    public class ConstrainedBoxBuilder
    {
        private BoxConstraints mConstraints = null;
        private Widget         mChild       = null;


        public ConstrainedBoxBuilder Child(Widget child)
        {
            mChild = child;
            return this;
        }

        public ConstrainedBoxBuilder Constraints(BoxConstraints constraints)
        {
            mConstraints = constraints;
            return this;
        }

        public ConstrainedBox EndConstrainedBox()
        {
            return new ConstrainedBox(constraints: mConstraints, child: mChild);
        }
    }
}
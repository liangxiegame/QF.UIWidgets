using TodoListUIWidgets;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public class FlexBuilder : LayoutBuilder<FlexBuilder>
    {
        private Axis mDirection = Axis.vertical;

        public FlexBuilder DirectionHorizontal()
        {
            mDirection = Axis.horizontal;
            return this;
        }

        public Flex EndFlex()
        {
            return new Flex(
                direction: mDirection,
                children: mChildren,
                crossAxisAlignment: mCrossAxisAlignment
            );
        }
    }

    public static class ExpandedExtension
    {
        public static Expanded Expanded<T>(this T self, int flex = 1) where T : Widget
        {
            return new Expanded(child: self, flex: flex);
        }
    }
}
using System.Collections.Generic;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public class RowBuilder : LayoutBuilder<RowBuilder>
    {
        private MainAxisAlignment  mMainAxisAlignment  = MainAxisAlignment.start;
        private CrossAxisAlignment mCrossAxisAlignment = CrossAxisAlignment.center;
        private MainAxisSize       mMainAxisSize       = MainAxisSize.max;
        private VerticalDirection  mVerticalDirection  = VerticalDirection.down;
        private TextDirection?     mTextDirection      = null;

        public RowBuilder TextDirectionRTL()
        {
            mTextDirection = TextDirection.rtl;
            return this;
        }


        public RowBuilder MainAxisAlignmentCenter()
        {
            mMainAxisAlignment = MainAxisAlignment.center;
            return this;
        }
        
        public RowBuilder MainAxisAlignmentEnd()
        {
            mMainAxisAlignment = MainAxisAlignment.end;
            return this;
        }
        
        public RowBuilder MainAxisAlignmentSpaceAround()
        {
            mMainAxisAlignment = MainAxisAlignment.spaceAround;
            return this;
        }

        public RowBuilder VerticalDirectionUp()
        {
            mVerticalDirection = VerticalDirection.up;
            return this;
        }

        public RowBuilder MainAxisSizeMin()
        {
            mMainAxisSize = MainAxisSize.min;
            return this;
        }

        public RowBuilder CrossAxisAlignmentStart()
        {
            mCrossAxisAlignment = CrossAxisAlignment.start;
            return this;
        }

        public RowBuilder CrossAxisAlignmentCenter()
        {
            mCrossAxisAlignment = CrossAxisAlignment.center;
            return this;
        }

        public Row EndRow()
        {
            return new Row(
                children: mChildren,
                crossAxisAlignment: mCrossAxisAlignment,
                mainAxisAlignment: mMainAxisAlignment,
                mainAxisSize: mMainAxisSize,
                verticalDirection: mVerticalDirection,
                textDirection: mTextDirection
            );
        }
    }
}
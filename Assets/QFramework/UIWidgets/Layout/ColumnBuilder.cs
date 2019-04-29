using System.Collections.Generic;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public class ColumnBuilder : LayoutBuilder<ColumnBuilder>
    {
        public Column EndColumn()
        {
            return new Column(children:mChildren,crossAxisAlignment:mCrossAxisAlignment);
        }
    }
}
using System.Collections.Generic;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public class LayoutBuilder<T> where T : LayoutBuilder<T>
    {
        protected List<Widget> mChildren = new List<Widget>();

        public T Child(Widget child)
        {
            mChildren.Add(child);
            return this as T;
        }
        
        public T Children(List<Widget> children)
        {
            mChildren.AddRange(children);
            return this as T;
        }

        protected CrossAxisAlignment mCrossAxisAlignment = CrossAxisAlignment.center;

        public T CrossAxisAlignmentStart()
        {
            mCrossAxisAlignment = CrossAxisAlignment.start;
            return this as T;
        }
    }
}
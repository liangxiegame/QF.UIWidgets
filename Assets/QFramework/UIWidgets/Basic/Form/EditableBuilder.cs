using Unity.UIWidgets.foundation;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets.Basic.Form
{
    public class EditableBuilder<T>  where T : EditableBuilder<T>
    {
        protected TextEditingController mController;
        
        protected FocusNode mFocusNode = new FocusNode();
                
        protected Color mCursorColor = Color.black;


        protected int? mMaxLine = 1;

        protected int mFontSize;

        protected ValueChanged<string> mOnValueChanged = null;
        protected ValueChanged<string> mOnSubmit       = null;


        public T InitData(string initData)
        {
            mController = new TextEditingController(initData);
            return this as T;
        }
        
        public T Controller(TextEditingController controller)
        {
            mController = controller;
            return this as T;
        }

        public T FocusNode(FocusNode focusNode)
        {
            mFocusNode = focusNode;
            return this as T;
        }

        public T FontSize(int size)
        {
            mFontSize = size;
            return this as T;
        }

        public T OnValueChanged(ValueChanged<string> onValueChanged)
        {
            mOnValueChanged = onValueChanged;
            return this as T;
        }

        public T OnSubmit(ValueChanged<string> onSubmit)
        {
            mOnSubmit = onSubmit;
            return this as T;
        }

        public T MaxLine(int line)
        {
            mMaxLine = line;
            return this as T;
        }
    }
}
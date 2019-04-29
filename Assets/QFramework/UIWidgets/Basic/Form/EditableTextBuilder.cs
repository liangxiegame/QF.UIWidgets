using QFramework.UIWidgets.Basic.Form;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public class EditableTextBuilder : EditableBuilder<EditableTextBuilder>
    {
        public EditableText EndEditableText()
        {
            return new EditableText(
                mController == null ? new TextEditingController() : mController,
                mFocusNode,
                style: mFontSize == 0 ? null : new TextStyle(fontSize: mFontSize),
                mCursorColor,
                maxLines: mMaxLine,
                onChanged: mOnValueChanged,
                onSubmitted: mOnSubmit);
        }
    }
}
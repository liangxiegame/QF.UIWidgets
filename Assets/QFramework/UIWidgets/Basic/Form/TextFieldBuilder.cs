using QFramework.UIWidgets.Basic.Form;
using QFramework.UIWidgets.Form;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public partial class QF
    {
        public static TextFieldBuilder TextField => new TextFieldBuilder();
    }

    public class TextFieldBuilder : EditableBuilder<TextFieldBuilder>
    {
        private bool mAutoFocus = false;

        public TextFieldBuilder AutoFocus()
        {
            mAutoFocus = true;
            return this;
        }

        InputDecorationBuilder mInputDecorationBuilder = new InputDecorationBuilder();

        private bool mObscureText = false;

        public TextFieldBuilder ObscureText()
        {
            mObscureText = true;
            return this;
        }

        public TextFieldBuilder LabelText(string labelText)
        {
            mInputDecorationBuilder.LabelText = labelText;
            return this;
        }


        public TextFieldBuilder HintText(string hintText)
        {
            mInputDecorationBuilder.HintText = hintText;
            return this;
        }

        public TextFieldBuilder PrefixIcon(Icon icon)
        {
            mInputDecorationBuilder.PrefixIcon = icon;
            return this;
        }


        public TextField EndTextField()
        {
            return new TextField(
                controller: mController,
                focusNode: mFocusNode,
                autofocus: mAutoFocus,
                decoration: mInputDecorationBuilder.Build(),
                obscureText: mObscureText,
                onChanged: mOnValueChanged,
                onSubmitted: mOnSubmit);
        }
    }
}
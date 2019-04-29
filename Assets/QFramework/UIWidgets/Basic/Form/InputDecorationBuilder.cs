using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets.Form
{
    public class InputDecorationBuilder
    {
        public string LabelText;

        public string HintText;

        public Icon PrefixIcon;

        public InputDecoration Build()
        {
            return new InputDecoration(
                labelText: LabelText,
                hintText: HintText,
                prefixIcon: PrefixIcon
            );
        }
    }
}
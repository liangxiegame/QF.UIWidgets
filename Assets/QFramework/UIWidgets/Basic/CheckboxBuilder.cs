using Unity.UIWidgets.foundation;
using Unity.UIWidgets.material;
using Unity.UIWidgets.ui;

namespace QFramework.UIWidgets
{
    public partial class QF
    {
        public static CheckboxBuilder Checkbox => new CheckboxBuilder();
    }

    public class CheckboxBuilder
    {
        private bool? mValue;

        private ValueChanged<bool?> mOnChanged;

        private Color mActiveColor;

        public CheckboxBuilder ActiveColor(Color color)
        {
            mActiveColor = color;
            return this;
        }

        public CheckboxBuilder Value(bool value)
        {
            mValue = value;
            return this;
        }

        public CheckboxBuilder OnChanged(ValueChanged<bool?> onChanged)
        {
            mOnChanged = onChanged;
            return this;
        }

        public Checkbox EndCheckbox()
        {
            return new Checkbox(
                value: mValue,
                onChanged: mOnChanged,
                activeColor: mActiveColor
            );
        }
    }
}
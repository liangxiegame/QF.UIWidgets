using System.Runtime.InteropServices.WindowsRuntime;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.material;
using Unity.UIWidgets.ui;

namespace QFramework.UIWidgets
{
    public partial class QF
    {
        public static SwitchBuilder Switch => new SwitchBuilder();
    }
    
    public class SwitchBuilder
    {
        private bool? mValue;

        private ValueChanged<bool?> mOnChanged;

        private Color mActiveColor;

        public SwitchBuilder ActiveColor(Color color)
        {
            mActiveColor = color;
            return this;
        }
        
        public SwitchBuilder Value(bool value)
        {
            mValue = value;
            return this;
        }

        public SwitchBuilder OnChanged(ValueChanged<bool?> onChanged)
        {
            mOnChanged = onChanged;
            return this;
        }

        public Switch EndSwitch()
        {
            return new Switch(
                value: mValue,
                onChanged: mOnChanged,
                activeColor: mActiveColor
            );
        }
    }
}
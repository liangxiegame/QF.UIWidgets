using Unity.UIWidgets.gestures;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public static class GestureDetectorExtension
    {
        public static GestureDetector OnTap(this Widget self, GestureTapCallback onTap)
        {
            return new GestureDetector(child: self, onTap: onTap);
        }
    }
}
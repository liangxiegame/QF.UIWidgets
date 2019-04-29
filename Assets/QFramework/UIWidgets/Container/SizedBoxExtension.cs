using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public static class SizedBoxExtension
    {
        public static SizedBox SizedBox(this Widget self, float? width = null, float? height = null)
        {
            return new SizedBox(child: self,
                width: width,
                height: height);
        }
    }
}
using System.Runtime.CompilerServices;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public static class DecoratedBoxExtensions
    {
        public static DecoratedBox DecoratedBox(this Widget self,Decoration decoration)
        {
            return new DecoratedBox(child:self,decoration:decoration);
        }
    }
}
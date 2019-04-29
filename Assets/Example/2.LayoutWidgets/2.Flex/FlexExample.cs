using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class FlexExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return
                QF.Flex
                    .Child(
                        QF.Container
                            .Color(Colors.blue)
                            .EndContainer()
                            .Expanded(1))
                    .Child(
                        QF.Container
                            .Color(Colors.red)
                            .EndContainer()
                            .Expanded(9))
                    .EndFlex();
        }
    }
}
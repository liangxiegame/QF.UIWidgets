using Unity.UIWidgets.engine;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class StateExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new Counter();
        }

        class Counter : StatefulWidget
        {
            public override State createState()
            {
                return new CounterState();
            }
        }

        class CounterState : State<Counter>
        {
            private int mCount { get; set; } = 0;

            public override Widget build(BuildContext context)
            {
                return new GestureDetector(
                    child: new Text("Click Count:" + mCount, style: new TextStyle(fontSize: 30)),
                    onTap: () =>
                    {
                        this.mCount++;
                        this.setState(() => { this.mCount++; });
                    }
                );
            }
        }
    }
}
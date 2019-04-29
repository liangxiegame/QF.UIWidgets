using System.Collections.Generic;
using System.Linq;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.gestures;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class GradientButtonExample : UIWidgetsPanel
    {
        void onTap(){
            print("button click");
        }

        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body: new Container(
                        child: new Column(
                            children: new List<Widget>
                            {
                                new GradientButton(
                                    colors: new List<Color> {Colors.orange, Colors.red},
                                    height: 50.0f,
                                    child: new Text("Submit"),
                                    onTap: onTap
                                ),
                                new GradientButton(
                                    height: 50.0f,
                                    colors: new List<Color> {Colors.lightGreen, Colors.green[700]},
                                    child: new Text("Submit"),
                                    onTap: onTap
                                ),
                                new GradientButton(
                                    height: 50.0f,
                                    colors: new List<Color> {Colors.lightBlue[300], Colors.blueAccent},
                                    child: new Text("Submit"),
                                    onTap: onTap
                                )
                            }
                        )
                    )));
        }

        class GradientButton : StatelessWidget
        {
            // 渐变色数组
            List<Color> colors;

            // 按钮宽高
            float width;
            float height;

            Widget child;

            //点击回调
            GestureTapCallback onTap;

            public GradientButton(
                List<Color> colors,
                float height,
                GestureTapCallback onTap,
                Widget child,
                float width = float.MaxValue)
            {
                this.colors = colors;
                this.width = width;
                this.height = height;
                this.onTap = onTap;
                this.child = child;
            }

            public override Widget build(BuildContext context)
            {
                ThemeData theme = Theme.of(context);

                //确保colors数组不空
                List<Color> _colors = colors ??
                                      new List<Color>()
                                      {
                                          theme.primaryColor,
                                          theme.primaryColorDark ?? theme.primaryColor
                                      };
                return new DecoratedBox(
                    decoration: new BoxDecoration(
                        gradient: new LinearGradient(colors: _colors)
                    ),
                    child: new Material(
                        type: MaterialType.transparency,
                        child: new InkWell(
                            splashColor: colors.Last(),
                            highlightColor: Colors.transparent,
                            onTap: onTap,
                            child: new ConstrainedBox(
                                constraints: BoxConstraints.tightFor(height: height, width: width),
                                child: new Center(
                                    child: new Padding(
                                        padding: EdgeInsets.all(8.0f),
                                        child: new DefaultTextStyle(
                                            style: new TextStyle(fontWeight: FontWeight.bold),
                                            child: child)
                                    )
                                )
                            )
                        )
                    )
                );
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;
using UnityEngine;


namespace LearnUIWidgets
{
    public class RouteTransitionExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home:new Scaffold(
                    body:new PageA()
                    )
                );
        }

        class PageA : StatelessWidget
        {
            public override Widget build(BuildContext context)
            {
                return QF.Column
                    .Child(QF.RaisedButton
                        .Child(QF.Text.Data("打开页面").EndText())
                        .OnPressed(() =>
                        {
                            Navigator.push(context, new FadeRoute(
                                transitionDurationm: TimeSpan.FromMilliseconds(500),
                                builder: (buildContext => { return new PageB(); })));
                        })
                        .EndRaisedButton())
                    .EndColumn();
            }
        }
        
        class PageB : StatelessWidget
        {
            public override Widget build(BuildContext context)
            {
                return
                    QF.Container
                        .Color(Colors.blue)
                        .PaddingAll(0)
                        .Child(
                            QF.Column
                                .Child(QF.RaisedButton
                                    .Child(QF.Text.Data("返回").EndText())
                                    .OnPressed(() =>
                                    {
                                        Navigator.push(context, new PageRouteBuilder(
                                            transitionDuration: TimeSpan.FromMilliseconds(500),
                                            pageBuilder: (buildContext, animation1, secondaryAnimation) => new RotationTransition(
                                                turns: animation1,
                                                child: new PageA()
                                            )));
                                        
                                    })
                                    .EndRaisedButton())
                                .EndColumn())
                        .EndContainer();
            }
        }

        class FadeRoute : PageRoute
        {
            public FadeRoute(
                WidgetBuilder builder,
                TimeSpan transitionDurationm,
                RouteSettings settings =null, 
                bool fullscreenDialog = false) : base(settings, fullscreenDialog)
            {
                this.builder = builder;
                this.transitionDuration = transitionDurationm;
            }

            private WidgetBuilder builder;


            public override TimeSpan transitionDuration { get; }


            public override Widget buildPage(BuildContext context, Animation<float> animation,
                Animation<float> secondaryAnimation)
            {
                return builder(context);
            }

            public override Widget buildTransitions(BuildContext context, Animation<float> animation,
                Animation<float> secondaryAnimation, Widget child)
            {
                return new FadeTransition(
                    opacity: animation,
                    child: builder(context)
                );
            }
        }
    }
}
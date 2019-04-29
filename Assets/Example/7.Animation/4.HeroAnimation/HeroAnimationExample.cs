using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class HeroAnimationExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body: new HeroAnimationRoute()
                )
            );
        }

        class HeroAnimationRoute : StatelessWidget
        {
            public override Widget build(BuildContext context)
            {
                return QF.Container
                    .AlignmentTopCenter()
                    .Child(new InkWell(
                        child: new Hero(
                            tag: "unity",
                            child: Image.asset("unity-black", width: 50, height: 50)
                        ),
                        onTap: () =>
                        {
                            Navigator.push(context, new PageRouteBuilder(
                                pageBuilder: (buildContext, animation1, secondaryAnimation) => new FadeTransition(
                                    opacity: animation1,
                                    child:new Scaffold(
                                        appBar: new AppBar(title: new Text("原图")),
                                        body: new HeroAnimationRouteB()
                                    )
                                )));
                        }))
                    .EndContainer();
            }
        }

        class HeroAnimationRouteB : StatelessWidget
        {
            public override Widget build(BuildContext context)
            {
                return new Center(
                    child:new Hero(
                        tag:"unity",
                        child: Image.asset("unity-black")
                        )
                    );
            }
        }


    }
}
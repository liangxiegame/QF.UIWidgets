using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QFramework.UIWidgets;
using RSG;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.scheduler;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class UnfiniteListViewExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(home:new Scaffold(body:new UnfiniteListViewWidget()));
        }

        class UnfiniteListViewWidget : StatefulWidget
        {
            public override State createState()
            {
                return new UnfinitelistViewState();
            }
        }

        class UnfinitelistViewState : State<UnfiniteListViewWidget>
        {
            
            static string LoadingTag  = "##loading##"; //表尾标记
            
            
            List<string> mWords = new List<string>()
            {
                LoadingTag
            };

            
            string GenerateWord(int i)
            {
                return "Hello" + i;
            }

            void RetrieveData()
            {
                Promise.Delayed(TimeSpan.FromSeconds(2))
                    .Then(() =>
                    {
                        mWords.InsertRange(mWords.Count - 1,
                            //每次生成20个单词
                            Enumerable.Range(0, 10).Select(GenerateWord).ToList()
                        );
                        setState(() =>
                        {
                            //重新构建列表
                        });
                    });
            }


            public override Widget build(BuildContext context)
            {
                return ListView.seperated(
                    itemCount:mWords.Count,
                    itemBuilder:((buildContext, index) =>
                    {
                        //如果到了表尾
                        if (mWords[index] == LoadingTag)
                        {
                            //不足100条，继续获取数据
                            if (mWords.Count - 1 < 100)
                            {
                                // 获取数据
                                RetrieveData();

                                return QF.Container
                                    .PaddingAll(16)
                                    .AlignmentCenter()
                                    .Child(new CircularProgressIndicator(
                                        strokeWidth: 2.0f
                                    ).SizedBox(24.0f, 24.0f))
                                    .EndContainer();
                            }
                            else
                            {
                                return QF.Container
                                    .AlignmentCenter()
                                    .PaddingAll(16)
                                    .Child(QF.Text
                                        .Data("没有更多了")
                                        .FontColor(Colors.grey)
                                        .EndText())
                                    .EndContainer();
                            }
                        }

                        return new ListTile(title: new Text(mWords[index]));
                    }),
                    separatorBuilder:((buildContext, index) => new Divider(height:0))
                    );
            }
            
            
        }
        
    }
}
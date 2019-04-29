using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class ListViewBuilderExample : UIWidgetsPanel
    {
        List<int> mListData = new List<int>();

        protected override Widget createWidget()
        {
            for (int i = 0; i < 1000; i++)
            {
                mListData.Add(i);
            }
            
            var divider =new Divider(color: Colors.blue);
            var emptydivider =new Divider(color: Colors.white);


            return new MaterialApp(
                home: new Scaffold(
//                    body: ListView.builder(
                    body: ListView.seperated(
                        itemCount: mListData.Count,
                        separatorBuilder: (context, index) =>
                        {
                            if (index % 5 == 0)
                            {
                                return divider;
                            }
                            else
                            {
                                return emptydivider;
                            }
                        },
                        itemBuilder: (context, index) => new ListTile(
                            title: QF.Text.Data(mListData[index].ToString()).EndText()
                        )
                    )
                )

            );
        }
    }
}
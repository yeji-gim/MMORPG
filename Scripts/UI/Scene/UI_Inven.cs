using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   
public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel
    }
    void Start()
    {
        Init();
    }


    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform)
            Manager.Resource.Destroy(child.gameObject);

        // ���� �κ��丮 ������ �����ؼ�
        for(int i=0; i<8;i++)
        {

            GameObject item = Manager.UI.MakeSubItem<UI_Inven_Item>(gridPanel.transform).gameObject;
            //item.transform.SetParent(gridPanel.transform);
            // item.GetOrAddComponent<>
            UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>();
            invenItem.SetInfo($"�����{i}��");
        }
    }
}


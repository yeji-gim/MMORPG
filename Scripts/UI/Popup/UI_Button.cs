using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    [SerializeField]
    Text _text;

    enum Buttons
    {
        PointButton,
    }
    enum Texts
    {
        PoinText,
        scoreText,
    }
    enum GameObjects
    {
        TestObject,
    }

    enum Images
    {
        ItemIcon,
    }
    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        //

        GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);
        GameObject go = Get<Image>((int)Images.ItemIcon).gameObject;

        BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
    }

    int _score = 0;
    public void OnButtonClicked(PointerEventData data)
    {
        _score++;
        Get<Text>((int)Texts.scoreText).text = $"Á¡¼ö :{_score}";

    }
}


using System; // 추가하기
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;
    bool _pressed = false;

   public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        /* 마우스 입력 */
        if(Input.GetMouseButton(0)) // 마우스 누르는 중
        {
            MouseAction.Invoke(Define.MouseEvent.Press); // 마우스를 누르고 있을 땐 Define.MouseEvent.Press을 인수로 넘겨 액션에 등록된 함수들 실행
            _pressed = true; // 누르는 중이었음을 표시
        }
        else // 누르는 중이 아님
        {
            if (_pressed) // 누르는 중이 아닌데 눌렀었다면 뗀 것
                MouseAction.Invoke(Define.MouseEvent.Click); // 마우스를 누르다 뗐을 땐 Define.MouseEvent.Click을 인수로 넘겨 액션에 등록된 함수들 실행
            _pressed = false;
        }
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}


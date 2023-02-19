using System; // �߰��ϱ�
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

        /* ���콺 �Է� */
        if(Input.GetMouseButton(0)) // ���콺 ������ ��
        {
            MouseAction.Invoke(Define.MouseEvent.Press); // ���콺�� ������ ���� �� Define.MouseEvent.Press�� �μ��� �Ѱ� �׼ǿ� ��ϵ� �Լ��� ����
            _pressed = true; // ������ ���̾����� ǥ��
        }
        else // ������ ���� �ƴ�
        {
            if (_pressed) // ������ ���� �ƴѵ� �������ٸ� �� ��
                MouseAction.Invoke(Define.MouseEvent.Click); // ���콺�� ������ ���� �� Define.MouseEvent.Click�� �μ��� �Ѱ� �׼ǿ� ��ϵ� �Լ��� ����
            _pressed = false;
        }
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}


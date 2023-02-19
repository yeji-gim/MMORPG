using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    Vector3 _destPos;
    void Start()
    {

        Manager.Input.MouseAction -= OnMouseClicked;
        Manager.Input.MouseAction += OnMouseClicked;

       // 
    }
    float _yAngle = 0.0f;


    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
        
    }
    PlayerState _state = PlayerState.Idle;


    void Update()
    {
        void UpdateDie()
        {
            // �ƹ��͵� ����
        }
        void UpdateMoving()
        {
            Vector3 dir = _destPos - transform.position; // dir �� ����� ũ�Ⱑ �Ѵ� ������ ����
            if (dir.magnitude < 0.0001f)
            {
                _state = PlayerState.Idle;
            }
            else
            {
                float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);

                transform.position += dir.normalized * moveDist;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
                transform.LookAt(_destPos);
            }
            // �ִϸ��̼�
            Animator anim = GetComponent<Animator>();
            // ���� ���� ������ �Ѱ��ش�
            anim.SetFloat("speed", _speed);
       
   
        }
       
        void UpdateIdle()
        {
   
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("speed", 0);
    
        }

        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
                    
        }
        
       

    }

    
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (_state == PlayerState.Die)
            return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0F, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall"))) // 8���� Monstar�����Ƿ� Monstar�� RayCasting�� �ɸ��� �� ��
        {
            _destPos = hit.point;
            _state = PlayerState.Moving;
            //Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        }
    }
}


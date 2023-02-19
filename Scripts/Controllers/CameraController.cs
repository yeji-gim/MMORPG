using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   
public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuaterView;

    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);

    [SerializeField]
    GameObject _player = null;
    void Start()
    {
      
    }

   
    // Update 문에 있으면 문제가 되는 이유
    // Player 둘다 업데이트 문에 있으므로 누가 먼저 업데이트 됐는지 몰라서 덜덜 떨린다.
    // 문제 해결 : Player update 된 후 이동하기 -> LateUpdate()
    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuaterView)
        {
            RaycastHit hit;
            if (Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
                transform.position = _player.transform.position + _delta.normalized * dist;
            }
        }
        else
        {
            transform.position = _player.transform.position + _delta;
            transform.LookAt(_player.transform); // 무조건 상대 오브젝트 트랜스폼을 강제로 로테이션 시킴
        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuaterView;
        _delta = delta;
    }
}


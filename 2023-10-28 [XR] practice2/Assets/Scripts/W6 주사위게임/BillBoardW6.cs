using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardW6 : MonoBehaviour
{
    public Transform CamTr;

    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // 방법 1 - 상위 오브젝트 추가
        tr.LookAt(CamTr.position);

        // 방법 2 - 로테이션 추가
        // tr.LookAt(CamTr.position);
        // tr.Rotate(0, 180, 0);

        // 방법 3 - W7
        //tr.LookAt(CamTr.position, Vector3 up); //뭐임 왜 Vector3 up을? y축 방향으로 회전하란 것 같은디
    }
}

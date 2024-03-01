using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardW4 : MonoBehaviour
{
    public Transform camTr; // 캠
    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // 카메라 방향으로 회전
        tr.LookAt(camTr.position);
        // tr.Rotate(0,180,0);
    }
}

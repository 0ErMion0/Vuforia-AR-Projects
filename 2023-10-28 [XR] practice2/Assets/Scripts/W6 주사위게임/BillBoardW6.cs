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
        // ��� 1 - ���� ������Ʈ �߰�
        tr.LookAt(CamTr.position);

        // ��� 2 - �����̼� �߰�
        // tr.LookAt(CamTr.position);
        // tr.Rotate(0, 180, 0);

        // ��� 3 - W7
        //tr.LookAt(CamTr.position, Vector3 up); //���� �� Vector3 up��? y�� �������� ȸ���϶� �� ������
    }
}

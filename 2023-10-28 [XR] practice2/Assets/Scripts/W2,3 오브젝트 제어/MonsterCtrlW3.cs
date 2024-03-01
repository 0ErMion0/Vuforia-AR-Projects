using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrlW3 : MonoBehaviour
{
    // ���� ��ȯ �� �÷��̾� ������ �̵�
    public float speed;
    Vector3 moveDir;

    void Start()
    {
        // [ ���� ��ȯ ]
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        moveDir = player.transform.position - transform.position;
        moveDir.y = 0;

        float angle = Vector3.SignedAngle( // �� ���� ���� ���� ����
            transform.forward, moveDir.normalized, Vector3.up); // ���� �� <-��-> �÷��̾���, y�� ���� ����

        transform.Rotate(0, angle, 0); // ȸ��
    }

    // Update is called once per frame
    void Update()
    {
        // [ �̵� ]

        // ��� 1
        Vector3 deltaPos = moveDir.normalized * speed * Time.deltaTime;
        transform.Translate(deltaPos, Space.World); // �̵�

        //// ��� 2
        //Vector3 deltaPos2 = transform.forward * speed * Time.deltaTime;
        //transform.Translate(deltaPos, Space.World);

        //// ��� 3
        //Vector3 deltaPos3 = Vector3.forward * speed * Time.deltaTime;
        //transform.Translate(deltaPos, Space.Self);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletW2P2 : MonoBehaviour
{
    public float speed; // �ӵ�
    Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaPos = direction * speed * Time.deltaTime; // �� �������� �̵�
        transform.Translate(deltaPos); // �������� �̵�
    }

    // �Ѿ��� ��ġ ����
    public void SetPosDir(Vector3 pos, Vector3 dir)
    {
        transform.position = pos; // �Ѿ� ���� ��ġ
        direction = dir; // �̵��� ���� ����
    }
}

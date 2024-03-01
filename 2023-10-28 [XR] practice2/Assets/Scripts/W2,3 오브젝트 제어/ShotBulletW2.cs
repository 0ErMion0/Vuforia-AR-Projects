using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBulletW2 : MonoBehaviour
{
    public GameObject bulletObj;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Shot(transform.forward);
            Shot(-transform.forward);
            Shot(transform.right);
            Shot(-transform.right);
            Shot(transform.up);
        }
    }

    void Shot(Vector3 dir)
    {
        GameObject obj = Instantiate(bulletObj);
        Vector3 shotPos = transform.position + transform.up * 0.05f; // �� pos + �Ѿ� ����
        // 0.05f�� �ǹ��� �߿� �Ǿ��־ ���� �ʿ��� �Ѿ� �߻�ǵ��� ����ø���
        // up �����ε� �̰� �� ���� �κ�, �ǹ���, �Ʒ��� �����ϱ�.

        obj.GetComponent<BulletMoveW2>().SetPosDir(shotPos, dir); // Ÿ Ŭ������ �Լ� ������ ȣ��
        Destroy(obj, 10);
    }
}

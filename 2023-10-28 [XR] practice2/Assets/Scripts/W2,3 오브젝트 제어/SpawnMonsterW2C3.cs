using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsterW2C3 : MonoBehaviour
{
    public GameObject monObj;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) // ù ȣ��
        {
            Invoke("Spawn", 0.5f); // 0.5f �ڿ� Spawn �Լ� ȣ��
        }
        else if (Input.GetKeyDown("2"))
        {
            InvokeRepeating("Spawn", 1.0f, 2.0f); // 1.0f �ڿ� 2.0f �������� �Լ� ȣ��
        }
        else if (Input.GetKeyDown("3"))
        {
            CancelInvoke("Spawn"); // Spawn �Լ� ȣ���ϴ°� �ߴ�
        }
        else if (Input.GetKeyDown("4"))
        {
            CancelInvoke(); // ��� �Լ� ȣ�� �ߴ�
        }
    }

    void Spawn()
    {
        GameObject obj = Instantiate(monObj);

        Vector3 randPos;
        randPos.x = Random.Range(-0.2f, 0.2f);
        randPos.y = 0;
        randPos.z = Random.Range(-0.2f, 0.2f);

        float randDeg = Random.Range(0, 360);

        obj.transform.position = transform.position + randPos; // ���� ���� ��ġ ����
        obj.transform.rotation = Quaternion.Euler(0, randDeg, 0); // ���� ���� ȸ���� ������
    }
}

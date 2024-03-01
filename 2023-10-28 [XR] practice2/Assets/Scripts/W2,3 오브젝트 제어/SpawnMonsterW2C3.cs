using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsterW2C3 : MonoBehaviour
{
    public GameObject monObj;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) // 첫 호출
        {
            Invoke("Spawn", 0.5f); // 0.5f 뒤에 Spawn 함수 호출
        }
        else if (Input.GetKeyDown("2"))
        {
            InvokeRepeating("Spawn", 1.0f, 2.0f); // 1.0f 뒤에 2.0f 간격으로 함수 호출
        }
        else if (Input.GetKeyDown("3"))
        {
            CancelInvoke("Spawn"); // Spawn 함수 호출하는거 중단
        }
        else if (Input.GetKeyDown("4"))
        {
            CancelInvoke(); // 모든 함수 호출 중단
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

        obj.transform.position = transform.position + randPos; // 몬스터 생성 위치 설정
        obj.transform.rotation = Quaternion.Euler(0, randDeg, 0); // 몬스터 생성 회전값 설정ㄴ
    }
}

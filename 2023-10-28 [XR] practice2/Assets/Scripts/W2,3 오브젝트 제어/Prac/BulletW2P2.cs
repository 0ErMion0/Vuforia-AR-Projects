using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletW2P2 : MonoBehaviour
{
    public float speed; // 속도
    Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaPos = direction * speed * Time.deltaTime; // 이 방향으로 이동
        transform.Translate(deltaPos); // 이쪽으로 이동
    }

    // 총알의 위치 설정
    public void SetPosDir(Vector3 pos, Vector3 dir)
    {
        transform.position = pos; // 총알 시작 위치
        direction = dir; // 이동할 방향 설정
    }
}

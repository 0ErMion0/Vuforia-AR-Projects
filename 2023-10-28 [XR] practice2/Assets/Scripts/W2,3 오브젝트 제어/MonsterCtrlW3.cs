using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrlW3 : MonoBehaviour
{
    // 방향 전환 후 플레이어 쪽으로 이동
    public float speed;
    Vector3 moveDir;

    void Start()
    {
        // [ 방향 전환 ]
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        moveDir = player.transform.position - transform.position;
        moveDir.y = 0;

        float angle = Vector3.SignedAngle( // 두 벡터 사이 각도 구함
            transform.forward, moveDir.normalized, Vector3.up); // 몬스터 앞 <-비교-> 플레이어쪽, y축 대한 각도

        transform.Rotate(0, angle, 0); // 회전
    }

    // Update is called once per frame
    void Update()
    {
        // [ 이동 ]

        // 방법 1
        Vector3 deltaPos = moveDir.normalized * speed * Time.deltaTime;
        transform.Translate(deltaPos, Space.World); // 이동

        //// 방법 2
        //Vector3 deltaPos2 = transform.forward * speed * Time.deltaTime;
        //transform.Translate(deltaPos, Space.World);

        //// 방법 3
        //Vector3 deltaPos3 = Vector3.forward * speed * Time.deltaTime;
        //transform.Translate(deltaPos, Space.Self);
    }
}

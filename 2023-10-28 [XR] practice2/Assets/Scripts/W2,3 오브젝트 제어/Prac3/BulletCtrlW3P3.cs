using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrlW3P3 : MonoBehaviour
{
    // 초기 위치
    //속ㄷㅗ
    public float speed = 0.3f;
    Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaPos = direction * speed * Time.deltaTime;
        transform.Translate(deltaPos);
    }

    public void SetBullet(Vector3 pos, Vector3 dir)
    {
        transform.position = pos;
        direction = dir;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    // ㄹㅔㅇㅣㅇㅓㅇㅔㄱㅔ 이도ㅇ 
    public float speed;
    Vector3 movDir;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        movDir = player.transform.position - transform.position;
        movDir.y = 0;

        float angle = Vector3.SignedAngle(
            transform.forward, movDir.normalized, Vector3.up);

        transform.Rotate(0, angle, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaPos = movDir.normalized * speed * Time.deltaTime;
        transform.Translate(deltaPos, Space.World);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            print("충돌");
            Destroy(gameObject);
        }
        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}

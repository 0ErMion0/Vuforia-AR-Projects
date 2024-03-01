using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletW2P22 : MonoBehaviour
{
    public float speed;
    Vector3 direction;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            //Destroy(other);
            Destroy(gameObject);
        }
    }
}

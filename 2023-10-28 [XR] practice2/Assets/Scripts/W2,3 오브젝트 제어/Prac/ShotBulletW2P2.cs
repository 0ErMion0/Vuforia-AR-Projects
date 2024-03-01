using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBulletW2P2 : MonoBehaviour
{
    public GameObject bulletObj;

    // Update is called once per frame
    void Update()
    {

    }

    void Shot(Vector3 dir)
    {
        GameObject obj = Instantiate(bulletObj);
        Vector3 shotPos = transform.position + transform.up * 0.05f;

        obj.GetComponent<BulletW2P2>().SetPosDir(shotPos, dir);
        Destroy(obj, 3f);
    }
}

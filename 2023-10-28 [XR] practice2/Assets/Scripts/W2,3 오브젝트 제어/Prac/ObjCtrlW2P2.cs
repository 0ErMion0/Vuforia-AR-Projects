using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCtrlW2P2 : MonoBehaviour
{
    Vector3 nowPos;
    public GameObject bulletObj;

    // Update is called once per frame
    void Update()
    {
        // 상하 이동으로 오브젝트 y 축 대해 이동
        if (Input.GetMouseButtonDown(0))
        {
            nowPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 deltaPos = Input.mousePosition - nowPos;
            deltaPos *= (Time.deltaTime * 0.1f);
            transform.Translate(0, deltaPos.y, 0, Space.World);

            Vector2 deltaPos2 = Input.mousePosition - nowPos;
            deltaPos2 *= (Time.deltaTime * 10f);
            transform.Rotate(0,0,-deltaPos2.x, Space.World);
        }
        nowPos = Input.mousePosition;
    }
    void Shot(Vector3 dir)
    {
        GameObject obj = Instantiate(bulletObj);
        Vector3 shotPos = transform.position + transform.up * 0.05f;

        obj.GetComponent<BulletW2P2>().SetPosDir(shotPos, dir);
        Destroy(obj, 3f);
    }

    public void OnClickFront(string name)
    {
        Shot(transform.forward + transform.right);
        Shot(transform.forward - transform.right);
    }

    public void OnClickBack(string name)
    {
        Shot(-transform.forward + transform.right);
        Shot(-transform.forward - transform.right);
    }
}

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
        Vector3 shotPos = transform.position + transform.up * 0.05f; // 현 pos + 총알 방향
        // 0.05f는 피벗이 발에 되어있어서 몸통 쪽에서 총알 발사되도록 끌어올린거
        // up 방향인데 이게 그 고정 부분, 피벗이, 아래에 있으니까.

        obj.GetComponent<BulletMoveW2>().SetPosDir(shotPos, dir); // 타 클래스의 함수 가져와 호출
        Destroy(obj, 10);
    }
}

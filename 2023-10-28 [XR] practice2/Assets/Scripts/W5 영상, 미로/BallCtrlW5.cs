using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrlW5 : MonoBehaviour
{
    public Transform camTr;
    Rigidbody rb;

    Vector3 firstPos; // 리스폰
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        firstPos = transform.localPosition; // 초기 위치 저장해서 리스폰 할 수 있도록 하기
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = camTr.up * -0.5f; // 공에 카메라의 아래로 중력 가해주기
    }

    public void OnFound()
    {
        if(rb != null)
        {
            rb.isKinematic = false;
        }
    }

    public void OnLost()
    {
        if(rb != null)
        {
            rb.isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string objName = collision.gameObject.name; // 부딪힌거의 이름 가져옴

        if(objName == "Item")
        {
            collision.gameObject.SetActive(false);
            print("아이템 획득");
        }
        else if(objName == "Exit")
        {
            GameMngW5.instance.GoNextStage();
            print("스테이지 클리어");
        }
        else if(objName == "Trap")
        {
            transform.localPosition = firstPos;
        }
    }
}

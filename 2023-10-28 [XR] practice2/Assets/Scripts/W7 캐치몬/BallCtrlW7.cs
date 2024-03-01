using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallCtrlW7 : MonoBehaviour
{
    // 볼 위치 지정 - 카메라 앞에!
    public Transform camTr;

    Rigidbody rb;
    Vector3 mousePos;

   
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if(rb.isKinematic == false)
        {
            return;
        }
        
        // 볼 위치 설정
        Vector3 offset = camTr.forward * 0.4f - camTr.up * 0.12f;
        transform.position = camTr.position + offset;
        transform.rotation = camTr.rotation;

        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 deltaPos = mousePos - Input.mousePosition;
            float len = deltaPos.magnitude; // 벡터 계산

            rb.isKinematic = false; // <- 던진 순간 중력에 맏김
            rb.AddForce((camTr.forward + camTr.up).normalized * len * 0.3f);
            rb.AddTorque(-deltaPos.y, deltaPos.x, 0);

            // 기존 볼 위치로
            Invoke("ResetBall", 2);
        }
    }

    void ResetBall()
    {
        gameObject.SetActive(true);

        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // stopping every ongoing movement and rotation of rigidbody
    }

    // 몬스터 맞추기
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }


}

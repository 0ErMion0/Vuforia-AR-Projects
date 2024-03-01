using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallCtrlW7 : MonoBehaviour
{
    // �� ��ġ ���� - ī�޶� �տ�!
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
        
        // �� ��ġ ����
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
            float len = deltaPos.magnitude; // ���� ���

            rb.isKinematic = false; // <- ���� ���� �߷¿� ����
            rb.AddForce((camTr.forward + camTr.up).normalized * len * 0.3f);
            rb.AddTorque(-deltaPos.y, deltaPos.x, 0);

            // ���� �� ��ġ��
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

    // ���� ���߱�
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }


}

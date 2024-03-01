using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrlW5 : MonoBehaviour
{
    public Transform camTr;
    Rigidbody rb;

    Vector3 firstPos; // ������
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        firstPos = transform.localPosition; // �ʱ� ��ġ �����ؼ� ������ �� �� �ֵ��� �ϱ�
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = camTr.up * -0.5f; // ���� ī�޶��� �Ʒ��� �߷� �����ֱ�
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
        string objName = collision.gameObject.name; // �ε������� �̸� ������

        if(objName == "Item")
        {
            collision.gameObject.SetActive(false);
            print("������ ȹ��");
        }
        else if(objName == "Exit")
        {
            GameMngW5.instance.GoNextStage();
            print("�������� Ŭ����");
        }
        else if(objName == "Trap")
        {
            transform.localPosition = firstPos;
        }
    }
}

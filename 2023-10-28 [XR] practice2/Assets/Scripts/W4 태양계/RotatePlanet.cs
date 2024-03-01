using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public Transform targetTr;
    public float rotSpeed;

    Transform tr;
    
    void Start()
    {
        tr = GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        tr.RotateAround(targetTr.position, Vector3.up, Time.deltaTime * rotSpeed);
    }

    public void OnTargetFound()
    {
        print("Ÿ�� �̹��� �߰�");
        //enabled = true; // ��ũ��Ʈ Ȱ��ȭ
        gameObject.SetActive(true);
    }
    public void OnTargetLost()
    {
        print("Ÿ�� �̹��� ����");
        //enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}

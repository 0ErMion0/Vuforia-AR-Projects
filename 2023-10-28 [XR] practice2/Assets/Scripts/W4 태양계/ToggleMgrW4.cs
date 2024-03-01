using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMgrW4 : MonoBehaviour
{
    Camera ARCam;
    
    // Start is called before the first frame update
    void Start()
    {
        ARCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = ARCam.ScreenPointToRay(Input.mousePosition); // ���콺���� ��ũ������ ���� ��

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100, 1 << 8)) 
            {
                GameObject canvas = hit.transform.Find("Canvas").gameObject;
                canvas.SetActive(!canvas.activeSelf);
            }
            // "<<" �浹ó�� �� �� ���̴µ� ��Ʈ ��������!
            // 1�� 8ĭ �������� �о��� ��
            // �¾� ������Ʈ�� ���Ͱ� ��ġ�ؼ� �浹 üũ�ϴ°�
            // ���̸� ���콺���� �������� �ؼ� 8�� ���̾ ���ؼ��� �浹üũ��
            // ĵ������ �̸� ���� ������Ʈ ������
            // �ڱ� �ڽ��� Ȱ��ȭ ���� üũ�ؼ� �� �ݴ�� �ϰ� ��
        }
    }
}

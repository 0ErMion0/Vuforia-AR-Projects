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
            Ray ray = ARCam.ScreenPointToRay(Input.mousePosition); // 마우스에서 스크린으로 레이 쏨

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100, 1 << 8)) 
            {
                GameObject canvas = hit.transform.Find("Canvas").gameObject;
                canvas.SetActive(!canvas.activeSelf);
            }
            // "<<" 충돌처리 할 때 쓰이는데 비트 연산자임!
            // 1을 8칸 좌측으로 밀어내라는 뜻
            // 태양 오브젝트가 저것과 일치해서 충돌 체크하는것
            // 레이를 마우스에서 나오도록 해서 8번 레이어에 대해서만 충돌체크함
            // 캔버스란 이름 가진 오브젝트 얻어오고
            // 자기 자신의 활성화 여부 체크해서 그 반대로 하게 함
        }
    }
}

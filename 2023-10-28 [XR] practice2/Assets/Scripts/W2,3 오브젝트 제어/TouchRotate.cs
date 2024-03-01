using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    // 좌측 마우스 누르면
    // 이전
    
    public Space mySpace;
    Vector3 prePos;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 deltaPos = Input.mousePosition - prePos;
            deltaPos *= (Time.deltaTime * 10);

            //transform.Rotate(deltaPos.y, -deltaPos.x, 0, mySpace);
            transform.Rotate(new Vector3 (deltaPos.y,-deltaPos.x,0), Space.World);
        }

        prePos = Input.mousePosition;
    }
}

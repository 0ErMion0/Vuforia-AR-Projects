using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrlW2C2 : MonoBehaviour
{
    enum State
    {
        Move,
        Spin,
        Zoom
    }

    public Text stateText;
    Vector3 prePos;
    State curState = State.Move;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            prePos = Input.mousePosition;
        }
        
        if (Input.GetMouseButton(0))
        {
            Vector3 deltaPos = Input.mousePosition - prePos;

            switch (curState)
            {
                case State.Move:
                    deltaPos *= (Time.deltaTime * 0.1f);
                    transform.Translate(new Vector3(deltaPos.x, 0, deltaPos.y), Space.World);
                    break;
                case State.Spin:
                    deltaPos *= (Time.deltaTime * 10f);
                    transform.Rotate(deltaPos.y, -deltaPos.x, 0, Space.World);
                    break;
                case State.Zoom:
                    deltaPos *= (Time.deltaTime * 0.1f);
                    transform.localScale += deltaPos;
                    break;
            }
        }

        prePos = Input.mousePosition;
    }

    // 상태 버튼 눌린 경우 //
    public void OnClickMove(string name)
    {
        curState = State.Move;
        stateText.text = name;
    }

    public void OnClickSpin(string name)
    {
        curState = State.Spin;
        stateText.text = name;
    }

    public void OnClickZoom(string name)
    {
        curState = State.Zoom;
        stateText.text = name;
    }

    // 충돌했을 경우
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
            print("충돌 시작");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Monster")
            print("충돌 지속");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Monster")
            print("충돌 종료");
    }
}

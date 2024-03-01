using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjCtrlW2P22 : MonoBehaviour
{
    // 마우스로 플레이어 조작
    // 마우스 1 누르면 앞ㅇㅡㄹㅗ 발사
    // 2 누르ㅁㄴ 뒤로 발사

    Vector3 prePos;
    public GameObject bulletObj;
    public GameObject monsterObj;
    State currState = State.x;
    public Text stateText;

    enum State
    {
        x,
        y
    }

    private void Start()
    {
        InvokeRepeating("MonsterCome", 1f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //// 조작
        //if (Input.GetMouseButtonDown(0))
        //{
        //    prePos = Input.mousePosition;
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    Vector2 deltaPos = Input.mousePosition - prePos;
        //    deltaPos *= (Time.deltaTime * 0.1f);
        //    transform.Translate(deltaPos.x, deltaPos.y, 0, Space.World);
        //}

        if (Input.GetMouseButton(0))
        {
            Vector2 deltaPos = Input.mousePosition - prePos;
            deltaPos *= (Time.deltaTime * 0.1f);

            switch (currState)
            {
                case State.x:
                    //deltaPos *= (Time.deltaTime * 0.1f);
                    transform.Translate(deltaPos.x, 0, 0, Space.World);
                    break;
                case State.y:
                    //deltaPos *= (Time.deltaTime * 0.1f);
                    transform.Translate(0, deltaPos.y, 0, Space.World);
                    break;
            }
        }
        prePos = Input.mousePosition;


        // 총알 발사
        if (Input.GetMouseButtonDown(0))
        {
            Shot(transform.forward + transform.right);
            Shot(transform.forward - transform.right);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Shot(-transform.forward + transform.right);
            Shot(-transform.forward - transform.right);
        }
    }

    public void OnClickX(string name)
    {
        currState = State.x;
        stateText.text = name;
    }

    public void OnClickY(string name)
    {
        currState = State.y;
        stateText.text = name;
    }

    public void Shot(Vector3 dir)
    {
        GameObject obj = Instantiate(bulletObj);
        Vector3 shotPos = transform.position + transform.up * 0.05f;

        obj.GetComponent<BulletW2P22>().SetBullet(shotPos, dir);
        Destroy(obj, 3f);
    }

    public void MonsterCome()
    {
        GameObject obj = Instantiate(monsterObj);

        Vector3 randPos;
        randPos.x = Random.Range(-0.2f, 0.2f);
        randPos.z = Random.Range(-0.2f, 0.2f);
        randPos.y = 0;

        float randRot = Random.Range(0, 360);

        obj.transform.position = transform.position + randPos;
        obj.transform.rotation = Quaternion.Euler(0, randRot, 0);
    }

}

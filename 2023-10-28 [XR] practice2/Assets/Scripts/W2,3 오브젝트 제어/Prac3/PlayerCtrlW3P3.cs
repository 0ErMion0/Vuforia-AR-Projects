using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum GameStateW3P3
{
    Front,
    Back
}
public class PlayerCtrlW3P3 : MonoBehaviour
{
    Vector3 prePos;

    public GameObject bulletObj;
    GameStateW3P3 nowState = GameStateW3P3.Front;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            prePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 deltaPos1 = Input.mousePosition - prePos;
            deltaPos1 *= (Time.deltaTime * 0.1f);

            transform.Translate(0, deltaPos1.y, 0, Space.World);

            Vector3 deltaPos2 = Input.mousePosition - prePos;
            deltaPos2 *= (Time.deltaTime * 10);

            transform.Rotate(0, 0, deltaPos2.x, Space.World);
        }
        prePos = Input.mousePosition;
    }

    public void OnClickFront()
    {
        nowState = GameStateW3P3.Front;
        text.text = "Front";
        Shot(transform.forward + transform.right);
        Shot(transform.forward - transform.right);
    }

    public void OnClickBack()
    {
        nowState = GameStateW3P3.Back;
        text.text = "Back";
        Shot(-transform.forward + transform.right);
        Shot(-transform.forward - transform.right);
    }

    public void Shot(Vector3 dir)
    {
        GameObject bullet = Instantiate(bulletObj);
        Vector3 shotPos = transform.position + transform.up * 0.05f;

        bullet.GetComponent<BulletCtrlW3P3>().SetBullet(shotPos, dir);
        Destroy(gameObject, 3f);
    }
}

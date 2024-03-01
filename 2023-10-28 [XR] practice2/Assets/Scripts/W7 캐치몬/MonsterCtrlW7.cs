using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCtrlW7 : MonoBehaviour
{
    public float hitRate; // 몬스터 잡을 확률

    public float damageRate;
    public float catchRate;
    public Image imgHP;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Ball")
            return;

        if (Random.Range(0.0f, 1.0f) < hitRate) // 0.7, 0.5
        {
            print("명중");
            imgHP.fillAmount -= damageRate;
            if(imgHP.fillAmount > 0.001f)
            {
                GameMngW7.instance.PopupMsg("명중",1);
            }//(imgHP.fillAmount < 0.001f)
            else
            {
                if(Random.Range(0.0f, 1.0f) < catchRate)
                {
                    print("잡음");
                    GameMngW7.instance.AddCatch();
                }
                else
                {
                    print("놓침");
                    GameMngW7.instance.PopupMsg("놓침", 2);
                }
                gameObject.SetActive(false);

                Invoke("ChangePos", Random.Range(2, 5)); // 몬스터 리스폰
            }
        }
        else
        {
            print("막힘");
            GameMngW7.instance.PopupMsg("막힘", 1);
        }
    }

    // 몬스터 리스폰
    private void ChangePos()
    {
        gameObject.SetActive(true);

        Vector3 pos;
        pos.x = Random.Range(-0.2f, 0.2f);
        pos.y = 0;
        pos.z = Random.Range(-0.2f, 0.2f);

        transform.localPosition = pos;
    }
}

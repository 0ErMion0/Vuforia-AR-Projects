using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCtrlW7 : MonoBehaviour
{
    public float hitRate; // ���� ���� Ȯ��

    public float damageRate;
    public float catchRate;
    public Image imgHP;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Ball")
            return;

        if (Random.Range(0.0f, 1.0f) < hitRate) // 0.7, 0.5
        {
            print("����");
            imgHP.fillAmount -= damageRate;
            if(imgHP.fillAmount > 0.001f)
            {
                GameMngW7.instance.PopupMsg("����",1);
            }//(imgHP.fillAmount < 0.001f)
            else
            {
                if(Random.Range(0.0f, 1.0f) < catchRate)
                {
                    print("����");
                    GameMngW7.instance.AddCatch();
                }
                else
                {
                    print("��ħ");
                    GameMngW7.instance.PopupMsg("��ħ", 2);
                }
                gameObject.SetActive(false);

                Invoke("ChangePos", Random.Range(2, 5)); // ���� ������
            }
        }
        else
        {
            print("����");
            GameMngW7.instance.PopupMsg("����", 1);
        }
    }

    // ���� ������
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

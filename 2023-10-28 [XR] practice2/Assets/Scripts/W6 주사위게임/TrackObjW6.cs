using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TrackObjW6 : MonoBehaviour
{
    // ĳ���� ���� ��ũ��Ʈ
    public TextMesh infoTM;
    
    public string objName;
    public int hp;
    public int atk;
    public int def;

    public bool isDetected;

    Animation objAni;

    // Start is called before the first frame update
    void Start()
    {
        InitInfo();
    }

    public void InitInfo()
    {
        infoTM.text = objName + "\n HP: " + hp;
    }

    public void OnDetect(bool detect)
    {
        isDetected = detect;
    }

    //public float PlayAnimation(string clipName)
    //{
    //    if (objAni.GetClip(clipName) == null)
    //    {
    //        clipName = objName + "_" + clipName;
    //    }
    //    objAni.Play(clipName);
    //    return objAni.GetClip(clipName).length;
    //}
    public float PlayAnimation(string clipName)
    {
        if (objAni.GetClip(clipName) == null) // Ŭ�� �̸� ������
        {
            clipName = name + "_" + clipName; // �̷��� �̸� ����
        }
        objAni.Play(clipName); // �ִϸ��̼� ���

        return objAni.GetClip(clipName).length; // �ִϸ��̼��� ���� ����
    }
}

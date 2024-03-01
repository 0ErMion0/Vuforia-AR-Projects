using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class TrackObjW61 : MonoBehaviour
{
    // 캐릭터 정보 스크립트
    public TextMesh infoTM;

    public string objName; // 공격
    public int hp; // hp
    public int atk; // atk
    public int def; // def?

    public bool isDetected;

    Animation objAni;

    // Start is called before the first frame update
    void Start()
    {
        objAni = GetComponent<Animation>();
        InitInfo();
    }

    // 시작하자마자 플레이어 위에 정보 뜨게 함
    public void InitInfo()
    {
        infoTM.text = objName + "\n HP: " + hp;
    }

    public void OnDetect(bool detect)
    {
        isDetected = detect;
    }

    public float PlayAnimation(string clipname)
    {
        if (objAni.GetClip(clipname) == null)
        {
            clipname = name + "_" + clipname;// + " (Read-Only)";
        }
        objAni.Play(clipname);
        return objAni.GetClip(clipname).length;
    }
}

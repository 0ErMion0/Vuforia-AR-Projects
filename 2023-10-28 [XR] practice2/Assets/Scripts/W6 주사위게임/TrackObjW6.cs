using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TrackObjW6 : MonoBehaviour
{
    // 캐릭터 정보 스크립트
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
        if (objAni.GetClip(clipName) == null) // 클립 이름 없으면
        {
            clipName = name + "_" + clipName; // 이렇게 이름 설정
        }
        objAni.Play(clipName); // 애니메이션 재생

        return objAni.GetClip(clipName).length; // 애니메이션의 길이 리턴
    }
}

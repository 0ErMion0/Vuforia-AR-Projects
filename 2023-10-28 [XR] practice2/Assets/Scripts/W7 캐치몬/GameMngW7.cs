using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameStateW7
{
    Ready,
    Begin,
    End
}

public class GameMngW7 : MonoBehaviour
{
    static public GameMngW7 instance;
    public Text numText;
    public int maxCatch;
    int numCatch = 0;
    public Text stateText;

    public GameObject ballObj;
    public GameStateW7 gameState = GameStateW7.Ready;


    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        numText.text = "��ȹ�� " + numCatch + "/" + maxCatch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCatch()
    {
        ++numCatch;
        numText.text = "��ȹ�� " + numCatch + "/" + maxCatch;

        if(numCatch < maxCatch)
        {
            print("����");
        }
        else
        {
            print("��� ����");
        }

        if(numCatch >= maxCatch)
        {
            PopupMsg("��� ����", 3);
        }
        else
        {
            PopupMsg("����", 2);
        }
    }

    public void PopupMsg(string msg, int time)
    {
        StartCoroutine(ShowMsg(msg, time));
    }

    IEnumerator ShowMsg(string msg, int time)
    {
        stateText.text = msg;
        yield return new WaitForSeconds(time);
        stateText.text = "";
    }

    public void OnDetected()
    {
        if (gameState == GameStateW7.Ready)
        {
            numText.text = "��ȹ�� " + numCatch + "/" + maxCatch;
            gameState = GameStateW7.Begin;
            ballObj.SetActive(true);
            PopupMsg("�� ����", 2);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState2
{
    Ready,
    Battle,
    Result
}

public class BattleMngW62 : MonoBehaviour
{
    public TrackObjW61 objPlayer;
    public TrackObjW61 objMonster;
    public Text stateMsg;
    public GameObject objStartBtn;
    public GameObject objReplayBtn;

    public GameState2 currentState = GameState2.Ready;
    

    // Update is called once per frame
    void Update()
    {
        if(currentState == GameState2.Ready)
        {
            if (objPlayer.isDetected && objMonster.isDetected)
            {
                if (objStartBtn.activeSelf == false)
                {
                    objStartBtn.SetActive(true);
                    stateMsg.text = "���� ��ư�� �����ּ���.";
                }
            }
            else
            {
                if (objStartBtn.activeSelf)
                {
                    objStartBtn.SetActive(false);
                    stateMsg.text = "ī�带 �νĽ����ּ���.";
                }
            }
        }
        
    }

    public void OnClickStart()
    {
        currentState = GameState2.Battle;
        stateMsg.text = "�ֻ����� ���� ���ϱ�";

        objStartBtn.SetActive(false);
        StartCoroutine(RollTheDices());
    }

    IEnumerator RollTheDices()
    {
        int dicePlayer = 0;
        int diceMonster = 0;

        for(int i = 0; i<30; i++)
        {
            dicePlayer = Random.Range(1, 7);
            diceMonster = Random.Range(1, 7);

            objPlayer.infoTM.text = "�ֻ���: " + dicePlayer;
            objMonster.infoTM.text = "�ֻ���: " + diceMonster;

            yield return new WaitForSeconds(0.1f);
        }

        // ���� ����
        if(dicePlayer > diceMonster)
        {
            stateMsg.text = objPlayer.objName + " ����";
            StartCoroutine(StartBattle(objPlayer, objMonster));
        }
        else if(diceMonster > dicePlayer)
        {
            stateMsg.text = objMonster.objName + " ����";
            StartCoroutine(StartBattle(objMonster, objPlayer));
        }
        else
        {
            stateMsg.text = "���º� - �ٽ��ϱ�";
            yield return new WaitForSeconds(1.0f);
            StartCoroutine(RollTheDices());
        }
    }

    IEnumerator StartBattle(TrackObjW61 firstTurn, TrackObjW61 secondTurn)
    {
        yield return new WaitForSeconds(1.0f);

        int firstHp = firstTurn.hp;
        int secondHp = secondTurn.hp;

        firstTurn.infoTM.text = firstTurn.objName + "\n HP: " + firstHp;
        secondTurn.infoTM.text = secondTurn.objName + "\n HP: " + secondHp;

        while (true)
        {
            // ����
            stateMsg.text = firstTurn.objName + "����";

            float aniLen = firstTurn.PlayAnimation("Attack");
            yield return new WaitForSeconds(aniLen);
            firstTurn.PlayAnimation("Idle");

            secondHp -= firstTurn.atk;
            secondTurn.infoTM.text = secondTurn.objName + "\n HP: " + secondHp;

            if(secondHp <= 0)
            {
                stateMsg.text = firstTurn.objName + "��(��) �¸��Ͽ����ϴ�.";
                break;
            }

            yield return new WaitForSeconds(1.0f);

            // �İ�
            stateMsg.text = secondTurn.objName + "����";

            aniLen = secondTurn.PlayAnimation("Attack");
            yield return new WaitForSeconds(aniLen);
            secondTurn.PlayAnimation("Idle");

            firstHp -= secondTurn.atk;
            firstTurn.infoTM.text = firstTurn.objName + "\n HP: " + firstHp;

            if (firstHp <= 0)
            {
                stateMsg.text = secondTurn.objName + "��(��) �¸��Ͽ����ϴ�.";
                break;
            }

            yield return new WaitForSeconds(1.0f);
        }

        yield return new WaitForSeconds(1.0f);
        objReplayBtn.SetActive(true);
    }

    public void OnClickReplay()
    {
        //currentState = GameState2.Ready;
        //stateMsg.text = "ī�带 �νĽ����ּ���";

        //objPlayer.InitInfo();
        //objMonster.InitInfo();

        //objReplayBtn.SetActive(false);

        SceneManager.LoadScene("BattleCard1");
    }
}

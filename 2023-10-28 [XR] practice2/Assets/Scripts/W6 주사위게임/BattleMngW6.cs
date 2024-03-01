using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// ���� ������
public enum GameState
{
    Ready,
    Battle,
    Result
}


public class BattleMngW6 : MonoBehaviour
{
    // ���� �÷��� ��ũ��Ʈ
    public TrackObjW6 objPlayer;
    public TrackObjW6 objMonster;
    public Text stateMsg;
    public GameObject objStartBtn;
    public GameObject objReplayBtn;

    public GameState gameState = GameState.Ready;

    // Update is called once per frame
    void Update()
    {
        if(gameState == GameState.Ready)
        {
            if (objPlayer.isDetected && objMonster.isDetected)
            {
                if (objStartBtn.activeSelf == false) // �� �� ã���� �� ��ư �����ٸ�
                {
                    objStartBtn.SetActive(true);
                    stateMsg.text = "���� ��ư�� �����ּ���.";
                }
            }
            else
            {
                if (objStartBtn.activeSelf == true)
                {
                    objStartBtn.SetActive(false);
                    stateMsg.text = "ī�带 �νĽ����ּ���.";
                }
            }
        } 
    }

    public void OnClickStart() // ���� ��ư ������
    {
        gameState = GameState.Battle;
        stateMsg.text = "�ֻ����� ���� ���ϱ�";

        objStartBtn.SetActive(false);
        StartCoroutine(RollTheDices());
    }
    public void OnClickReplay()
    {
        gameState = GameState.Ready;
        stateMsg.text = "ī�带 �νĽ����ּ���.";

        objPlayer.InitInfo();
        objMonster.InitInfo();

        objReplayBtn.SetActive(false);

        //SceneManager.LoadScene("BattleCard");
    }

    IEnumerator RollTheDices()
    {
        //objPlayer.infoTM.text = "�ֻ��� : " + 1;
        //objMonster.infoTM.text = "�ֻ��� : " + 6;

        //yield return null;

        // [ �ֻ��� ���� ]
        int dicePlayer = 0;
        int diceMonster = 0;

        for(int i = 0; i < 30; i++) // 0~29, �� 30�� �������� �ֻ��� ������
        {
            dicePlayer = Random.Range(0, 6) + 1;
            diceMonster = Random.Range(0, 6) + 1;

            objPlayer.infoTM.text = "�ֻ��� : " + dicePlayer;
            objMonster.infoTM.text = "�ֻ��� : " + diceMonster;

            yield return new WaitForSeconds(0.1f);
        }

        // [ �ֻ��� ����� ���� ���� �� ī�� ��Ʋ ]
        if(dicePlayer > diceMonster)
        {
            stateMsg.text = objPlayer.objName + " ����";
            StartCoroutine(StartBattle(objPlayer, objMonster)); // ��Ʋ
        }
        else if(dicePlayer < diceMonster)
        {
            stateMsg.text = objMonster.objName + " ����";
            StartCoroutine(StartBattle(objMonster, objPlayer)); // ��Ʋ
        }
        else
        {
            stateMsg.text = "���º� - �ٽ��ϱ�";

            yield return new WaitForSeconds(1.0f);
            StartCoroutine(RollTheDices());
        }
    }

    IEnumerator StartBattle(TrackObjW6 firstTurn, TrackObjW6 secondTurn)
    {
        yield return new WaitForSeconds(1.0f);

        int firstHP = firstTurn.hp;
        int secondHP = secondTurn.hp;

        firstTurn.infoTM.text = firstTurn.objName + "\n HP:" + firstHP;
        secondTurn.infoTM.text = secondTurn.objName + "\n HP:" + secondHP;

       
        while (true) // ���� ü�� 0 �� ������ �ݺ�
        {
            // ���� ����
            stateMsg.text = firstTurn.objName + "����"; // ���� ����

            //float aniLen = firstTurn.PlayAnimation("Attack");
            //yield return new WaitForSeconds(aniLen);
            //firstTurn.PlayAnimation("Idle");
            // �ִϸ��̼�
            float aniLen = firstTurn.PlayAnimation("Attack"); // �ִϸ��̼��� ����ϰ� ����ϴµ� �ɸ��� �ð��� aniLen�� �־���
            yield return new WaitForSeconds(aniLen); // aniLen �ð���ŭ ��ٸ� - �ִϸ��̼� �����ϴ� ���� ������ ������� �ʵ���
            firstTurn.PlayAnimation("Idle"); // ���� -> �⺻ ���� ��ȯ

            secondHP -= firstTurn.atk; // ü�� ����
            secondTurn.infoTM.text = secondTurn.objName + "\n HP:" + secondHP; // ���� ����â ������Ʈ
        
            if(secondHP <= 0)
            {
                stateMsg.text = firstTurn.objName + "��(��) �¸��Ͽ����ϴ�.";
                break;
            }

            yield return new WaitForSeconds(1.0f);

            // �Ĺ� ����
            stateMsg.text = secondTurn.objName + "����";

            //aniLen = secondTurn.PlayAnimation("Attack");
            //yield return new WaitForSeconds(aniLen);
            //secondTurn.PlayAnimation("Idle");
            aniLen = secondTurn.PlayAnimation("Attack");
            yield return new WaitForSeconds(aniLen);
            secondTurn.PlayAnimation("Idle");

            firstHP -= secondTurn.atk;
            firstTurn.infoTM.text = firstTurn.objName + "\n HP:" + firstHP;

            if(firstHP <= 0)
            {
                stateMsg.text = secondTurn.objName + "��(��) �¸��Ͽ����ϴ�.";
                break;
            }

            yield return new WaitForSeconds(1.0f);
        }

        yield return new WaitForSeconds(1.0f);
        objReplayBtn.SetActive(true);
    }
}

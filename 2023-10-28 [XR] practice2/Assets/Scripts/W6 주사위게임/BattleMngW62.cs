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
                    stateMsg.text = "시작 버튼을 눌러주세요.";
                }
            }
            else
            {
                if (objStartBtn.activeSelf)
                {
                    objStartBtn.SetActive(false);
                    stateMsg.text = "카드를 인식시켜주세요.";
                }
            }
        }
        
    }

    public void OnClickStart()
    {
        currentState = GameState2.Battle;
        stateMsg.text = "주사위로 선공 정하기";

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

            objPlayer.infoTM.text = "주사위: " + dicePlayer;
            objMonster.infoTM.text = "주사위: " + diceMonster;

            yield return new WaitForSeconds(0.1f);
        }

        // 선공 결정
        if(dicePlayer > diceMonster)
        {
            stateMsg.text = objPlayer.objName + " 선공";
            StartCoroutine(StartBattle(objPlayer, objMonster));
        }
        else if(diceMonster > dicePlayer)
        {
            stateMsg.text = objMonster.objName + " 선공";
            StartCoroutine(StartBattle(objMonster, objPlayer));
        }
        else
        {
            stateMsg.text = "무승부 - 다시하기";
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
            // 선공
            stateMsg.text = firstTurn.objName + "공격";

            float aniLen = firstTurn.PlayAnimation("Attack");
            yield return new WaitForSeconds(aniLen);
            firstTurn.PlayAnimation("Idle");

            secondHp -= firstTurn.atk;
            secondTurn.infoTM.text = secondTurn.objName + "\n HP: " + secondHp;

            if(secondHp <= 0)
            {
                stateMsg.text = firstTurn.objName + "이(가) 승리하였습니다.";
                break;
            }

            yield return new WaitForSeconds(1.0f);

            // 후공
            stateMsg.text = secondTurn.objName + "공격";

            aniLen = secondTurn.PlayAnimation("Attack");
            yield return new WaitForSeconds(aniLen);
            secondTurn.PlayAnimation("Idle");

            firstHp -= secondTurn.atk;
            firstTurn.infoTM.text = firstTurn.objName + "\n HP: " + firstHp;

            if (firstHp <= 0)
            {
                stateMsg.text = secondTurn.objName + "이(가) 승리하였습니다.";
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
        //stateMsg.text = "카드를 인식시켜주세요";

        //objPlayer.InitInfo();
        //objMonster.InitInfo();

        //objReplayBtn.SetActive(false);

        SceneManager.LoadScene("BattleCard1");
    }
}

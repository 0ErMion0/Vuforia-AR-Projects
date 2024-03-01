using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 상태 열거형
public enum GameState
{
    Ready,
    Battle,
    Result
}


public class BattleMngW6 : MonoBehaviour
{
    // 게임 플레이 스크립트
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
                if (objStartBtn.activeSelf == false) // 둘 다 찾았을 때 버튼 꺼졌다면
                {
                    objStartBtn.SetActive(true);
                    stateMsg.text = "시작 버튼을 눌러주세요.";
                }
            }
            else
            {
                if (objStartBtn.activeSelf == true)
                {
                    objStartBtn.SetActive(false);
                    stateMsg.text = "카드를 인식시켜주세요.";
                }
            }
        } 
    }

    public void OnClickStart() // 시작 버튼 누르면
    {
        gameState = GameState.Battle;
        stateMsg.text = "주사위로 선공 정하기";

        objStartBtn.SetActive(false);
        StartCoroutine(RollTheDices());
    }
    public void OnClickReplay()
    {
        gameState = GameState.Ready;
        stateMsg.text = "카드를 인식시켜주세요.";

        objPlayer.InitInfo();
        objMonster.InitInfo();

        objReplayBtn.SetActive(false);

        //SceneManager.LoadScene("BattleCard");
    }

    IEnumerator RollTheDices()
    {
        //objPlayer.infoTM.text = "주사위 : " + 1;
        //objMonster.infoTM.text = "주사위 : " + 6;

        //yield return null;

        // [ 주사위 결정 ]
        int dicePlayer = 0;
        int diceMonster = 0;

        for(int i = 0; i < 30; i++) // 0~29, 총 30번 랜덤으로 주사위 던지기
        {
            dicePlayer = Random.Range(0, 6) + 1;
            diceMonster = Random.Range(0, 6) + 1;

            objPlayer.infoTM.text = "주사위 : " + dicePlayer;
            objMonster.infoTM.text = "주사위 : " + diceMonster;

            yield return new WaitForSeconds(0.1f);
        }

        // [ 주사위 결과로 선공 결정 후 카드 배틀 ]
        if(dicePlayer > diceMonster)
        {
            stateMsg.text = objPlayer.objName + " 선공";
            StartCoroutine(StartBattle(objPlayer, objMonster)); // 배틀
        }
        else if(dicePlayer < diceMonster)
        {
            stateMsg.text = objMonster.objName + " 선공";
            StartCoroutine(StartBattle(objMonster, objPlayer)); // 배틀
        }
        else
        {
            stateMsg.text = "무승부 - 다시하기";

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

       
        while (true) // 누구 체력 0 될 때까지 반복
        {
            // 선발 공격
            stateMsg.text = firstTurn.objName + "공격"; // 상태 설정

            //float aniLen = firstTurn.PlayAnimation("Attack");
            //yield return new WaitForSeconds(aniLen);
            //firstTurn.PlayAnimation("Idle");
            // 애니메이션
            float aniLen = firstTurn.PlayAnimation("Attack"); // 애니메이션을 재생하고 재생하는데 걸리는 시간을 aniLen에 넣어줌
            yield return new WaitForSeconds(aniLen); // aniLen 시간만큼 기다림 - 애니메이션 동작하는 동안 다음꺼 실행되지 않도록
            firstTurn.PlayAnimation("Idle"); // 공격 -> 기본 으로 전환

            secondHP -= firstTurn.atk; // 체력 감소
            secondTurn.infoTM.text = secondTurn.objName + "\n HP:" + secondHP; // 후자 설명창 업데이트
        
            if(secondHP <= 0)
            {
                stateMsg.text = firstTurn.objName + "이(가) 승리하였습니다.";
                break;
            }

            yield return new WaitForSeconds(1.0f);

            // 후발 공격
            stateMsg.text = secondTurn.objName + "공격";

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
                stateMsg.text = secondTurn.objName + "이(가) 승리하였습니다.";
                break;
            }

            yield return new WaitForSeconds(1.0f);
        }

        yield return new WaitForSeconds(1.0f);
        objReplayBtn.SetActive(true);
    }
}

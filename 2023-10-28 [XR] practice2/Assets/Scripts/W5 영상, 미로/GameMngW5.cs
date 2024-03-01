using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMngW5 : MonoBehaviour
{
    static public GameMngW5 instance; // ½Ì±ÛÅæ
    public GameObject[] stages; // ½ºÅ×ÀÌÁö ¹è¿­
    int curStage = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void GoNextStage()
    {
        StartCoroutine(ChangeStage());
    }

    IEnumerator ChangeStage()
    {
        stages[curStage].SetActive(false);

        ++curStage;
        if (curStage < stages.Length)
        {
            yield return new WaitForSeconds(2f);
            stages[curStage].SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("EscapeMaze");
        }
    }
}

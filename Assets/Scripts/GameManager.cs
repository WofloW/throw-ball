using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerManager player1;
    public PlayerManager player2;
    public int m_NumToWin = 5;
    public Text MessageText;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GameLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(GamePlaying());

        //StartCoroutine(GameLoop());

    }

    private IEnumerator GamePlaying()
    {
        yield return null;
        //while (player1.m_Wins < 5 || player2.m_Wins < 5)
        //{
        //    yield return null;
        //}
        //if (player1.m_Wins == 5 || player2.m_Wins == 5)
        //{
        //    string message = "DRAW!";
        //    if(player1.m_Wins == 5 && player2.m_Wins != 5){
        //        message = "Player 1 wins!";
        //    } else {
        //        message = "Player 2 wins!";
        //    }
        //    MessageText.text = message;
        //}
    }
}

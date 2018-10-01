using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public PlayerManager m_Player1;
    public PlayerManager m_Player2;
    public int m_NumToWin = 5;
    public Text m_MessageText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(GameLoop());
    }

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
        while (m_Player1.m_Wins < 5 || m_Player2.m_Wins < 5)
        {
            m_MessageText.text = m_Player1.m_Wins + ":" + m_Player2.m_Wins;
            yield return null;
        }
        //if (m_Player1.m_Wins == 5 || m_Player2.m_Wins == 5)
        //{
        //    string message = "DRAW!";
        //    if(m_Player1.m_Wins == 5 && m_Player2.m_Wins != 5){
        //        message = "Player 1 wins!";
        //    } else {
        //        message = "Player 2 wins!";
        //    }
        //    m_MessageText.text = message;
        //    SceneManager.LoadScene(0);
        //    yield return null;
        //}
    }
}

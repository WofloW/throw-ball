using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    public PlayerManager m_player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject coll = collision.gameObject;

        if (coll.CompareTag("Player") && m_player)
        {
            Debug.Log(m_player.m_PlayerNumber);
            if (coll.GetComponent<PlayerManager>())
            {
                if (m_player.m_PlayerNumber != coll.GetComponent<PlayerManager>().m_PlayerNumber)
                {
                    m_player.m_Wins++;
                }
            }
        } else {
            m_player = null;
        }
    }
}

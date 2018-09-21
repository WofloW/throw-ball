using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    public int m_PlayerNumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject coll = collision.gameObject;

        if (coll.CompareTag("Player"))
        {
            if (coll.GetComponent<PlayerManager>())
            {
                if (m_PlayerNumber != coll.GetComponent<PlayerManager>().m_PlayerNumber)
                {
                    

                }
            }
        } else {
            m_PlayerNumber = 0;
        }
    }
}

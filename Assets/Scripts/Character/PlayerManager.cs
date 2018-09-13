using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {
    public int m_Wins = 0;
    public int m_PlayerNumber = 1;
    public BallManager m_Ball;
    public Transform m_FireTransform;
    public Slider m_AimSlider;
    //public AudioSource m_ShootingAudio;
    //public AudioClip m_ChargingClip; 
    //public AudioClip m_FireClip;
    public float m_MinLaunchForce = 5f;
    public float m_MaxLaunchForce = 20f;
    public float m_MaxChargeTime = 0.75f;

    private string m_FireButton;
    private float m_CurrentLaunchForce;
    private float m_ChargeSpeed;    
    private bool m_Fired;       


    public bool carrying = false;

    private void Start()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;

        m_AimSlider.value = m_MinLaunchForce;
        m_FireButton = "Fire" + m_PlayerNumber;
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }


    private void Update()
    {
        if (carrying)
        {
            carry(m_Ball);
            m_AimSlider.value = m_MinLaunchForce;

            if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
            {
                m_CurrentLaunchForce = m_MaxLaunchForce;
                Fire();
            }
            else if (Input.GetButtonDown(m_FireButton))
            {
                m_Fired = false;
                m_CurrentLaunchForce = m_MinLaunchForce;

                //m_ShootingAudio.clip = m_ChargingClip;
                //m_ShootingAudio.Play();
            }
            else if (Input.GetButton(m_FireButton) && !m_Fired)
            {
                m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;
                m_AimSlider.value = m_CurrentLaunchForce;
            }
            else if (Input.GetButtonUp(m_FireButton) && !m_Fired)
            {
                Fire();
            }
        }

    }


    private void Fire()
    {
        m_Fired = true;

        m_Ball.GetComponent<Rigidbody>().velocity = m_CurrentLaunchForce * m_FireTransform.forward;
        m_Ball.m_PlayerNumber = m_PlayerNumber;

        //m_ShootingAudio.clip = m_FireClip;
        //m_ShootingAudio.Play();

        m_CurrentLaunchForce = m_MinLaunchForce;
        carrying = false;
        m_Ball = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject coll = collision.gameObject;
        if (coll.CompareTag("ball") && !carrying)
        {
            carrying = true;
            collision.rigidbody.isKinematic = true;
            coll.transform.position = gameObject.transform.position;
            m_Ball = coll.GetComponent<BallManager>();
            //if (coll.GetComponent<BallManager>())
            //{
            //    if (coll.GetComponent<BallManager>().m_PlayerNumber == 0)
            //    {

            //        m_CarryBall = true;
            //    }
            //    if (coll.GetComponent<BallManager>().m_PlayerNumber != m_PlayerNumber)
            //    {

            //    }
            //}
        }
    }

    void carry(BallManager o) {
        o.transform.position = gameObject.transform.position;
    }
}

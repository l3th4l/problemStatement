using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float LerpTime;

    GameObject Player;
    CharControl PlayerControl;

    Vector3 offset;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerControl = Player.GetComponent<CharControl>();
        offset = Player.transform.position - transform.position;
        print(offset);
    }

    void Update()
    {
        if(!PlayerControl.midAir)
        {
            transform.position = Vector3.Slerp(transform.position, Player.transform.position - offset, LerpTime);
        }
    }
}

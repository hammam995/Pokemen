using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class Character : MonoBehaviour
{
    // moving everything to pokemon because he will fight , the player will only move
    // player variables 
    public Animator characterAnimatior;
    protected virtual void Start()
    {
        characterAnimatior = GetComponent<Animator>();
    }
    void Update()
    {

    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMaterials : MonoBehaviour
{
    public GameObject Plane;
    public Material[] material;
    public ESCROBJ EnemyNumber;
    Renderer rend;

    void Start()
    {
        //this script is to ChangePlaneMaterials depends on the enemy number to change the fight enviroment
        rend = Plane.GetComponent<Renderer>();
        for (int i = 0; i < material.Length; i++)
        {
            rend.sharedMaterial = material[EnemyNumber.EnemyNumber];
        }
        rend.enabled = true;

    }

    void Update()
    {
        

    }
    public void ChangePlaneMaterials()
    {
        rend = Plane.GetComponent<Renderer>();
        for (int i = 0; i < material.Length; i++)
        {
            rend.sharedMaterial = material[EnemyNumber.EnemyNumber];
        }
        rend.enabled = true;
    }
}

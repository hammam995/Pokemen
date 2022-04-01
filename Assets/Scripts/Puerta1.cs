using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Puerta1 : MonoBehaviour
{
    [SerializeField] private string loadLevel;
    public ESCROBJ EnemyNumberFromScriptableObject; // we will change the number of the enemy in the scriptable object , we will take the info when we collide with the player to change it is value , then in the battle system we will take the info of the enemy number that's we already change it in the stage scene before we go to the battle system
    public int CurrenEnemyNumber;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("contacto");
            EnemyNumberFromScriptableObject.EnemyNumber = CurrenEnemyNumber;
            SceneManager.LoadScene(loadLevel);
        }
    }
}

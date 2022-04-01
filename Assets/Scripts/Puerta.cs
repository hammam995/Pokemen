using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Puerta : MonoBehaviour
{
    // in this script to check if the player defeated all 4 enemies to go to winning scene
    [SerializeField] private string loadLevel;
    public EPinfo EnemyScriptableObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (EnemyCurrentHPisZero(EnemyScriptableObject) == true)
            {
                SceneManager.LoadScene(loadLevel);
            }
            else
                SceneManager.LoadScene("Level 1");
        }
    }

    public bool EnemyCurrentHPisZero(EPinfo EnemyPokemon)
    {
        if (EnemyPokemon.EnemyList[0].EnemyPokemonList[0].EnemyPokemonCurrentHealth <= 0 && EnemyPokemon.EnemyList[0].EnemyPokemonList[1].EnemyPokemonCurrentHealth <= 0 && EnemyPokemon.EnemyList[0].EnemyPokemonList[2].EnemyPokemonCurrentHealth <= 0 && EnemyPokemon.EnemyList[1].EnemyPokemonList[0].EnemyPokemonCurrentHealth <= 0 && EnemyPokemon.EnemyList[1].EnemyPokemonList[1].EnemyPokemonCurrentHealth <= 0 && EnemyPokemon.EnemyList[1].EnemyPokemonList[2].EnemyPokemonCurrentHealth <= 0 && EnemyPokemon.EnemyList[2].EnemyPokemonList[0].EnemyPokemonCurrentHealth <= 0 && EnemyPokemon.EnemyList[2].EnemyPokemonList[1].EnemyPokemonCurrentHealth <= 0 && EnemyPokemon.EnemyList[2].EnemyPokemonList[2].EnemyPokemonCurrentHealth <= 0 && EnemyPokemon.EnemyList[3].EnemyPokemonList[0].EnemyPokemonCurrentHealth <= 0 && EnemyPokemon.EnemyList[3].EnemyPokemonList[1].EnemyPokemonCurrentHealth <= 0 && EnemyPokemon.EnemyList[3].EnemyPokemonList[2].EnemyPokemonCurrentHealth <= 0) // if the player defeat all the 4 enemies pokemons and make their lives is zero he will go to winning scene if it is not he will back to the stage scene

        {
            return true;
        }
        else
            return false;
    }




}

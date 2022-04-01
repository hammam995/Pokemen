using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hospital : MonoBehaviour
{
    // the script will be inside the hospital building and from it we will control the panal and open and close it
    // take the player scriptable object and restore all pokemons heal
    // close the panel when we press on the pokemon ball to go back
    // press X butoon in the keyboard to activate the canvas of the hospital
    public GameObject HospitalCanvas;
    public PPinfo PlayerPScriptableObject;
    public Text HealingMassege;
    public GameObject Player;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hospital Contacted with the player");
            if (Input.GetKeyDown(KeyCode.X))
            {
                Time.timeScale = 0;
                Player.SetActive(false);
                HospitalCanvas.SetActive(true);
            }
        }
    }
    public void HealAllPlayerPokemons()
    {
        for (int i = 0; i < PlayerPScriptableObject.PokemonList.Count; i++) // PN is variable to take the pokemon number from the loop
        {
            // i want to control in the left side variables
            PlayerPScriptableObject.PokemonList[i].PlayerPokemonCurrentHealth = PlayerPScriptableObject.PokemonList[i].PlayerPokemonMaxHealth;
            Debug.Log("All player pokemons HP are Restored");
        }

        HealingMassege.text = "All Player Pokemon Healed";
    }

    public void ExitButton()
    {
        HealingMassege.text = "";
        Player.SetActive(true);
        Time.timeScale = 1;
    }
}

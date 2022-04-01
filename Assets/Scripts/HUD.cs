using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // to only controll the pokemon HUD live and level
    // we will take the info from the Player pokemon scriptable object and the Enemy pokemon scriptable object 
    // depends on the pokemon number we will put his info hp ,etc , we will take the info from the Enemy Number and inside it we see his pokemons
    public Text NameText;
    public Text LevelText;
    public Slider HpSlider;
    public Text currentHP; // we have to update it every time we do change to it
    public Text MaxtHP; 
    void Start()
    {
    }
    void Update()
    {

    }
    public void SetHUDPlayer(PPinfo playerPokemon, int PN) // to set the hud for the player pokemon depends on the player pookemon number
    {
        NameText.text = playerPokemon.PokemonList[PN].PlayerPokemonName;
        LevelText.text = "Level " + playerPokemon.PokemonList[PN].PlayerPokemonLevel;
        HpSlider.maxValue = playerPokemon.PokemonList[PN].PlayerPokemonMaxHealth;
        HpSlider.value = playerPokemon.PokemonList[PN].PlayerPokemonCurrentHealth;
        currentHP.text = "" + playerPokemon.PokemonList[PN].PlayerPokemonCurrentHealth + "HP";
        MaxtHP.text = "" + playerPokemon.PokemonList[PN].PlayerPokemonMaxHealth + "HP";

    }
    public void SetHUDEnemy(EPinfo EnemyPokemon, int EnemyNumber, int PN) // to set the hud for the Enemy pokemon depends on the enemy pookemon number
    {
        NameText.text = EnemyPokemon.EnemyList[EnemyNumber].EnemyPokemonList[PN].EnemyPokemonName;
        LevelText.text = "Level " + EnemyPokemon.EnemyList[EnemyNumber].EnemyPokemonList[PN].EnemyPokemonLevel;
        HpSlider.maxValue = EnemyPokemon.EnemyList[EnemyNumber].EnemyPokemonList[PN].EnemyPokemonMaxHealth;
        HpSlider.value = EnemyPokemon.EnemyList[EnemyNumber].EnemyPokemonList[PN].EnemyPokemonCurrentHealth;
        currentHP.text = "" + EnemyPokemon.EnemyList[EnemyNumber].EnemyPokemonList[PN].EnemyPokemonCurrentHealth + "HP";
        MaxtHP.text = "" + EnemyPokemon.EnemyList[EnemyNumber].EnemyPokemonList[PN].EnemyPokemonMaxHealth + "HP";
    }
    public bool EnemyTakeDamage(PPinfo playerPokemon, int PN, EPinfo EnemyPokemon, int EnemyNumber, int EPN) // player pokemon do damage to enemy pokemon
    {
        // pn = pokemon number of the player from the battle who will do the damage to the enemy pokemon number
        // EPN = enemy pokemon number who will recieve the damage from the player pokemon 
        // when the pokemon take damage we check if he is a life or died
        // enemy health - pokemon player damage
        EnemyPokemon.EnemyList[EnemyNumber].EnemyPokemonList[EPN].EnemyPokemonCurrentHealth -= playerPokemon.PokemonList[PN].PlayerPokemonDamagae;
        if (EnemyPokemon.EnemyList[EnemyNumber].EnemyPokemonList[EPN].EnemyPokemonCurrentHealth <= 0) // if the enemy pokemon die return true
            return true;
        else
            return false;
    }
    public bool PlayerTakeDamage(EPinfo EnemyPokemon, int EnemyNumber, int EPN, PPinfo playerPokemon, int PN) //  enemy pokemon do damage to player pokemon(reverse and swap from the above method)
    {
        // pn = pokemon number of the player from the battle who will recieve the attack from the enemy pokemon
        // EPN = enemy pokemon number who will do the attack to the player
        // when the pokemon take damage we check if he is a life or died
        // Player health - pokemon player damage
        playerPokemon.PokemonList[PN].PlayerPokemonCurrentHealth -= EnemyPokemon.EnemyList[EnemyNumber].EnemyPokemonList[EPN].EnemyPokemonDamagae;
        if (playerPokemon.PokemonList[PN].PlayerPokemonCurrentHealth <= 0) // if the player pokemon die return true
            return true;
        else
            return false;
    }
    public void SetHP(float hp) // to check from the current health and from it we decide if the other side live or dead ( if the pokemon live or died)
    {
        HpSlider.value = hp;//to update the slider of the current health for the player or the enemy
    }
    public void Heal(PPinfo playerPokemon, int PN, float increasingAmount) // amount we will increase it to the specific pokemon to the current pokemon of the player
    {
        playerPokemon.PokemonList[PN].PlayerPokemonCurrentHealth += increasingAmount;
        if (playerPokemon.PokemonList[PN].PlayerPokemonCurrentHealth > playerPokemon.PokemonList[PN].PlayerPokemonMaxHealth)
            playerPokemon.PokemonList[PN].PlayerPokemonCurrentHealth = playerPokemon.PokemonList[PN].PlayerPokemonMaxHealth;
        
    }
    // 2 methods to updates the text of the player when he is healing and also i put it when he is having the damagae also the enemy when he is having the damage the text number will be updates
    public void PlayerCurrentTextHP(PPinfo playerPokemon, int PN)
    {
        currentHP.text = "" + playerPokemon.PokemonList[PN].PlayerPokemonCurrentHealth + "HP";
    }
    public void EnemyCurrentTextHP(EPinfo EnemyPokemon, int EnemyNumber, int EPN)
    {
        currentHP.text = "" + EnemyPokemon.EnemyList[EnemyNumber].EnemyPokemonList[EPN].EnemyPokemonCurrentHealth + "HP";
    }
    public bool PlayerCurrentHPWhenCallisZero(PPinfo playerPokemon, int PN)
    {
        if (playerPokemon.PokemonList[PN].PlayerPokemonCurrentHealth <= 0)
            return true;
        else
            return false;

    }
    public bool EnemyCurrentHPisZero(EPinfo EnemyPokemon, int EnemyNumber, int EPN)
    {
        if (EnemyPokemon.EnemyList[EnemyNumber].EnemyPokemonList[EPN].EnemyPokemonCurrentHealth <= 0)
            return true;
        else
            return false;
    }
}

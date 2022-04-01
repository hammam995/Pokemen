using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pokemon : MonoBehaviour
// the commons features between the player and enemy pokemon
// tha Pokemon Script is the parent of the player Pokemon and thr enemy Pokemon
// while the character is the parent of the player and the enemy from outside the battle to make them move
{
    public float PokemonMaxHealth; // the origin and the start health
    public float PokemonCurrentHealth; // the pokemon current health
    public Slider healthbar; //for healthbar maybe we put it in the hud

    public string PokemonName;
    // public PlayerPokemonInfo.PlayerPokemonType Type;
    public int PokemonLevel;
    public float PokemonDamagae; // when we click on the Attack the messure of the damage to do to the other pokemon

    public Animator characterAnimatior;
    void Start()
    {
        PokemonCurrentHealth = PokemonMaxHealth;
        characterAnimatior = GetComponent<Animator>();
    }

    void Update()
    {
        // health = Mathf.Clamp(health, 0, 100);
    }
    protected float healthRange(float newMaxHealth) // in case of udate of Health
    {
        return newMaxHealth;
    }
    protected void takedamage(float amount) // if a character have a damage
    {
        PokemonCurrentHealth -= amount;
        healthbar.value = PokemonCurrentHealth / PokemonMaxHealth;
    }
}

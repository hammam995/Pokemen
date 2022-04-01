using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerPokemonInfo", menuName = "PlayerPokemonSaveData/PlayerPokemonSaveDataObject", order = 1)]


public class PPinfo : ScriptableObject
{
    // here we will put the player pokemons scriptable object
    public List<PlayerPokemonInfo> PokemonList = new List<PlayerPokemonInfo>();
}

[System.Serializable]
public class PlayerPokemonInfo
{
    // every pokemon will have
    public GameObject PlayerPokemonGameObject; // the player will have 3 Pokemons
    public float PlayerPokemonMaxHealth; // the origin and the start health
    public float PlayerPokemonCurrentHealth; // the pokemon current health
    public string PlayerPokemonName;
    public enum PlayerPokemonType { Normal, ice, fire, poison };
    public PlayerPokemonType PPokemonType;
    public int PlayerPokemonLevel;
    public float PlayerPokemonDamagae; // when we click on the Attack the messure of the damage to do to the other pokemon
}



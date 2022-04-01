using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInfo", menuName = "EnemyInfoSaveData/EnemyInfoSaveDataObject", order = 1)]

public class EPinfo : ScriptableObject
{
    // here we will put the enemy number info and his pokemons scriptable object
    public List<EnemyInfo> EnemyList = new List<EnemyInfo>();
}

[System.Serializable]
public class EnemyInfo
{
    //Every enemy will have
    public int EnemyNumber;
    public List<EnemyPokemonInfo> EnemyPokemonList = new List<EnemyPokemonInfo>();
}

[System.Serializable]
public class EnemyPokemonInfo
{
    // every pokemon will have
    public GameObject EnemyPokemonGameObject; // the enemy will have 3 Pokemons so it must be a list
    public float EnemyPokemonMaxHealth; // the origin and the start health
    public float EnemyPokemonCurrentHealth; // the pokemon current health
    public string EnemyPokemonName;
    public enum EnemyPokemonType { Normal, ice, fire, poison };
    public EnemyPokemonType EPokemonType;
    public int EnemyPokemonLevel;
    public float EnemyPokemonDamagae; // when we click on the Attack the messure of the damage to do to the other pokemon
}



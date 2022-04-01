using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public enum BattleState { START, PLAYERTURN, ENEMYTURN, CHANGINGPlayerPOKEMON, CHANGINGEnemyPOKEMON, WON, LOST } // (start to set up the first pokemons , if attack pressed go to next , player turn , if one of the p or e dies we go to next pokemon , if player kill all enemy poke , if enemy kill all player pokemon) at the beggining of player or enemy turn we check if the poke live then we start fight if it is not live we swap to the next pokemon then we back to the person who swapped the pokemon to start fight

public class BattleSystem : MonoBehaviour
{
    // in start we will setup the fight for the first pokeomns by butting very pokemon in his position and his HUD info , the player will have his own methos also he enemy to do the setup
    public Transform playerBattleStation;
    public BattleState state;
    public int PN = 0; // from it we change the pokemon number of the player and we do what we want from it is ability
    public HUD playerHUD;
    public GameObject PPokemonGo;
    public PPinfo PlayerPScriptableObject;
    // enemy section
    public Transform EnemyBattleStation;    
    public int EPN = 0; // enemy pokemon number
    public int EnemyNumber; // we will take the value from the enemy number when he player met the enemy mentioned to change the scene
    public HUD enemyHUD;
    public GameObject EPokemonGo;
    public EPinfo EnemyScriptableObject;    
    public Text dialogueText; // to make the player knows what happens to him
    public bool isEnemyPokemonDead;
    public bool isPlayerPokemonDead;
    public int healinghNumber = 1;
    public bool checkFromPlayerPokemonHealthAttheMomentOfCalling;
    public bool checkFromEnemyPokemonHealth;
    public Button Attack;
    public Button Run;
    public Button inventorty;
    public ESCROBJ EnemyNumberFromScriptableObject;
    public Animator PlayerAnimation;
    public Animator EnemyAnimation;


    void Start()
    {
        EnemyNumber = EnemyNumberFromScriptableObject.EnemyNumber;
        Debug.Log("Enemy Number is == " + EnemyNumber);

        state = BattleState.START;

        StartCoroutine(SetupBattle());

    }
    void Update()
    {
        ATTONEturn();
        RunONturn();
        InvrntoryONturn();
    }
    public void CallPlayerPokemon() // just to call the player pokemon and call the first pokemon is alive in the player pokemon list 
                                    // the same to the enemy 
    {
        checkFromPlayerPokemonHealthAttheMomentOfCalling = playerHUD.PlayerCurrentHPWhenCallisZero(PlayerPScriptableObject, PN);
        if (checkFromPlayerPokemonHealthAttheMomentOfCalling == true)
        {
            PN += 1;
            CallPlayerPokemon();
            return;
        }
        PPokemonGo = Instantiate(PlayerPScriptableObject.PokemonList[PN].PlayerPokemonGameObject, playerBattleStation);
        PlayerAnimation = PPokemonGo.GetComponent<Animator>();
        playerHUD.SetHUDPlayer(PlayerPScriptableObject, PN);


    }
    public void CallEnemyPokemon() // now on this
    {
        checkFromEnemyPokemonHealth = enemyHUD.EnemyCurrentHPisZero(EnemyScriptableObject, EnemyNumber, EPN);
        if (checkFromEnemyPokemonHealth == true && EPN == 2)
        {
            Debug.Log("from the beggining The enemy doesnt have any pokemons");
            state = BattleState.WON;
            StartCoroutine(won());
            
            return;
        }
        else if (checkFromEnemyPokemonHealth == true)
        {
            EPN += 1;
            CallEnemyPokemon();
            return;
        }

        EPokemonGo = Instantiate(EnemyScriptableObject.EnemyList[EnemyNumber].EnemyPokemonList[EPN].EnemyPokemonGameObject, EnemyBattleStation); // enemy number , from it we choose and select his pokemons ,enemy number is the enemy number but pokemon list from it we choose whci pokemon we want from the enemy
        EnemyAnimation = EPokemonGo.GetComponent<Animator>();
        enemyHUD.SetHUDEnemy(EnemyScriptableObject, EnemyNumber, EPN);

    }
    void PlayerTurn() // in player method we change the dialog if the state was player turn ( because the current state is player so the dialog will apear)
    {
        dialogueText.text = "Choose an action:";
        healinghNumber = 1;        
        // in every player turn we check if his current pokemon life or not if it is not we go to next pokemon
    }
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerAttack()); // the player will attack when it is his turn
    }
    public void ATTONEturn() // to make the player only attack in his turn to make the button only work in the player turn even if it was enemy turn the button will not be interactable
    {
        if (state != BattleState.PLAYERTURN)
        {
            Attack.interactable = false;
        }
        if (state == BattleState.PLAYERTURN)
        {
            Attack.interactable = true;
        }
    }
    public void OnHealButton() // when we press on the button the player heal his pokemon we will not go to the enemy turn we will stay in the player state we only change the state when we the player pokemon attack
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerHeal());
        
    }
    public void OnRunButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerRun());
    }
    public void RunONturn() 
    {
        if (state != BattleState.PLAYERTURN)
        {
            Run.interactable = false;
        }
        if (state == BattleState.PLAYERTURN)
        {
            Run.interactable = true;
        }
    }
    public void InvrntoryONturn() // to make the player only attack in his turn to make the button only work in the player turn even if it was enemy turn the button will not be interactable
    {
        if (state != BattleState.PLAYERTURN)
        {
            inventorty.interactable = false;
        }
        if (state == BattleState.PLAYERTURN)
        {
            inventorty.interactable = true;
        }
    }

    IEnumerator PlayerRun()
    {
        for (int i = 0; i < EnemyScriptableObject.EnemyList[EnemyNumber].EnemyPokemonList.Count; i++)
        {
            EnemyScriptableObject.EnemyList[EnemyNumber].EnemyPokemonList[i].EnemyPokemonCurrentHealth = EnemyScriptableObject.EnemyList[EnemyNumber].EnemyPokemonList[i].EnemyPokemonMaxHealth;
        }
        Debug.Log("you are cowerd you escaped from the fight what a shame");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level 1");
    }


    IEnumerator PlayerHeal()
    {
        if (healinghNumber > 0)
        {
            playerHUD.Heal(PlayerPScriptableObject, PN, 25);
            // here we change the bar of hp
            playerHUD.SetHP(PlayerPScriptableObject.PokemonList[PN].PlayerPokemonCurrentHealth); // to change the hp slider of the player
            playerHUD.PlayerCurrentTextHP(PlayerPScriptableObject, PN);
            dialogueText.text = "You feel renewed strength!";
            healinghNumber -= 1;
        }
        else
            dialogueText.text = "Portion only one time in the turn!";
        yield return new WaitForSeconds(2f);
        
    }

    IEnumerator SetupBattle()
    {
        
        // we call the player pokemon and we put his HUD attached to the pokemon we create it or call it
        // next we call the enemy pokemon in the same way and we attache it to the HUD
        // then after doing the 2 two previouois step we move from the start sitiuation to the player sitiuation enumerator 
        CallPlayerPokemon();
        CallEnemyPokemon();



        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN; // after setting up the player and enemy pokemon we change the state to be the playeer turn
        PlayerTurn(); // then we playe the player method
    }
    IEnumerator PlayerAttack() // when we press attack and it is the player turn state
    {
        
        PlayerAnimation.SetTrigger("isAttacking");
        isEnemyPokemonDead = enemyHUD.EnemyTakeDamage(PlayerPScriptableObject, PN, EnemyScriptableObject, EnemyNumber, EPN); // later we change the zero to the pokemon number (player pokemon , player pokemon number , enemypokemon , enemy pokemon number)
        enemyHUD.SetHP(EnemyScriptableObject.EnemyList[EnemyNumber].EnemyPokemonList[EPN].EnemyPokemonCurrentHealth); // to control the current health and change it is value
        enemyHUD.EnemyCurrentTextHP(EnemyScriptableObject, EnemyNumber, EPN);
        dialogueText.text = "The attack is successful!";
        yield return new WaitForSeconds(2f);
        if (isEnemyPokemonDead == true)
        {
            if (EPN < 2)
            {
                Debug.Log("the enemy pokemon died and the state is Changing enemy pokemon");
                state = BattleState.CHANGINGEnemyPOKEMON;
                EnemyAnimation.SetTrigger("isDying");
                yield return new WaitForSeconds(3f);
                StartCoroutine(ChangingEnemyPokemon());
            }
            else
            {
                Debug.Log("the enemy lost all his pokemons the player won the game and the state is won");
                state = BattleState.WON;
                EnemyAnimation.SetTrigger("isDying");
                yield return new WaitForSeconds(5f);
                StartCoroutine(won());
            }
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator EnemyTurn()
    {
        dialogueText.text = "Eenmy " + EnemyScriptableObject.EnemyList[EnemyNumber].EnemyPokemonList[EPN].EnemyPokemonName + " is Attacking";
        yield return new WaitForSeconds(3f);
        EnemyAnimation.SetTrigger("isAttacking");
        isPlayerPokemonDead = playerHUD.PlayerTakeDamage(EnemyScriptableObject, EnemyNumber, EPN, PlayerPScriptableObject, PN);
        playerHUD.SetHP(PlayerPScriptableObject.PokemonList[PN].PlayerPokemonCurrentHealth);
        playerHUD.PlayerCurrentTextHP(PlayerPScriptableObject, PN);        
        if (isPlayerPokemonDead == true)
        {
            if (PN < 2)
            {
                Debug.Log("the player pokemon die and the state is changing player pokemon");
                state = BattleState.CHANGINGPlayerPOKEMON; // it was lost
                PlayerAnimation.SetTrigger("isDying");
                yield return new WaitForSeconds(3f);


                StartCoroutine(ChangingPlayerPokemon());
            }
            else
            {
                Debug.Log("you lost all your pokemon dies");
                state = BattleState.LOST;
                PlayerAnimation.SetTrigger("isDying");
                yield return new WaitForSeconds(5f);
                StartCoroutine(lost());
            }

        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    IEnumerator ChangingPlayerPokemon()
    {
        Destroy(PPokemonGo);
        PN += 1;

        CallPlayerPokemon();
        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }
    IEnumerator ChangingEnemyPokemon()
    {
        Destroy(EPokemonGo);
        EPN += 1;
        CallEnemyPokemon();
        yield return new WaitForSeconds(2f);
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator won()
    {
        Debug.Log("the player did not start the battle because the enemy doesn't have any pokemonsssss you currently in won state you must back to the stage scene");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level 1");
    }
    IEnumerator lost()
    {
        Debug.Log("the player lost all his pokemons you will back to the main stage with HP 1 and enemy will recover all his pokemons hp");
        for (int i = 0; i < PlayerPScriptableObject.PokemonList.Count; i++) // PN is variable to take the pokemon number from the loop
        {
            // i want to control in the left side variables
            PlayerPScriptableObject.PokemonList[i].PlayerPokemonCurrentHealth = 1;
            Debug.Log("All player pokemons HP are 1");
        }
        for (int i = 0; i < EnemyScriptableObject.EnemyList[EnemyNumber].EnemyPokemonList.Count; i++)
        {
            EnemyScriptableObject.EnemyList[EnemyNumber].EnemyPokemonList[i].EnemyPokemonCurrentHealth = EnemyScriptableObject.EnemyList[EnemyNumber].EnemyPokemonList[i].EnemyPokemonMaxHealth;
        }
        Debug.Log("All enemy pokemons HP reset to it's max HP Because the player lost the battle hhhhhh");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level 1");
    }
}








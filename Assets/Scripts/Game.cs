using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Character joueur;
    public Character enemy;
    private bool canInteract = true;

    bool activatedDefense = false;

    public void TryInteract(string action)
    {
        if (!canInteract) return;
        switch (action)
        {
            case "Attack":
                joueur.Attack(enemy);
                StartCoroutine(WaitNextTurn());
                break;
            case "Defend":
                activatedDefense =true;
                StartCoroutine(WaitNextTurn());
                break;
            case "Heal":
                joueur.HealSelf();
                StartCoroutine(WaitNextTurn());

                break;
        }

    }


    public IEnumerator WaitNextTurn()
    {
        CheckDef(joueur);
        canInteract = false;
        yield return new WaitForSeconds(1);
        IATurn();
        CheckDef(enemy);

        yield return new WaitForSeconds(1);
        canInteract = true;
    }

    private void IATurn()
    {
        int randInt = UnityEngine.Random.Range(1, 4);
        if(randInt == 1)
        {
            enemy.Attack(joueur);

        }
        else if (randInt == 2)
        {
            activatedDefense = true;

        }
        else if (randInt == 3) 
        {
            enemy.HealSelf();
        }
        else
        {
            Debug.LogError("T'es débile");
        }

    }
    
    private void CheckDef(Character chara)
    {
        if (activatedDefense)
        {
            activatedDefense = false;
            chara.defense = 0.5f;
        }
        else
        {
            chara.defense = 0;
        }
    }

}

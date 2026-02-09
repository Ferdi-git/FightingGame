using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FIGHT : MonoBehaviour
{
    private float char1Health = 100;
    private float char2Health = 100;
    [SerializeField] private Slider char1;
    [SerializeField] private Slider char2;


    public enum TypeAction
    {
        Attack,
        Defend,
        Heal
    }

    private void Start()
    {
        StartCoroutine(Fight());
    }

    private IEnumerator Fight()
    {
        while (char1Health > 0 && char2Health > 0)
        {
            char2.value = char2Health;

            yield return new WaitForSeconds(0.7f);

 
            char1.value = char1Health;
            yield return new WaitForSeconds(0.7f);

        }
        if(char1Health <= 0)
        {
            print("Char2 Won");
        }
        else
        {
            print("Char1 Won");
        }
    }


    public void ResetFight()
    {
        char1Health = 100;
        char2Health = 100;
        char1.value = char1Health;
        char2.value = char2Health;
        StopAllCoroutines();
        StartCoroutine(Fight());
    }



    }




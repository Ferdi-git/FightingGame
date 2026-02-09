using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    private float maxHealth = 100;
    [SerializeField] private float Health = 100f;
    public float health {
        get { return Health; } 
        set {Health = value; CheckIfAlive(); } 
    }


    public float defense = 0f;
    private float strength = 20f;
    private float healMult = 0.2f;
    private float critChance = 0.2f;
    private float critMult = 2f;

    [SerializeField] SOEventChara eventChara;

    public UnityEvent CharacterDie;

    public void GetHit(float dmgTaken)
    {
        dmgTaken *= 1-defense;
        dmgTaken = Mathf.Max(dmgTaken, 0); 
        health -= dmgTaken;
        eventChara.GetHitInvoke(dmgTaken);
    }

    public void GetHealed(float nbrToHeal)
    {
        health += nbrToHeal;
        eventChara.GetHealedInvoke(nbrToHeal);
    }

    public void CheckIfAlive()
    {
        if(health <= 0)
        {
            OnCharaDeath();
            CharacterDie.Invoke();
        }
    }

    public void Attack(Character charaToAtk)
    {
        float dmgToDeal = CalculateDamage();
        charaToAtk.GetHit(dmgToDeal);
    }

    public void HealSelf()
    {
        float healedFor = maxHealth * healMult;
        GetHealed(healedFor);
    }



    private float CalculateDamage()
    {
        float dmg = strength;
        float randomFloat = Random.Range(0, 1f);

        if (critChance > randomFloat)
        {
            dmg *= critMult;
            print("CRITICAL HIT " + dmg);

        }
        return dmg;
    }

    private void OnCharaDeath()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;
using UnityEngine.UI;
public class UIVisual : MonoBehaviour
{
    [SerializeField] private SOEventChara eventPlayer;
    [SerializeField] private SOEventChara eventEnemy;
    [SerializeField] private Slider playerHealth;
    [SerializeField] private Slider enemyhealth;


    private void Start()
    {
        eventPlayer.GetHit += RemovePlayerHealth;
        eventPlayer.GetHealed += AddPlayerHealth;
        eventEnemy.GetHit += RemoveEnemyHealth;
        eventEnemy.GetHealed += AddEnemyHealth;
    }
    public void RemovePlayerHealth(float dmg)
    {
        playerHealth.value -= dmg;
    }
    public void AddPlayerHealth(float dmg)
    {
        playerHealth.value += dmg;
    }

    public void RemoveEnemyHealth(float dmg)
    {
        enemyhealth.value -= dmg;
    }
    public void AddEnemyHealth(float dmg)
    {
        enemyhealth.value += dmg;
    }

}

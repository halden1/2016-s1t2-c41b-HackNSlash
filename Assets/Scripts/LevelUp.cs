using UnityEngine;
using System.Collections;

public class LevelUp : MonoBehaviour
{

    #region Public Variables
    public string playerStatsTag = "Player"; // the tag of the object that hold the player stats scripts

    public int healthPerLevel =10;
    public int attackPerLevel = 1;
    public int defencePerLevel = 0;
    public float speedPerLevel = 0;

    public float rangedAttackRangePerLevel = 0;
    public int rangedAttackPerLevel = 1;
    public int rangedAttackAmmoPerLevel = 0;
    public float rangedAttackSpeedPerLevel = 0;
    #endregion


    #region Private Variables
    private PlayerStats playerStats;

    private int currentLevel = 0;
    private int currentExp = 0;
    private int expToLevelUp = 1;
    private static int tmp;
    #endregion

    void Start()
    {
        //get exp and level from player stats 
        playerStats = FindObjectOfType<PlayerStats>();
        currentLevel = playerStats.getLevel();
        currentExp = playerStats.getExp();
        expToLevelUp = playerStats.getMaxExp();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentExp >= expToLevelUp)
        {
            
            playerStats.addMaxExp(10);
            expToLevelUp = playerStats.getMaxExp();

            playerStats.addLevel(1);//save these to the player stat class

            playerStats.addMaxHealth(10);
            tmp = playerStats.getMaxHealth();
            playerStats.addAttack(attackPerLevel);
            playerStats.addDefence(defencePerLevel);
            playerStats.addSpeed(speedPerLevel);

            playerStats.addRangedAttackRange(rangedAttackRangePerLevel);
            playerStats.addRangedAttackDamage(rangedAttackPerLevel);
            playerStats.addRangedAttackAmmo(rangedAttackAmmoPerLevel);
            playerStats.addRangedAttackSpeed(rangedAttackSpeedPerLevel);

            playerStats.addExp(playerStats.getExp() * -1);
            currentExp = 0;
        }
    }
    public void forceLevelup() { currentExp = expToLevelUp; }


    public void expUp(int exp)
    {
        currentExp += exp;
        playerStats.addExp(exp);
    }
}

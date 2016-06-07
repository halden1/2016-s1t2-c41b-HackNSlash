using UnityEngine;
using System.Collections;

public class LevelUp : MonoBehaviour {

    #region Public Variables
    public string playerStatsTag = "Player"; // the tag of the object that hold the player stats scripts
    
    public float healthPerLevel = 0;
    public int attackPerLevel = 1;
    public int defencePerLevel = 0;
    public float speedPerLevel = 0;
    #endregion


    #region Private Variables
    private PlayerStats playerStats;

    private int currentLevel = 0;
    private int currentExp = 0;
    private int expToLevelUp = 10;

    #endregion
    void Start () {
        //get exp and level from player stats 
        playerStats = FindObjectOfType<PlayerStats>();
        currentLevel = playerStats.getLevel();
        currentExp = playerStats.getExp();
    }
	
	// Update is called once per frame
	void Update () {
        if (currentExp >= expToLevelUp)
        {
            expToLevelUp += expToLevelUp;//exp to level up doubles each level
            playerStats.addLevel(1);//save these to the player stat class
            playerStats.addHealth(healthPerLevel);
            playerStats.addAttack(attackPerLevel);
            playerStats.addDefence(defencePerLevel);
            playerStats.addSpeed(speedPerLevel);
            playerStats.addExp(currentExp - playerStats.getExp());
        }
	}
    public void forceLevelup() { currentExp = expToLevelUp; }
}

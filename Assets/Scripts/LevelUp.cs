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

    private int currentLevel = 0;
    private int currentExp = 0;
    private int expToLevelUp = 10;

    #endregion
    void Start () {
        //get exp and level from player stats 
        currentLevel = GameObject.FindGameObjectWithTag(playerStatsTag).GetComponent<PlayerStats>().getLevel();
        currentExp = GameObject.FindGameObjectWithTag(playerStatsTag).GetComponent<PlayerStats>().getExp();
    }
	
	// Update is called once per frame
	void Update () {
        if (currentExp >= expToLevelUp)
        {
            currentLevel++;
            expToLevelUp += expToLevelUp;//exp to level up doubles each level

            GameObject.FindGameObjectWithTag(playerStatsTag).GetComponent<PlayerStats>().addLevel(1);//save these to the player stat class
            GameObject.FindGameObjectWithTag(playerStatsTag).GetComponent<PlayerStats>().addHealth(healthPerLevel);
            GameObject.FindGameObjectWithTag(playerStatsTag).GetComponent<PlayerStats>().addAttack(attackPerLevel);
            GameObject.FindGameObjectWithTag(playerStatsTag).GetComponent<PlayerStats>().addDefence(defencePerLevel);
            GameObject.FindGameObjectWithTag(playerStatsTag).GetComponent<PlayerStats>().addSpeed(speedPerLevel);
            GameObject.FindGameObjectWithTag(playerStatsTag).GetComponent<PlayerStats>().addExp(currentExp - GameObject.FindGameObjectWithTag(playerStatsTag).GetComponent<PlayerStats>().getExp());
        }
	}
    public void forceLevelup() { currentExp = expToLevelUp; }
}

using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{

    #region Public Variables
    
    #endregion

    #region Private Variables

    public int level = 0;
    public int exp = 0;
    public int maxExp = 10;

    public int health = 100;
    public int maxHealth = 100;

    private int attack = 10;
    private int defence = 10;
    private float speed = 10;

    private float rangedAttackRange = 20;
    private int rangedAttackDamage = 5;
    private int rangedAttackAmmo = 3;
    private float rangedAttackSpeed = 5;



    #endregion

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0) { Destroy(this.gameObject); }
        if (health > maxHealth) { health = maxHealth; }
    }
    //adder funtions
    public void addLevel(int tmpLevel) { level += tmpLevel; }
    public void addExp(int tmpExp) { exp = exp + tmpExp;  }
    public void addMaxExp(int tmpMaxExp) { maxExp += tmpMaxExp; }
    public void addHealth(int tmpHealth) { health += tmpHealth; if (health > maxHealth) { health = maxHealth; } }
    public void addMaxHealth(int tmpMaxHealth) { maxHealth += tmpMaxHealth; health = maxHealth; }
    public void addAttack(int tmpAttack) { attack += tmpAttack; }
    public void addDefence(int tmpDefence) { defence += tmpDefence; }
    public void addSpeed(float tmpSpeed) { speed += tmpSpeed; }

    public void addRangedAttackRange(float tmpRangedAttackRange) { rangedAttackRange += tmpRangedAttackRange; }
    public void addRangedAttackDamage(int tmpRangedAttackDamage) { rangedAttackDamage += tmpRangedAttackDamage; }
    public void addRangedAttackAmmo(int tmpRangedAttackAmmo) { rangedAttackAmmo += tmpRangedAttackAmmo; }
    public void addRangedAttackSpeed(float tmpRangedAttackSpeed) { rangedAttackSpeed += tmpRangedAttackSpeed; }


    //getters
    public int getLevel() { return level; }
    public int getExp() { return exp; }
    public int getMaxExp() { return maxExp; }
    public int getHealth() { return health; }
    public int getMaxHealth() { return maxHealth; }
    public int getAttack() { return attack; }
    public int getDefence() { return defence; }
    public float getSpeed() { return speed; }

    public float getRangedAttackRange() { return rangedAttackRange; }
    public int getRangedAttackDamage() { return rangedAttackDamage; }
    public int getRangedAttackAmmo() { return rangedAttackAmmo; }
    public float getRangedAttackSpeed() { return rangedAttackSpeed; }



    public void takingDamage(int damage) { health -= damage; }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    #region Public Variables
    
    #endregion

    #region Private Variables

    private int level = 0;
    private int exp = 0;
	[SerializeField]
    private int health = 100;
	[SerializeField]
    private int maxHealth = 100;
    public int maxExp = 10;


    private int attack = 10;
    private int defence = 10;
    private float speed = 10;

    private float rangedAttackRange = 20;
    private int rangedAttackDamage = 5;
    private int rangedAttackAmmo = 3;
    private float rangedAttackSpeed = 5;
	public Slider Shealth;
	public Slider EXP;
	public Text Tlevel;
	public Text Texp;
	public Text Tattack;
	public Text Tdefence;
	public Text Tspeed;
	public Text Thealth;


    #endregion

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		
		Shealth.value = health;
		Shealth.maxValue = maxHealth;
	//	EXP.maxValue = MAX EXP
		EXP.value = exp;
		Tlevel.text = "Level: " + level.ToString();
		Texp.text = "Exp: " + exp.ToString();
		Tattack.text = "Attack: " + attack.ToString();
		Tdefence.text = "Defense: " + defence.ToString();
		Tspeed.text = "Speed: " + speed.ToString();
		Thealth.text = "Health: " + health.ToString();


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

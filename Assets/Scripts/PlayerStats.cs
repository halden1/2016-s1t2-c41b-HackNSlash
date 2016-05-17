using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    #region Public Variables



    #endregion

    #region Private Variables

    private int level = 0;
    private int exp = 0;
    private float health = 0;
    private int attack = 0;
    private int defence = 0;
    private float speed = 0;

    #endregion

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void addLevel(int tmpLevel) { level += tmpLevel; }
    public void addExp(int tmpExp) { exp += tmpExp; }
    public void addHealth(float tmp) { health += tmp; }
    public void addAttack(int tmpAttack) { attack += tmpAttack; }
    public void addDefence(int tmpDefence) { defence += tmpDefence; }
    public void addSpeed(float tmpSpeed) { speed += tmpSpeed; }

    public int getLevel() { return level; }
    public int getExp() { return exp; }
    public float getHealth() { return health; } 
    public int getAttack(){ return attack; }
    public int getDefence(){ return defence; }
    public float getSpeed(){ return speed; }
}

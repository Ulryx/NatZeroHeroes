using UnityEngine;

[System.Serializable]
public class Character
{
    public string name;
    public int maxHP;
    public int currentHP;

    public Character(string name, int hp)
    {
        this.name = name;
        this.maxHP = hp;
        this.currentHP = hp;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Max(currentHP, 0);
    }

    public bool IsDead()
    {
        return currentHP <= 0;
    }
}

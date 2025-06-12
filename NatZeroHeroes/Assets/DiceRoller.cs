using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceRoller : MonoBehaviour
{
    // === UI References ===
    public TextMeshProUGUI resultText;
    public Button rollButton;
    public TextMeshProUGUI heroHPText;
    public TextMeshProUGUI enemyHPText;
    public TextMeshProUGUI heroNameText;
    public TextMeshProUGUI enemyNameText;

    // === Character Data ===
    private Character hero;
    private Character enemy;

    void Start()
    {
        // Create Characters
        hero = new Character("Big D", 20);
        enemy = new Character("Nanners", 20);

        // Display Names
        heroNameText.text = hero.name;
        enemyNameText.text = enemy.name;

        // Hook Roll Button
        rollButton.onClick.AddListener(RollDice);
        UpdateHP();
    }

    void RollDice()
    {
        int heroRoll = Random.Range(1, 7);
        int enemyRoll = Random.Range(1, 7);

        string outcome = $"{hero.name} rolled {heroRoll} | {enemy.name} rolled {enemyRoll}\n";

        if (heroRoll > enemyRoll)
        {
            enemy.TakeDamage(heroRoll);
            outcome += $"{hero.name} hits {enemy.name} for {heroRoll} damage!";
        }
        else if (enemyRoll > heroRoll)
        {
            hero.TakeDamage(enemyRoll);
            outcome += $"{enemy.name} strikes back! {hero.name} takes {enemyRoll} damage!";
        }
        else
        {
            outcome += "It's a draw — both hesitate dramatically.";
        }

        resultText.text = outcome;
        UpdateHP();

        if (hero.IsDead())
        {
            resultText.text += $"\n {hero.name} has fallen!";
            rollButton.interactable = false;
        }
        else if (enemy.IsDead())
        {
            resultText.text += $"\n {hero.name} defeats {enemy.name}!";
            rollButton.interactable = false;
        }
    }

    void UpdateHP()
    {
        heroHPText.text = $"Hero HP: {hero.currentHP}";
        enemyHPText.text = $"Enemy HP: {enemy.currentHP}";
    }
}

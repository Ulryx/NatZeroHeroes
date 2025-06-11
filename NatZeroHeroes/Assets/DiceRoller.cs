using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceRoller : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public Button rollButton;

    void Start()
    {
        rollButton.onClick.AddListener(RollDice);
    }

    void RollDice()
    {
        int roll = Random.Range(1, 7);
        resultText.text = $"You rolled a {roll}";
    }
}

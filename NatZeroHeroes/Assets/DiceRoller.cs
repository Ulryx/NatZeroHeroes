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

        // Color feedback
        if (roll == 1)
            resultText.color = Color.red;
        else if (roll == 6)
            resultText.color = new Color32(213, 160, 33, 255);
        else
            resultText.color = Color.white;
    }
}

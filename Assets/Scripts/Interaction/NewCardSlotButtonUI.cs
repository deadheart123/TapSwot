using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewCardSlotButtonUI : MonoBehaviour
{
    [SerializeField] private List<Button> buttons = new List<Button>();
    [SerializeField] private List<TMP_Text> texts = new List<TMP_Text>();

    // Start is called before the first frame update
    public void ResetAllButtonToInteractable()
    {
        foreach(Button button in buttons)
        {
            button.interactable = true;
        }

        foreach(TMP_Text text in texts)
        {
            text.text = "Swap to This Card";
        }
    }

}

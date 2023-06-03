using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomInputUI : MonoBehaviour
{
    // Condition Check
    [SerializeField] private TMP_InputField roomInput;

    [SerializeField] private Button ProceedButton;
    [SerializeField] private GameObject warningMsg;
    [SerializeField] private GameObject okMsg;

    [SerializeField] private CanvasGroup errorMsg;
    [SerializeField] private TMP_Text errorText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckRoomName();
    }

    public void CheckRoomName()
    {
        if(roomInput.text == "")
        {
            ProceedButton.interactable = false;
            warningMsg.SetActive(true);
            okMsg.SetActive(false);
        }
        else
        {
            ProceedButton.interactable = true;
            warningMsg.SetActive(false);
            okMsg.SetActive(true);
        }
    }

    public void DisplayErrorMessage(string message)
    {
        StartCoroutine(PlayErrorMessage(message));
    }

    public IEnumerator PlayErrorMessage(string message)
    {
        errorText.text = message;
        for(int i = 0; i < 50; i++)
        {
            errorMsg.alpha += 0.02f;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        for(int i = 0; i < 50; i++)
        {
            errorMsg.alpha -= 0.02f;
            yield return new WaitForSeconds(0.08f);
        }
    }
}

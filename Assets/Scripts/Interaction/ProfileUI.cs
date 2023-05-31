using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileUI : MonoBehaviour
{
    /**
    * First time - Profile title -> Create your profile.
    *                            -> Only Save and Proceed.
    *
    * Second time - Profile title -> Edit your profile.
    *                             -> Save and Back.
    *
    */

    // Condition Check
    [SerializeField] private TMP_InputField usernameInput;

    // UI
    [SerializeField] private bool isCreated;
    [SerializeField] private TMP_Text ProfileTitle;
    [SerializeField] private GameObject Backbtn;
    [SerializeField] private Button ProceedButton;
    [SerializeField] private TMP_Text ProceedbtnText;
    [SerializeField] private GameObject warningMsg;
    [SerializeField] private GameObject okMsg;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckUsername();
        CheckCreateStatus();
    }

    public void CheckUsername()
    {
        if(usernameInput.text == "")
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

    public void AlreadyCreate()
    {
        isCreated = true;
    }

    public void CheckCreateStatus()
    {
        if(isCreated == true)
        {
            ProfileTitle.text = "<font-weight=900>EDIT YOUR PROFILE";
            ProceedbtnText.text = "<font-weight=900>APPLY CHANGES";
            Backbtn.SetActive(true);
        }
        else
        {
            ProfileTitle.text = "<font-weight=900>CREATE YOUR PROFILE";
            ProceedbtnText.text = "<font-weight=900>CREATE PROFILE";
            Backbtn.SetActive(false);
        }
    }
}

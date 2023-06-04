using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MascotTalkAnimation : MonoBehaviour
{
    [SerializeField] private float time = 0f;
    [SerializeField] private RectTransform obj;
    [SerializeField] private RectTransform mascot;
    [SerializeField] private CanvasGroup speechBubble;
    [SerializeField] private GameObject buttonGroup;
    [SerializeField] private Vector2 startAnchor;
    [SerializeField] private Vector2 finishAnchor;

    void Start()
    {
        obj.anchoredPosition = startAnchor;
        speechBubble.alpha = 0f;
        StartCoroutine(EnterTheScene());
        if(buttonGroup != null)
        {
            buttonGroup.SetActive(false);
        }
    }

    void OnEnable()
    {
        obj.anchoredPosition = startAnchor;
        speechBubble.alpha = 0f;
        if(buttonGroup != null)
        {
            buttonGroup.SetActive(false);
        }
        StartCoroutine(EnterTheScene());
        Debug.Log(gameObject.name + ":onenable");
    }

    void OnDisable()
    {
        Debug.Log(gameObject.name + ":ondisable");
    }

    void Update()
    {
        time = time + Time.deltaTime;
        if(time >= 4f)
        {
            StartCoroutine(Idle());
            time = 0f;
        }
    }
    
    public IEnumerator EnterTheScene()
    {
        yield return new WaitForSeconds(0.4f);
        obj.DOAnchorPos(finishAnchor,0.5f,false);
        yield return new WaitForSeconds(0.5f);
        speechBubble.alpha = 1f;
        if(buttonGroup != null)
        {
            buttonGroup.SetActive(true);
        }
        StartCoroutine(Idle());
        yield return null;
    }

    public IEnumerator Idle()
    {
        mascot.DOAnchorPosY(mascot.anchoredPosition.y-30,1.9f,false);
        yield return new WaitForSeconds(2f);
        mascot.DOAnchorPosY(mascot.anchoredPosition.y+30,1.9f,false);
        yield return new WaitForSeconds(2f);
        yield return null;
    }
}

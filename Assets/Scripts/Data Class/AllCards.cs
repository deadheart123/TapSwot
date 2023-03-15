using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CardList", menuName = "Add CardList SO")]
public class AllCards : ScriptableObject
{
    public List<CardSO> cards = new List<CardSO>();
}


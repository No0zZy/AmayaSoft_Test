using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public UnityEvent correctChoice;
    public UnityEvent incorrectChoice;

    public void OnItemClicked(ItemHolder item)
    {
        gameManager.SetChosedItemHolder(item);

        if (item == gameManager.GoalItemHodler)
        {
            correctChoice?.Invoke();
        }
        else
        {
            incorrectChoice?.Invoke();
        }
    }
}
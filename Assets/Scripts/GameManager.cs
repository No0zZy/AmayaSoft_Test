using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AnimationsManager animManager;
    [SerializeField] private GameUI gameUI;
    public ItemHolder GoalItemHodler { get; private set; }

    public UnityEvent gameStart;
    public UnityEvent levelPassed;

    private ItemHolder chosedItemHolder;

    private void Start()
    {
        gameStart?.Invoke();
    }

    public void SetGoalItemHolder(ItemHolder itemHolder)
    {
        GoalItemHodler = itemHolder;
        gameUI.GoalText.text = $"Find {GoalItemHodler.Value}";
    }

    public void SetChosedItemHolder(ItemHolder itemHolder)
    {
        chosedItemHolder = itemHolder;
    }

    public void OnCorrectChoice()
    {
        StartCoroutine(WaitCorrectAnimationEnd(animManager.Bounce(chosedItemHolder.ItemTransform)));
    }

    public void OnIncorrectChoice()
    {
        animManager.ShakePosition(chosedItemHolder.ItemTransform);
    }

    private IEnumerator WaitCorrectAnimationEnd(float animationDuration)
    {
        yield return new WaitForSeconds(animationDuration);
        levelPassed?.Invoke();
    }

    public void OnRestartGame()
    {
        gameStart?.Invoke();
    }
}

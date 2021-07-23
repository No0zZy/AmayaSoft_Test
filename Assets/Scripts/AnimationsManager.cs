using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class AnimationsManager : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private InputHandler inputHandler;

    [Header("Correct Choise")]
    [SerializeField] private float bounceDuration;
    [Header("Incorrect Choise")]
    [SerializeField] private float shakePositionDuration;
    [SerializeField] private int shakePositionStrength;
    [Header("Scale One (OnGameStart)")]
    [SerializeField] private float scaleOneDuration;
    [Header("Fade Text")]
    [SerializeField] private float fadeTextDuration;
    [Header("Fade Panel")]
    [SerializeField] private float fadeImageDuration;
    [Header("Start Animation")]
    [SerializeField] private float secondsPerItemHolder;

    public UnityEvent restartAnimationDone;

    public float Bounce(Transform target)
    {
        target.DOScale(1.2f, 0.33f * bounceDuration)
            .OnComplete(() => target.DOScale(0.9f, 0.33f * bounceDuration)
                .OnComplete(() => target.DOScale(1f, 0.33f * bounceDuration)));

        return bounceDuration;
    }

    public float ShakePosition(Transform target)
    {
        target.DOShakePosition(shakePositionDuration, shakePositionStrength);

        return shakePositionDuration;
    }

    public float SetScaleOne(Transform target)
    {
        target.DOScale(1f, scaleOneDuration);

        return scaleOneDuration;
    }

    public void SetScaleZero(Transform target)
    {
        target.DOScale(0f, 0f);
    }

    public float FadeTextShow(Text text)
    {
        text.DOFade(1f, fadeTextDuration);

        return fadeTextDuration;
    }
    public float FadeTextHide(Text text)
    {
        text.DOFade(0f, fadeTextDuration);

        return fadeTextDuration;
    }

    public float FadeImageShow(Image image)
    {
        image.DOFade(1f, fadeImageDuration);

        return fadeImageDuration;
    }
    public float FadeImageShow(Image image, float showValue)
    {
        image.DOFade(showValue, fadeImageDuration);

        return fadeImageDuration;
    }

    public float FadeImageHide(Image image)
    {
        image.DOFade(0f, fadeImageDuration);

        return fadeImageDuration;
    }

    public void GameStartAnimation()
    {
        StartCoroutine(GameStartAnim());
    }

    private IEnumerator GameStartAnim()
    {
        for (int i = 0; i < levelManager.ItemsPerLevel; i++)
        {
            SetScaleZero(levelManager.ItemHolders[i].transform);
            levelManager.ItemHolders[i].gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(FadeImageHide(gameUI.LoadingPanel));
        gameUI.LoadingPanel.gameObject.SetActive(false);

        for (int i = 0; i < levelManager.ItemsPerLevel; i++)
        {
            SetScaleOne(levelManager.ItemHolders[i].transform);
            yield return new WaitForSeconds(secondsPerItemHolder);
        }

        FadeTextShow(gameUI.GoalText);
    }

    public void GameRestartAnimation()
    {
        StartCoroutine(GameRestartAnim());
    }

    private IEnumerator GameRestartAnim()
    {
        gameUI.LoadingPanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(FadeImageShow(gameUI.LoadingPanel));
        gameUI.OnGameRestart();
        restartAnimationDone?.Invoke();
    }
}
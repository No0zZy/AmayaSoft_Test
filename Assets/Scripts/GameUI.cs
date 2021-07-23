using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private AnimationsManager animManager;
    [SerializeField] private Text goalText;
    public Text GoalText => goalText;

    [SerializeField] private Image loadingPanel;
    public Image LoadingPanel => loadingPanel;
    [SerializeField] private Image backGroundPanel;
    [Range(0,1)][SerializeField] private float backGroundPanelFadeValue;
    [SerializeField] private Button restartButton;

    public void OnGameComlete()
    {
        backGroundPanel.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        animManager.FadeImageShow(backGroundPanel, backGroundPanelFadeValue);
        animManager.SetScaleZero(restartButton.transform);
        animManager.Bounce(restartButton.transform);
    }

    public void OnGameRestart()
    {
        GoalText.color = new Color(1, 1, 1, 0);
        restartButton.transform.localScale = new Vector3(0, 0, 0);
        backGroundPanel.color = new Color(backGroundPanel.color.r, backGroundPanel.color.g, backGroundPanel.color.b, 0);
        restartButton.gameObject.SetActive(false);
        backGroundPanel.gameObject.SetActive(false);
    }
}

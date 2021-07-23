using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private Item[] itemsDB;
    [SerializeField] private ItemHolder[] itemHolders;
    public ItemHolder[] ItemHolders => itemHolders;
    [SerializeField] private int itemsPerLevel;
    public int ItemsPerLevel => itemsPerLevel;
    [SerializeField] private int maxLevels;
    public int Level { get; private set; }

    public UnityEvent gameComplete;

    private List<int> itemsIdInGame;
    private List<string> itemsValuesUsed;

    private void Awake()
    {
        itemsIdInGame = new List<int>();
        itemsValuesUsed = new List<string>();
    }

    public void OnLevelPassed()
    {
        if(Level + 1 <= maxLevels)
        {
            Level++;
            OnLevelStart();
        }    
        else
        {
            gameComplete?.Invoke();
        }
    }

    private void OnLevelStart()
    {
        itemsIdInGame.Clear();

        FillItemHolders();
        ChooseGoalItem();
    }

    public void OnStartGame()
    {
        foreach (var i in itemHolders)
        {
            i.gameObject.SetActive(false);
        }

        Level = 1;
        itemsValuesUsed.Clear();
        OnLevelStart();
    }

    private void FillItemHolders()
    {
        int itemId = 0;
        for (int i = 0; i < Level * itemsPerLevel; i++)
        {
            bool itemAdded = false;

            while (!itemAdded)
            {
                itemId = Random.Range(0, itemsDB.Length);
                itemAdded = true;

                foreach (var v in itemsIdInGame)
                    if (v == itemId)
                    {
                        itemAdded = false;
                        break;
                    }
            }

            itemsIdInGame.Add(itemId);
            itemHolders[i].gameObject.SetActive(true);
            itemHolders[i].SetItem(itemsDB[itemId]);
        }

    }

    private void ChooseGoalItem()
    {
        string itemValue = "";
        int itemId = 0;
        bool itemFound = false;
        while (!itemFound)
        {
            itemId = Random.Range(0, Level * itemsPerLevel);
            itemValue = itemHolders[itemId].Value;

            itemFound = true;
            foreach (var i in itemsValuesUsed)
                if (i == itemValue)
                {
                    itemFound = false;
                    break;
                }
        }

        itemsValuesUsed.Add(itemValue);
        gameManager.SetGoalItemHolder(itemHolders[itemId]);
    }
}

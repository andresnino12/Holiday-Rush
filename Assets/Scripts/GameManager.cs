using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public FinishScreen finishScreen;

    public ItemType currentTarget;

    private List<ItemType> remainingItems = new List<ItemType>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        remainingItems.AddRange((ItemType[])System.Enum.GetValues(typeof(ItemType)));

        ChooseNextItem();
    }

    public void ChooseNextItem()
    {
        if (remainingItems.Count == 0)
        {
            FinishScreen.Log("¡Todos los adornos fueron colocados!");
            finishScreen.ObjetosCompletos();
            return;
        }

        int randomIndex = Random.Range(0, remainingItems.Count);

        currentTarget = remainingItems[randomIndex];

        remainingItems.RemoveAt(randomIndex);

        FinishScreen.Log("Busca: " + currentTarget);
    }   
}
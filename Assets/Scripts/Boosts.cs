using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Boosts : MonoBehaviour
{
    public int BoostCount;
    [SerializeField] private List<GameObject> BoostsList = new List<GameObject>();

    [SerializeField] private Sprite BoostPrefabAvalible;
    [SerializeField] private Sprite BoostPrefabUsed;

    [SerializeField] private float rechargeTime = 5f;

    private float timer;


    private void Start()
    {
        BoostCount = BoostsList.Count;
        timer = rechargeTime;
    }

    public bool UseBoost()
    {
        if (BoostCount > 0)
        {
            BoostCount--;
            Debug.Log("Boosts left: " + BoostCount);
            UpdateGameobjects();
            return true;
        }
        else
        {
            Debug.Log("No boosts left!");
            return false;
        }
    }

    private void UpdateGameobjects()
    {
        for (int i = 0; i < BoostsList.Count; i++)
        {
            Image image = BoostsList[i].GetComponent<Image>();

            if (i >= BoostCount)
            {
                image.sprite = BoostPrefabUsed;
            }
            else
            {
                image.sprite = BoostPrefabAvalible;
            }
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = rechargeTime;
            BoostCount += 1;
            UpdateGameobjects();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class CreatePotion : MonoBehaviour, IAction
{
    float range = 3f;

    PickUpItem pickUpItem;
    BarTableBehaviour target;
    ActionScheduler actionScheduler;
    Move move;

    void Awake()
    {
        pickUpItem = GetComponent<PickUpItem>();
        actionScheduler = GetComponent<ActionScheduler>();
        move = GetComponent<Move>();
    }

    private void Update()
    {
        if (target == null) return;
        if (!GetIsInRange())
        {
            move.MoveTo(target.transform.position);
        }
        else
        {
            move.Cancel();
            CreatePotionBehaviour();
        }
    }
    private bool GetIsInRange()
    {
        return Vector3.Distance(transform.position, target.transform.position) < range;
    }

    public void PotionCreation(GameObject _target)
    {
        actionScheduler.StartAction(this);
        target = _target.GetComponent<BarTableBehaviour>();
    }

    public void Cancel()
    {
        target = null;
    }

    public bool CanCreatePotion(GameObject target)
    {
        if (target == null)
        {
            return false;
        }
        return true;
    }

    public void CreatePotionBehaviour()
    {
        foreach (Recipes i in target.GetComponent<BarTableBehaviour>().GetRecipes())
        {
            Debug.Log("No");
            if (i.GetIngredients().Count != pickUpItem.itemList.Count)
            {
                continue;
            }
            bool areEqual = CompareLists(i.GetIngredients(), pickUpItem.itemList);
            if(areEqual)
            {
                foreach (Transform j in pickUpItem.itemSprites)
                {
                    Destroy(j.gameObject);
                }
                pickUpItem.itemSprites.Clear();
                pickUpItem.itemList.Clear();

                pickUpItem.AddImage(i.GetFinalItem().GetItemSprite());
                pickUpItem.itemList.Add(i.GetFinalItem());
            }
        }
        target = null;
    }

    private bool CompareLists(List<Item> list1, List<Item> list2)
    {
        return list1.OrderBy(item => item.GetHashCode()).SequenceEqual(list2.OrderBy(item => item.GetHashCode()));
    }
}

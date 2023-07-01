using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItems : MonoBehaviour, IAction
{

    float range = 3f;

    TrashCan target;
    Move move;
    PickUpItem pickUpItem;
    ActionScheduler actionScheduler;

    private void Awake()
    {
        move = GetComponent<Move>();
        pickUpItem = GetComponent<PickUpItem>();
        actionScheduler = GetComponent<ActionScheduler>();
    }

    void Update()
    {
        if (target == null) return;
        if (!GetIsInRange())
        {
            move.MoveTo(target.transform.position);
        }
        else
        {
            move.Cancel();
            DeleteItemsBehaviour();
        }
    }

    public void Cancel()
    {
        target = null;
    }

    private bool GetIsInRange()
    {
        return Vector3.Distance(transform.position, target.transform.position) < range;
    }

    public void DeletePickedItems(GameObject _target)
    {
        actionScheduler.StartAction(this);
        target = _target.GetComponent<TrashCan>();
    }

    void DeleteItemsBehaviour()
    {
        foreach(Transform i in pickUpItem.itemSprites)
        {
            Destroy(i.gameObject);
        }
        pickUpItem.itemSprites.Clear();
        pickUpItem.itemList.Clear();
        target = null;
    }
}

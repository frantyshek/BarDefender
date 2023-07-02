using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] AudioClip[] deliverAudioClips;
    [SerializeField] Animator anim;

    AudioSource audioS;
    Move move;
    PickUpItem pickUpItem;

    private void Awake()
    {
        move = GetComponent<Move>();
        pickUpItem = GetComponent<PickUpItem>();
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        //if (health.IsDead()) return;
        if (DoDeliverItem()) return;
        if (DoCreatePotion()) return;
        if (DoPickUpItem()) return;
        if (DoDeletePickedItems()) return;
        if (DoMovement()) return;
    }

    bool DoDeliverItem()
    {
        RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
        foreach (RaycastHit hit in hits)
        {
            EnemyBehaviour target = hit.transform.GetComponent<EnemyBehaviour>();
            if (target == null) continue;
            if (pickUpItem.itemList.Count == 0) continue;
            if(target.GetWantedItem().GetItemIndex() != pickUpItem.itemList[0].GetItemIndex())
            {
                continue;
            }
            if (Input.GetMouseButtonDown(1))
            {
                pickUpItem.ClearImages();
                pickUpItem.itemList.Clear();
                int rnd = Random.Range(0, deliverAudioClips.Length);
                audioS.PlayOneShot(deliverAudioClips[rnd]);
                target.Destroy();
            }
            return true;
        }
        return false;
    }

    bool DoCreatePotion()
    {
        RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
        foreach (RaycastHit hit in hits)
        {
            BarTableBehaviour target = hit.transform.GetComponent<BarTableBehaviour>();
            if (target == null) continue;

            if (Input.GetMouseButtonDown(1))
            {
                GetComponent<CreatePotion>().PotionCreation(target.gameObject);
            }
            return true;
        }
        return false;
    }

    bool DoPickUpItem()
    {
        RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
        foreach (RaycastHit hit in hits)
        {
            ItemHolder target = hit.transform.GetComponent<ItemHolder>();
            if (target == null) continue;
            if (!pickUpItem.CanPickUp(target.gameObject))
            {
                continue;
            }

            if (Input.GetMouseButtonDown(1))
            {
                //anim.Play("Collect");
                GetComponent<PickUpItem>().PickUp(target.gameObject);
            }
            return true;
        }
        return false;
    }

    bool DoDeletePickedItems()
    {
        RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
        foreach (RaycastHit hit in hits)
        {
            TrashCan target = hit.transform.GetComponent<TrashCan>();
            if (target == null) continue;
            if (target.GetComponent<TrashCan>() == null)
            {
                continue;
            }

            if (Input.GetMouseButtonDown(1))
            {
                GetComponent<DeleteItems>().DeletePickedItems(target.gameObject);
            }
            return true;
        }
        return false;
    }

    bool DoMovement()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
        if (hasHit)
        {
            if (Input.GetMouseButton(1))
            {
                move.StartMoveAction(hit.point);
            }
            return true;
        }
        return false;
    }

    static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
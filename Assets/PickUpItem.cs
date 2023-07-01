using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour, IAction
{

    public List<Item> itemList;

    [SerializeField] Transform imageContainer;
    [SerializeField] Transform template;
    public List<Transform> itemSprites;

    float range = 3f;

    ItemHolder target;
    Move move;
    ActionScheduler actionScheduler;

    void Awake()
    {
        move = GetComponent<Move>();
        actionScheduler = GetComponent<ActionScheduler>();
    }

    void Update()
    {

        if (target == null) return;
        if(!GetIsInRange())
        {
            move.MoveTo(target.transform.position);
        }
        else
        {
            move.Cancel();
            PickUpBehaviour();
        }
    }

    private void PickUpBehaviour()
    {
        transform.LookAt(target.transform);
        Transform imageTransform = Instantiate(template, imageContainer);
        itemSprites.Add(imageTransform);
        Image image = imageTransform.gameObject.GetComponent<Image>();
        image.sprite = target.GetItem().GetItemSprite();
        imageTransform.gameObject.SetActive(true);
        itemList.Add(target.GetItem());
        target = null;
    }

    public void AddImage(Sprite sprite)
    {
        Transform imageTransform = Instantiate(template, imageContainer);
        itemSprites.Add(imageTransform);
        Image image = imageTransform.gameObject.GetComponent<Image>();
        image.sprite = sprite;
        imageTransform.gameObject.SetActive(true);
    }

    public void ClearImages()
    {
        foreach (Transform j in itemSprites)
        {
            Destroy(j.gameObject);
        }
        itemSprites.Clear();
    }

    public void PickUp(GameObject _target)
    {
        actionScheduler.StartAction(this);
        target = _target.GetComponent<ItemHolder>();
    }

    public void Cancel()
    {
        target = null;
    }

    private bool GetIsInRange()
    {
        return Vector3.Distance(transform.position, target.transform.position) < range;
    }

    public bool CanPickUp(GameObject target)
    {
        if(target == null)
        {
            return false;
        }
        foreach(Item i in itemList)
        {
            if(i.GetItemType() == ItemType.potion)
            {
                return false;
            }
            if(i.GetItemIndex() == target.GetComponent<ItemHolder>().GetItem().GetItemIndex())
            {
                return false;
            }
        }
        
        ItemHolder _target = target.GetComponent<ItemHolder>();
        return _target != null;
    }    
}

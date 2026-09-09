using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction Instance;
    private List<CollectibleItem> nearbyItems = new List<CollectibleItem>();

    private CollectibleItem currentItem;
    private TreeInteraction nearbyTree;
    public bool holding = false;

    [SerializeField] private Transform holdPoint;
    [SerializeField] private Transform dropPoint;

    private void OnTriggerEnter(Collider other)
    {
        CollectibleItem item = other.GetComponent<CollectibleItem>();

        if (item != null)
        {
            nearbyItems.Add(item);
        }

        TreeInteraction tree = other.GetComponent<TreeInteraction>();

        if (tree != null)
        {
            nearbyTree = tree;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CollectibleItem item = other.GetComponent<CollectibleItem>();

        if (item != null)
        {
            nearbyItems.Remove(item);
        }

        TreeInteraction tree = other.GetComponent<TreeInteraction>();

        if (tree != null)
        {
            nearbyTree = null;
        }
    }

    private CollectibleItem GetClosestItem()
    {
        if (nearbyItems.Count == 0)
            return null;

        CollectibleItem closest = nearbyItems[0];
        float closestDistance = Vector3.Distance(transform.position, closest.transform.position);

        foreach (CollectibleItem item in nearbyItems)
        {
            float distance = Vector3.Distance(transform.position, item.transform.position);

            if (distance < closestDistance)
            {
                closest = item;
                closestDistance = distance;
            }
        }

        return closest;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentItem == null)
            {
                CollectibleItem item = GetClosestItem();

                if (item != null)
                {
                    currentItem = item;

                    item.transform.SetParent(holdPoint);
                    item.transform.localPosition = Vector3.zero;
                    item.transform.localRotation = Quaternion.identity;

                    Collider col = item.GetComponent<Collider>();

                    if (col != null)
                        col.enabled = false;

                    Rigidbody rb = item.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        rb.isKinematic = true;
                        rb.useGravity = false;
                    }

                    FinishScreen.Log("Recogiste: " + item.itemType);
                    Holding();
                }
            }
            else if (nearbyTree != null)
            {
                bool placed = nearbyTree.PlaceObject(currentItem);

                if (placed)
                {
                    currentItem = null;
                    NotHolding();
                }
            }
            else
            {
                DropItem();
            }
        }
    }

    private void DropItem()
    {
        currentItem.transform.SetParent(null);

        currentItem.transform.position = dropPoint.position;

        Collider col = currentItem.GetComponent<Collider>();

        if (col != null)
            col.enabled = true;

        Rigidbody rb = currentItem.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        currentItem = null;
        NotHolding();
    }

    public bool Holding()
    {
        holding = true;
        return holding;
    }

        public bool NotHolding()
    {
        holding = false;
        return holding;
    }
}
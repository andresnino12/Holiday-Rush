using UnityEngine;

public class TreeInteraction : MonoBehaviour
{
    public static TreeInteraction Instance;

    [SerializeField] private Transform[] decorationPoints;

    private int currentDecorationIndex = 0;

    public bool PlaceObject(CollectibleItem item)
    {
        if (item.itemType != GameManager.Instance.currentTarget)
        {
            FinishScreen.Log("este no es el objeto :(");
            return false;
        }
        if (currentDecorationIndex >= decorationPoints.Length)
        {
            FinishScreen.Log("El arbol ya esta lleno");
            return false;
        }

        Transform point = decorationPoints[currentDecorationIndex];

        item.transform.SetParent(point);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        Rigidbody rb = item.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        Collider col = item.GetComponent<Collider>();

        if (col != null)
        {
            col.enabled = false;
        }

        currentDecorationIndex++;
        GameManager.Instance.ChooseNextItem();

        return true;
    }
}


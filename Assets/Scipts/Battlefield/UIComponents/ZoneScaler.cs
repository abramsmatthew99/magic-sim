using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ZoneScaler : MonoBehaviour, IDropHandler
{
    public float padding = 1f; // Distance between the objects and the zone’s edge
    private List<Transform> objectsInZone = new List<Transform>();
    private BoxCollider zoneCollider;
    private Vector3 originalScale;

    void Start()
    {
        zoneCollider = GetComponent<BoxCollider>();
        ScaleObjects();
    }

    // Function to manually scale the objects inside the zone
    public void ScaleObjects()
    {
        if (objectsInZone.Count > 0)
        {
            CalculateAndScale(objectsInZone);
        }
    }

    // Event method called when an object is dropped onto this zone
    public void OnDrop(PointerEventData eventData)
    {
        // Get the reference of the dropped object
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null)
        {
            // Add the dropped object to the zone's children and scale it
            Transform droppedObject = draggable.transform;
            droppedObject.SetParent(transform);
            objectsInZone.Add(droppedObject);
            originalScale = droppedObject.localScale;
            ScaleObjects();
        }
    }

    private void CalculateAndScale(List<Transform> objects)
    {
        // Rest of the function remains the same as before (unchanged)
        // ...
        // ...
    }
    // Update is no longer needed in this version
}
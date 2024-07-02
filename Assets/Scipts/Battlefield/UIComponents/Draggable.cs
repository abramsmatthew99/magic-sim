using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private GameObject dragRing; // To store the ring 
    private Renderer dragRingRenderer; // Access the ring's renderer for color changes

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Create the yellow ring
        Debug.Log("Begin Drag");
        dragRing = new GameObject("DragRing");
        dragRing.transform.SetParent(transform); // Make ring a child of the dragged object
        dragRing.transform.localPosition = Vector3.zero; // Center the ring
        dragRing.transform.localScale = transform.localScale; // Match the shape of the dragged object

        // Add a SpriteRenderer if you want a visual ring
        dragRingRenderer = dragRing.AddComponent<SpriteRenderer>();
        dragRingRenderer.material = new Material(Shader.Find("Sprites/Default")); 
        dragRingRenderer.material.color = Color.yellow;
        dragRingRenderer.sortingLayerName = "UI"; // Ensure ring is always visible on top
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Update the game object's position
        transform.position = eventData.position; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Destroy the drag ring
        Destroy(dragRing); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

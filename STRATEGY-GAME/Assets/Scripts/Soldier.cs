using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Soldier : MonoBehaviour
{
   
    bool onObject;
    AIDestinationSetter AIDestinationSetter;
    public SpriteRenderer cell;
    Color startColor;
    private void Start()
    {
        startColor = cell.color;
        AIDestinationSetter = transform.parent.GetComponent<AIDestinationSetter>();
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (onObject)
                MouseDownOutside();
        }
        if (AIDestinationSetter.enabled)
        {
           
            if (Input.GetMouseButtonDown(1))
            {
                Vector2 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                AIDestinationSetter.target = world;
               
               
            }
          
           
        }
    }
    private void OnMouseDown()
    {
        cell.color = Color.green;
        AIDestinationSetter.target = transform.position;
        AIDestinationSetter.enabled = true;
        
      
    }

    void OnMouseEnter()
    {
        onObject = false;
    }

    
    void OnMouseExit()
    {
        onObject = true;
    }
    void MouseDownOutside()
    {
        AIDestinationSetter.enabled = false;
        cell.color = startColor;
        AIDestinationSetter.target = transform.position;
    }
}

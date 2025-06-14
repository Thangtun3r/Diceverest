using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DiceExcutor : MonoBehaviour
{
    private Dice dice;
    public List<Dice> diceHolders;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }


    private void Update()
    {
        Select();
        Deselect();
    }

   
    private void Select()
    {
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
                
                //check if the raycast hit a collider tagged as "Dice"
                if(hit.collider != null && hit.collider.gameObject.CompareTag("Dice"))
                {
                    IDiceSelectable selectable = hit.collider.GetComponent<IDiceSelectable>();
                    Dice dice = hit.collider.GetComponent<Dice>();
                    
                    // If the selectable is not null and the dice is not already in the list, add it yeh
                    if (selectable != null && dice != null && !diceHolders.Contains(dice) && dice.CurrentState == InteractionState.Deselected);
                    {
                        diceHolders.Add(dice);
                        selectable.HandleSelection(InteractionState.Selected); // Interface call
                    }
                }
            }
        }

    }

    private void Deselect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            
            if(hit.collider != null && hit.collider.gameObject.CompareTag("Dice"))
            {
                IDiceSelectable selectable = hit.collider.GetComponent<IDiceSelectable>();
                Dice dice = hit.collider.GetComponent<Dice>();
                    
                // If the selectable is not null and the dice is not already in the list, add it yeh
                if (selectable != null && dice != null && !diceHolders.Contains(dice) && dice.CurrentState == InteractionState.Selected);
                {
                    diceHolders.Remove(dice);
                }
            }
        }
    }
}

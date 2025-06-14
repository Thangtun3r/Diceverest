using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DiceExcutor : MonoBehaviour,IExecutable
{
    public static DiceExcutor Instance { get; private set; }
    private Dice dice;
    public List<Dice> diceHolders;
    private Camera camera;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        camera = Camera.main;
    }


    private void Update()
    {
        HandleSelection();
    }

   
    private void HandleSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Dice"))
            {
                IDiceSelectable selectable = hit.collider.GetComponent<IDiceSelectable>();
                Dice dice = hit.collider.GetComponent<Dice>();

                if (selectable != null && dice != null)
                {
                    if (diceHolders.Contains(dice))
                    {
                        diceHolders.Remove(dice);
                        selectable.HandleSelection(InteractionState.Deselected);
                    }
                    else if (dice.CurrentState == InteractionState.Deselected)
                    {
                        diceHolders.Add(dice);
                        selectable.HandleSelection(InteractionState.Selected);
                    }
                }
            }
        }
    }
    
    
    public void Execute()
    {
        Debug.unityLogger.Log("DiceExcutor");
        foreach (Dice d in diceHolders)
        {
            d.RollDice();
        }
    }
}

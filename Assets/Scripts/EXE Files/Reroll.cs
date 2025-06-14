using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reroll : MonoBehaviour
{
    private void Update()
    {
        UseCard();
    }

    private void UseCard()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Card"))
            {
                DiceExcutor.Instance.Execute();
            }
        }
    }
}

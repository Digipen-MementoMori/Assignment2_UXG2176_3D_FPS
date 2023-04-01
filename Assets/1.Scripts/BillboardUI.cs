using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    public Transform Player;

    private void Update()
    {
        Billboard();
    }

    private void Billboard()
    {
        if (Player == null)
        {
            Debug.Log("Player Transform is not assigned.");
            return;
        }

        // Calculate the rotation required to make the object face the player
        Vector3 direction = (Player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(-direction, Vector3.up);

        // Apply the rotation to the object, ignoring any rotation on the X and Z axes
        transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);
    }
}
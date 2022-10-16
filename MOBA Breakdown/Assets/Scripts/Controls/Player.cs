//================================================================
// Personal Project, started in Oct. 2022
// Script by:    Daniel Heilmann
// Last changed: 09-10-22
// TODO: Rework button inputs using new Input System.
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //# Constants 

    //# Public Variables 
    public Character pilotedCharacter;

    //# Private Variables 
    private string groundTag = "Ground";

    //# Monobehaviour Events 
    private void Awake()
    {
        if (pilotedCharacter == null)
            Debug.Log($"Player \"{this}\" does not have a character assigned to it.", this);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.CompareTag(groundTag))
                {
                    Vector3 location = hit.point;
                    //Debug.Log($"Raycast hit ground at {location}.");
                    pilotedCharacter.MoveTo(location);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.CompareTag(groundTag))
                {
                    Vector3 location = hit.point;
                    //Debug.Log($"Raycast hit ground at {location}.");
                    pilotedCharacter.PlaceAbility(location);
                }
            }
        }
    }

    //# Public Methods 

    //# Private Methods 

    //# Input Event Handlers 
}

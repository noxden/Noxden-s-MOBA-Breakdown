//================================================================
// Personal Project, started in Oct. 2022
// Script by:    Daniel Heilmann
// Last changed: 09-10-22
// TODO: Change scroll speed based on how close the cursor is to the edge.
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //# Constants 
    private const int scrollBorderWidth = 100;
    private const int scrollSpeed = 10;

    //# Public Variables 

    //# Private Variables 
    [SerializeField] private Vector2 screenDimensions;
    [SerializeField] private Vector2 mousePosition;

    //# Monobehaviour Events 
    private void Update()
    {
        if (screenDimensions != GetScreenDimensions())
        {
            screenDimensions = GetScreenDimensions();
            //Debug.Log(screenDimensions);
        }

        mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (GetScreenScrollDirection() != Vector2.zero)
        {
            Vector2 screenScrollDirection = GetScreenScrollDirection();
            Vector3 worldScrollDirection = new Vector3(screenScrollDirection.x, 0, screenScrollDirection.y);
            Vector3 worldScrollTranslation = worldScrollDirection * scrollSpeed * Time.deltaTime;
            transform.Translate(worldScrollTranslation, Space.World);
            //Debug.Log($"Camera movement direction: {worldScrollTranslation}");
        }
    }

    //# Public Methods 

    //# Private Methods 
    private Vector2 GetScreenDimensions()
    {
        return new Vector2(Screen.width, Screen.height);
    }

    private Vector2 GetScreenScrollDirection()
    {
        //> Prevent scrolling when outside window and exit out of this function
        if (mousePosition.x < 0 || mousePosition.x > screenDimensions.x || mousePosition.y < 0 || mousePosition.y > screenDimensions.y)
            return Vector2.zero;

        Vector2 returnVector = Vector2.zero;    //< Default is no movement (when in center of screen)

        if (mousePosition.x < 0 + scrollBorderWidth)
            returnVector += Vector2.left;
        else if (mousePosition.x > screenDimensions.x - scrollBorderWidth)
            returnVector += Vector2.right;

        if (mousePosition.y < 0 + scrollBorderWidth)
            returnVector += Vector2.down;
        else if (mousePosition.y > screenDimensions.y - scrollBorderWidth)
            returnVector += Vector2.up;

        return returnVector.normalized;
    }


    //# Input Event Handlers 
}

//================================================================
// Personal Project, started in Oct. 2022
// Script by:    Daniel Heilmann
// Last changed: 09-10-22
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Character : MonoBehaviour
{
    //# Constants 

    //# Public Variables 
    public int maxHP;
    public int currentHP;

    //# Private Variables 
    private NavMeshAgent agent;

    //# Monobehaviour Events 
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    //# Public Methods 
    public void MoveTo(Vector3 location)
    {
        agent.SetDestination(location);

        //> Checking if location can be reached or destination needed to be altered.
        if (agent.destination.x == location.x && agent.destination.z == location.z) //< As for some reason, the NavMeshAgent pushes the Character up by 0.8, causing destination never to equal location.
            Debug.Log($"{this.name} will now move towards {agent.destination}.");
        else
            Debug.Log($"{this.name} cannot find path towards {location}, moving to {agent.destination} instead.");

        //> Visualization
        NavMeshPath path = agent.path;
        for (int i = 0; i < path.corners.Length - 1; i++)
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red, 2);
    }

    public void PlaceAbility(Vector3 location)
    {
        GameObject ability = new GameObject("Ability");
        AOEAbility abilityScript = ability.AddComponent(typeof(AOEAbility)) as AOEAbility;
        abilityScript.size = 5;
        abilityScript.duration = 10;
        abilityScript.location = new Vector2(location.x, location.z);
    }

    public void Update()
    {
        float res = (float)currentHP/maxHP;
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = new Color(1, res,res, 1);
    }

    //# Private Methods 

    //# Input Event Handlers 
}

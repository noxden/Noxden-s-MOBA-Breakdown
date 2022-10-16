using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEAbility : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("collide");
        if(other.transform.parent != null) 
        {
            IEnumerator coroutine = DealDamage(other.transform.parent.GetComponent<Character>() as Character);
            StartCoroutine(coroutine);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.transform.parent != null) 
        {
            StopCoroutine("DealDamage");
        }
    }

    IEnumerator DealDamage(Character character)
    {
        while (true)
        {
            character.currentHP -= 100;
            yield return new WaitForSeconds(1);
        }

    }
}

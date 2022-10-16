using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEAbility : MonoBehaviour
{
    
    public float size;
    public float duration;
    public Vector2 location;
    
    private GameObject indicator;

    // Start is called before the first frame update
    void Start()
    {
        indicator = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        indicator.transform.parent = transform;
        indicator.name = "indicator";
        Destroy(indicator.GetComponent<CapsuleCollider>());

        gameObject.transform.position = new Vector3(location.x, 0.01f, location.y);
        gameObject.transform.localScale = new Vector3(size, 0.01f, size);

        CapsuleCollider coll = gameObject.AddComponent<CapsuleCollider>();
        coll.isTrigger = true;
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = new Color(255, 0, 0, 255);
        indicator.GetComponent<MeshRenderer>().material = mat;

        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter(Collider other) 
    {
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
            character.currentHP -= 30;
            yield return new WaitForSeconds(1.0f/3);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{

    public float size;
    public float duration;
    public Vector2 location;
    
    private GameObject indicator;

    // Start is called before the first frame update
    void Start()
    {
        indicator = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        indicator.name = "indicator";

        indicator.AddComponent<AOEAbility>();
        indicator.GetComponent<CapsuleCollider>().isTrigger = true;
        indicator.transform.position = new Vector3(location.x, 0.01f, location.y);
        indicator.transform.localScale = new Vector3(size, 0.01f, size);
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = new Color(255, 0, 0, 255);
        indicator.GetComponent<MeshRenderer>().material = mat;

        Destroy(indicator, 2);
        Destroy(this, 2);
    }
}

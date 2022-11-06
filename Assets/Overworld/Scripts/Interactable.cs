using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    /*
 * Zum Szenenwechsel
 * Dieses Script anhängen und Interactable.cs anhängen
 * Interactable: Als Material Glow auswählen evtl. Größe einstellen
 * SceneChanger: passenden Index auswählen
 */ 


    private GameObject copy;
    public Material color;
    public bool isHighlight;
    public float thickness = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        isHighlight = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Pointer"))
        {
            //Debug.Log("Hallo :)");
            isHighlight = true;
            copy = Instantiate(this.gameObject, transform.parent);
            Destroy(copy.GetComponent<Rigidbody>());
            Destroy(copy.GetComponent<BoxCollider>());
            Destroy(copy.GetComponent<SphereCollider>());
            Destroy(copy.GetComponent<MeshCollider>());
            Destroy(copy.GetComponent<LODGroup>());
            copy.transform.localScale = new Vector3(transform.localScale.x + thickness, transform.localScale.y + thickness, transform.localScale.z + thickness);
            copy.GetComponent<MeshRenderer>().material = color;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Pointer"))
        {
            Destroy(copy);
            isHighlight = false;
            //Debug.Log("Tschüss :(");
        }
    }
}

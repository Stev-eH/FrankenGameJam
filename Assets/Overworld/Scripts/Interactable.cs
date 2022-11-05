using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private GameObject copy;
    private GameObject glow;
    public Material color;
    public bool isHighlight;

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
            copy = Instantiate(this.gameObject);
            Destroy(copy.GetComponent<Rigidbody>());
            Destroy(copy.GetComponent<BoxCollider>());
            Destroy(copy.GetComponent<SphereCollider>());
            copy.transform.localScale = new Vector3(transform.localScale.x + 0.2f, transform.localScale.y + 0.2f, transform.localScale.z + 0.2f);
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

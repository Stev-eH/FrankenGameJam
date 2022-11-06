using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlacer : MonoBehaviour
{
    [SerializeField]
    private Transform lightPrefab = null;

    [SerializeField]
    private Transform lightHolder = null;


    private bool[,] visited;
    private int width = 0;
    private int height = 0;

    // Update is called once per frame
    void Update()
    {
        visited ??= new bool[width, height];

        if(visited != null)
        {
            int z = (int)Mathf.Round(transform.position.z);
            int x = (int)Mathf.Round(transform.position.x);


            if (visited[x +width/2, z+height/2] == false)
            {
                visited[x + width / 2, z + height / 2] = true;
                var light = Instantiate(lightPrefab, transform);
                light.SetParent(lightHolder);
                light.position = new Vector3(x,0.5f, z);    
            }
        }
    }

    public void setSize(int widthS, int heightS)
    {
        width = widthS;
        height = heightS;
    }
}

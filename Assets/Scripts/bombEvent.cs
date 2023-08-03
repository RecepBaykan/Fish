using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float y = 2f *Camera.main.orthographicSize;
        float x = 2f * Camera.main.orthographicSize * Camera.main.aspect;
        GameObject a = new GameObject("deneme objesi");
        a.transform.position = new Vector2(- ((x/2) + 1), -(y/2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

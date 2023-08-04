using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balik : MonoBehaviour
{
    [SerializeField] private GameObject bubble;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x>3)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        bubble.transform.position = transform.position;
        GameObject bubbleClone = Instantiate(bubble);
        //bubbleClone.transform.position = transform.position;
        Destroy(gameObject);
        

}

   
}



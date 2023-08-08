using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class special : MonoBehaviour
{
    [SerializeField] private int hit;
    [SerializeField] private GameObject bubble;
    [SerializeField] private GameObject bubbleClone;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x >3)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnMouseDown() {
        
        bubbleClone = Instantiate(bubble);
       

        if(hit <=0)
        {
            bubbleClone.transform.position = transform.position;
            Destroy(gameObject);

        }else
        {
            bubbleClone.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit--;
        }
    }
}

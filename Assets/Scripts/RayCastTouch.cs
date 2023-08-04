using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTouch : MonoBehaviour
{
    // Algılmama ve dokunma ile ilgili değişkenler
    RaycastHit2D hit;
    Vector2 touchP;
    
    // Dokunulan nesnenin özelliklerini alma;
    string color;
    string point;
    
    

    // Baloncuk prefab
    [SerializeField] private GameObject bubble;
    GameObject bubbleClone;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(fishCreate.play && !fishCreate.bombaGeliyor)
        {
            raycast();
        }
        
    }


    

    void raycast()
    {
        if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) ||  Input.GetMouseButtonDown(0))
        {
            touchP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(touchP, Vector2.zero);
            
            if(hit.collider != null)
            {
                
                //color = hit.collider.gameObject.transform.GetChild(0).name;
                //point = hit.collider.gameObject.transform.GetChild(1).name;

                //Destroy(hit.collider.gameObject);
                //deleteObject(hit.collider.gameObject.transform.GetChild(0).gameObject, (Vector2) hit.collider.gameObject.transform.position);
                
                
            }


        }
    }


   

    
    
    
    
    void earnScore(string point)
    {

    }

    
    
    void deleteObject(GameObject go, Vector2 vect)
    {
        Destroy(go);
        GameObject bubbleClonee = Instantiate(bubble);
        bubbleClonee.transform.position = vect;
                
    }
}

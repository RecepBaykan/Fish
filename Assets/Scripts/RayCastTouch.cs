using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RayCastTouch : MonoBehaviour
{
    // Algılmama ve dokunma ile ilgili değişkenler
    RaycastHit2D hit;
    Vector2 touchP;

    // TextMesh Score
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private GameObject textScore;
    
    // Dokunulan nesnenin özelliklerini alma;
    string color;
    string point;
    
    

    // Baloncuk prefab
    [SerializeField] private GameObject bubble;
    


    void Start()
    {
        
    }

    
    void Update()
    {
        if(fishCreate.play)
        {
            raycast();
        }
        
    }


    

    void raycast()
    {
        
        
        
        if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            touchP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(touchP, Vector2.zero);
            
            if(hit.collider != null)
            {
                
                color = hit.collider.gameObject.transform.GetChild(0).name;
                point = hit.collider.gameObject.transform.GetChild(1).name;
                Vector2 vect = hit.collider.gameObject.transform.position;
                //earnScore(point, vect);

                
                
            }


        }
    }


   

    
    
    
    
    void earnScore(string point, Vector2 vect)
    {
        
            
    }

    
    
 
}

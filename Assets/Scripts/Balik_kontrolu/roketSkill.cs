using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roketSkill : MonoBehaviour
{

    public static bool roketGeliyor;
    [SerializeField] private float hiz;
    GameObject roket;
    GameObject konum;
    [SerializeField] private GameObject boom;

    private void Start() 
    {
        
        roket = transform.GetChild(0).gameObject;
        konum = transform.GetChild(1).gameObject;
        fishCreate.play = false;
       //roketGeliyor = true;
        

    }
    
    void Update()
    {

         if(roket.transform.position != konum.transform.position)
        {
           
            if(Vector2.Distance(roket.transform.position, konum.transform.position) <0.3f)
            {
                roket.transform.position = konum.transform.position;
            }else
            {
                roket.transform.position = Vector2.Lerp(roket.transform.position, konum.transform.position, hiz*Time.deltaTime);
                
            }
            
        }else
        {
            if(gameObject.transform.childCount != 3)
            {
                roketGeliyor = true;
                GameObject boomClone = Instantiate(boom);
                boomClone.transform.position = roket.transform.position;
                boomClone.transform.localScale = new Vector2(2f,2f);
                boomClone.transform.parent = gameObject.transform;
            
                fishCreate.play = true;
                roket.SetActive(false);
                StartCoroutine(Shake(0.5f, 0.1f));
            
            this.Wait(1f, () =>
            {
                roketGeliyor = false;
                Destroy(gameObject);
                
            });
            }
            

            
        }
       
        
    }



    float x, y;
    
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = Camera.main.transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            x = Random.Range(-1f, 1f) * magnitude;
            y = Random.Range(-1f, 1f) * magnitude;

        Camera.main.transform.localPosition = new Vector3(x, y, originalPosition.z);

        elapsed += Time.deltaTime;

        yield return null;
        }  

        Camera.main.transform.localPosition = originalPosition;
    }




    
}

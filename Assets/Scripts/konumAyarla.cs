using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class konumAyarla : MonoBehaviour
{



  /*  float x;
    float y;

    // Baloncukların yolu
    [SerializeField] private GameObject p1;
    [SerializeField] private GameObject p2;
    [SerializeField] private GameObject p3;
    [SerializeField] private GameObject p4;
    [SerializeField] private GameObject p5;
    [SerializeField] private GameObject p6;

    [SerializeField] private GameObject sp1;
    [SerializeField] private GameObject sp2;
    [SerializeField] private GameObject sp3;
    [SerializeField] private GameObject sp4;
    [SerializeField] private GameObject sp5;
    [SerializeField] private GameObject sp6;*/


    /*public float targetWidth = 5f; // Hedef genişlik (örn. 9:16 için 5)
    public float targetAspectRatio = 9f / 16f; // Hedef aspect ratio (örn. 9:16)

    // Start is called before the first frame update
    void Start()
    {
        
        
       
        float currentAspectRatio = (float)Screen.width / Screen.height;

        // Aspect ratio dönüşüm oranını hesapla
        float conversionRatio = currentAspectRatio / targetAspectRatio;

        // Kameranın genişliğini ayarla
        Camera.main.orthographicSize = targetWidth / conversionRatio;
        

        /*
        y = 2f*Camera.main.orthographicSize;
        x = 2f*Camera.main.orthographicSize*Camera.main.aspect;
        konum();
        foreach (Transform child in transform)
        {
            // Nesnenin orijinal boyutunu al
            Vector2 originalScale = child.localScale;

            // Nesnenin boyutlarını uygun şekilde ölçekle
            child.localScale = new Vector2(originalScale.x * conversionRatio, originalScale.y);
        }
    }*/
    /*public float targetWidth = 5f; // Hedef genişlik (örn. 9:16 için 5)
    public float targetHeight = 9f; // Hedef yükseklik (örn. 9:16 için 9)

    void Start()
    {
        // Cihazın aspect ratio'sunu hesapla
        float currentAspectRatio = (float)Screen.width / Screen.height;

        // Yatay ve dikey oranları hesapla
        float horizontalRatio = currentAspectRatio / (16f / 9f);
        float verticalRatio = currentAspectRatio / (9f / 16f);

        foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
        {   
            if (currentAspectRatio >= 1f) // Yatay ekranlar için
            {
                
                obj.transform.localScale = new Vector2(obj.transform.localScale.x/verticalRatio, 
                obj.transform.localScale.y/horizontalRatio);
            }
            else // Dikey ekranlar için
            {
                //obj.transform.localScale = new Vector2(obj.transform.localScale.x*horizontalRatio, obj.transform.localScale.y/verticalRatio);
            }

        }
        
        
    }*/

    

    void Start()
    {
        
        Camera.main.orthographicSize = 5f;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void konum()
    {
       /* //path1 path2
        GameObject[] path1 = GameObject.FindGameObjectsWithTag("path1");
        GameObject[] path2 = GameObject.FindGameObjectsWithTag("path2");
        for(int i = 0; i<path1.Length; i++)
        {
            path1[i].transform.position = new Vector2( -1f *((x/2) +1), 
            path1[i].transform.position.y);
            path2[i].transform.position = new Vector2( ((x/2) + 1), 
            path2[i].transform.position.y);
        }


        //baloncuklar
        GameObject[] balonpaths = new GameObject[6];*/
        }
}

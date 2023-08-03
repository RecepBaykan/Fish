using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fishCreate : MonoBehaviour
{
    [SerializeField] private GameObject fishParent;
    [SerializeField] private List<string> fishesName;
    [SerializeField] private List<string> fishesScore;
    
    [SerializeField] public static bool bombaGeliyor;

    [SerializeField] GameObject[] pathA;
    [SerializeField] GameObject[] pathB;
    

    string path1;
    string path2;
    
    [SerializeField] private float[] moveSpeed;

    [SerializeField] private float negatifX;
    [SerializeField] private float positifX;


    [SerializeField] private bool[] pathLock;
    [SerializeField] public static int pathLockCount;
    [SerializeField] private GameObject[] fishes;
    [SerializeField] private GameObject[] lastPath;

    public static bool setFish;

    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private GameObject textScore;
    Animation scoreAnim;
    
    public static bool play;

    [SerializeField] private GameObject bubble;

    [SerializeField] private GameObject exp;
   




    
    
    void Start()
    {
        play = false;
        pathLockCount =4;
        set();



        fishesName = new List<string>();
        for(int i = 0; i<fishParent.transform.childCount;i++){
            fishesName.Add(fishParent.transform.GetChild(i).name);
        }

       

        



       path1 = "path1";
       path2 = "path2";

    }

    // Update is called once per frame
    void Update()
    {

        if(int.Parse(Score.text)>= eventClass.hedefScore)
        {
            Score.color = Color.green;
        }else
        {
             Score.color = Color.red;
        }
        fishSpam();
        
        // Her 5 seviyede bir bomba gelir
        if(!bombaGeliyor)
        { 
        
            move();
        }else
        {
            if(setFish)
            {
                // Tüm balıkları yok eder.
                for(int i = 0; i<pathLock.Length; i++)
                {
                    if(pathLock[i])
                    {
                       
                        GameObject bubbleClone = Instantiate(bubble);
                        bubbleClone.transform.position = fishes[i].transform.position; 
                        scoreAdd(fishes[i], bubbleClone);
                        pathLock[i] = delete(fishes[i]);
                        
                    }
                    
                }

                pathLockCount+=3;

                // Yeniden balık sayısını ayarlar
                set();
                setFish = false;
                bombaGeliyor = false;
                eventClass.BombaGeldi = true;
                eventClass.seviyeAtla = true;
                
            
            }
           
           
        }
        
        
        if(play && !bombaGeliyor)
        {
            touch();
        }
        
       



    }

    void set()
    {
        
        pathLock = new bool[pathLockCount];
        fishes = new GameObject[pathLock.Length];
        lastPath = new GameObject[pathLock.Length];
        moveSpeed = new float[pathLock.Length];
    }

    void fishSpam(){
        
        
        for (int i = 0; i < pathLock.Length; i++)
        {
            if(!pathLock[i]){
                path();
                moveSpeed[i] = Random.Range(0.01f, eventClass.level*0.2f*Time.deltaTime);
                //Rastgele balık oluşturuluyor
                int a = 0;
                // Not: Switch Case
                if(eventClass.level <6)
                {
                    a = Random.Range(0, 3);
                }else
                {
                    if(eventClass.level<11)
                    {
                        a = Random.Range(0, 6);
                    }else
                    {
                        int sans = Random.Range(0, 11);
                        if(sans == 1)
                        {
                            a = Random.Range(8, 12);
                        }else
                        {
                            a = Random.Range(0, 8);
                        }
                    }
                }
                
                string UniqueID = System.Guid.NewGuid().ToString();
                fishes[i] = Instantiate(fishParent.transform.GetChild(a).gameObject);

                fishes[i].name = fishParent.transform.GetChild(a).name;
                

                  // Oluşturulan balık eşsiz yapılıyor,  özelliği ve puanını ekleniyor.
                GameObject color = new GameObject(fishes[i].name);
                GameObject score = new GameObject(earnFishScore(fishes[i].name, i));
                
                
                score.transform.parent = fishes[i].transform;
                color.transform.parent = fishes[i].transform;

                fishes[i].name = System.Guid.NewGuid().ToString();


               
                
               
                
              
                
                a = Random.Range(0,4);
                
                
                fishes[i].transform.position = new Vector2(pathA[a].transform.position.x,pathA[a].transform.position.y );
                a = Random.Range(0,4);

                 // Balığı Döndürme 
                if(fishes[i].transform.position.x > 0){

                    fishes[i].transform.GetComponent<SpriteRenderer>().flipX = true;
                }
               

                 
                lastPath[i] = pathB[a];

               
                
                pathLock[i] = true;

                

                


            }
        }
        
        
        



    }

    string fishScore;
    string earnFishScore(string s, int i)
    {
        
        foreach (var fish in fishesName)
        {
            if(fish == s)
            {
                fishScore = (Mathf.Round((moveSpeed[i] * 1500 + 8*eventClass.level))).ToString();
                break;
            }else{
                
            }
        }

        return fishScore;
        
    }

    void path(){
        
        

        if(Random.Range(2, 11) % 2 == 0){
            pathA = GameObject.FindGameObjectsWithTag(path1);
            pathB = GameObject.FindGameObjectsWithTag(path2);
        }else{
            pathA = GameObject.FindGameObjectsWithTag(path2);
            pathB = GameObject.FindGameObjectsWithTag(path1);
        }
    }


    /*void move(){

        if(pathLock[0]){
            
            if(distance( fishes[0].transform.position, lastPath[0].transform.position) || fishes[0] == null)
            {
               pathLock[0] = delete(fishes[0]);
            }else{
                fishes[0].transform.position = Vector2.Lerp(fishes[0].transform.position, lastPath[0].transform.position, Time.deltaTime * moveSpeed[0]);
            
            }


        }
        if(pathLock[1] ||  fishes[1] == null){
            
        
            if(distance( fishes[1].transform.position, lastPath[1].transform.position))
            {
               pathLock[1] = delete(fishes[1]);
            }else{
                fishes[1].transform.position  = Vector2.Lerp(fishes[1].transform.position,lastPath[1].transform.position, Time.deltaTime * moveSpeed[1]);
            }

        }
        if(pathLock[2] ||  fishes[2] == null){
            fishes[2].transform.position  = Vector2.Lerp(fishes[2].transform.position,lastPath[2].transform.position, Time.deltaTime *moveSpeed[2]);
              if(distance( fishes[2].transform.position, lastPath[2].transform.position))
            {
             pathLock[2] =  pathLock[2] = delete(fishes[2]);
            }else{
                  fishes[2].transform.position  = Vector2.Lerp(fishes[2].transform.position,lastPath[2].transform.position, Time.deltaTime *moveSpeed[2]);
            }
        }
        if(pathLock[3] ||  fishes[3] == null){
            
            if(distance( fishes[3].transform.position, lastPath[3].transform.position))
            {
              pathLock[3] =  delete(fishes[3]);
            } else{
                fishes[3].transform.position  = Vector2.Lerp(fishes[3].transform.position, lastPath[3].transform.position, Time.deltaTime * moveSpeed[3]);
            }
        }

    }*/

    void move()
    {
        for(int i = 0; i<pathLock.Length; i++)
        {
              if(pathLock[i]){
            
            if(distance( fishes[i].transform.position, lastPath[i].transform.position) || fishes[i] == null)
            {
               pathLock[i] = delete(fishes[i]);
            }else{
                fishes[i].transform.position = Vector2.MoveTowards(fishes[i].transform.position, lastPath[i].transform.position, moveSpeed[i]);
                //fishes[i].transform.Translate(lastPath[i].transform.position* Time.deltaTime * moveSpeed[i]);
            }


        }
        }
    }

    bool distance(Vector2 a, Vector2 b){

        if(Vector2.Distance(a, b)<2f){
            b = a;
            return true;
        }else{
            return false;
        }
    
    }

    bool delete(GameObject a){
        
        Destroy(a);

        return false;

    }




    RaycastHit2D hit;
    Vector2 mouseP;

    void touch()
    {
        if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) ||  Input.GetMouseButtonDown(0))
        {
            
            mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mouseP, Vector2.zero);
           
            if(hit.collider !=null){
                int a = 0;
                for(int i = 0; i<pathLock.Length;i++)
                {
                    if(hit.collider.gameObject.name == fishes[i].name)
                    {

                        pathLock[i] = false;
                        
                        a = i;
                        
                        break;
                    }
                }
                
                string name = hit.collider.gameObject.transform.GetChild(1).gameObject.name;
                switch (name)
                {
                    case "timeBoost":
                        touchTime.timeBoost = true;
                        patlat();
                        break;

                    case "timeDown":
                        touchTime.timeBoost = false;
                        patlat();
                        break;

                    case "bomb":
                    eventClass.GameOver = true;
                            GameObject ex = Instantiate(exp);
                            ex.transform.position = hit.collider.gameObject.transform.position;
                            Destroy(hit.collider.gameObject);
                            
                        break;
                    
                    case "points":
                        hit.collider.gameObject.transform.GetChild(0).gameObject.name = (int.Parse(hit.collider.gameObject.transform.GetChild(0).gameObject.name) + 100).ToString();
                        patlat();
                        break;

                    case "baloon":
                        

                    default: 
                        patlat();
                        break;   

                }
               
                
               
                
            }

        
        }
        

    }


    void patlat()
    {
          //Dokununca Skor puanını gösterir
            GameObject bubbleClone = Instantiate(bubble);
            bubbleClone.transform.position = hit.collider.gameObject.transform.position; 
            //bubbleClone.GetComponent<ParticleSystem>().startColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); 
                
               
            scoreAdd(hit.collider.gameObject, bubbleClone);

            Destroy(hit.collider.gameObject);
    }

    Vector2 objVector;
    void scoreAdd(GameObject obj, GameObject bubble){
               
            Score.text = (int.Parse(Score.text) + 
            int.Parse(obj.transform.GetChild(0).name)).ToString();
          
            GameObject go = Instantiate(textScore);
            go.transform.GetChild(0).GetComponent<TextMeshPro>().text = int.Parse(obj.transform.GetChild(0).name).ToString();
            go.transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y - 1f);
            objVector = new Vector2(go.transform.position.x, go.transform.position.y - 1.5f);
            StartCoroutine(scoreDestroy(go, objVector, bubble));

    }


    IEnumerator scoreDestroy(GameObject obj, Vector2 vec, GameObject bubble)
    {
       
       
        

        yield return new WaitForSeconds(0.8f);
        Destroy(obj);
        


    }


    
    


    
}

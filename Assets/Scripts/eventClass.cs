using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class eventClass : MonoBehaviour 
{
    public static bool GameOver;
    public static bool seviyeAtla;
    
    [SerializeField] private GameObject highScore;
    [SerializeField] private GameObject highScoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private TextMeshProUGUI playButtonText;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject restartButton;
 

    [SerializeField] private GameObject score;
    

    [SerializeField] private GameObject time;


    [SerializeField] private  GameObject gameOver;
    [SerializeField] private  TextMeshProUGUI gameOverScore;
    [SerializeField] private  TextMeshProUGUI lastestScore;


    [SerializeField] private GameObject seviyeYazisi;
    [SerializeField] private TextMeshProUGUI seviyeSayisi;
    [SerializeField] public static int level;

    [SerializeField] private GameObject hedefScoreObject;
    [SerializeField] private TextMeshProUGUI hedefScoreYazisi;
    [SerializeField] public static int hedefScore = 100;
    bool seviyeGosterildi;
    

    

    
    void Start()
    {
        
        GameOver = false;
        gameOver.SetActive(false);
        level = 1;
        hedefScoreYazisi.text = $"{hedefScore}";
      
        
        
    }


   
    void Update()
    {

            
        
            if(seviyeAtla)
            {   
           
                fishCreate.play = false;
                seviyeAtla = false;
                touchTime.sureOlc = true;
                time.SetActive(false);
                level ++; 
                
                hedefScore = (int)(hedefScore);
                hedefScoreYazisi.text = $"{hedefScore}";
                seviyeSayisi.text = level.ToString();
                seviyeGoster();
            
           
            }else{
                
            }
        


        
        
        if(GameOver)
        {
            touchTime.durdur = true;
            touchTime.sureOlc = true;
            gameOver.SetActive(true);
            gameOverScore.text = lastestScore.text;
            fishCreate.play = false;
            if(PlayerPrefs.GetString("high") == "")
            {
                PlayerPrefs.SetString("high", lastestScore.text);
            }else
            {
                if(int.Parse(PlayerPrefs.GetString("high"))<int.Parse(lastestScore.text))
                {
                    PlayerPrefs.SetString("high", lastestScore.text);
                }
            }
            highScore.SetActive(true);
            
            
        }

        
    }


    

    
    
    public void play()
    {
       
        
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        

        hedefScoreObject.SetActive(true);
        highScore.SetActive(false);
        //fishCreate.play = true;
        if(!seviyeGosterildi)
        {
            seviyeGoster();
        }else
        {
            fishCreate.play = true; 
        }
        seviyeGosterildi = true;


        playButton.SetActive(false);
        pauseButton.SetActive(true);
        restartButton.SetActive(true);
        score.SetActive(true);
        touchTime.durdur = false;
        
     
        
       
       
        

        

    }

    public void pause()
    {
        Time.timeScale = 0;
        touchTime.durdur = true;
        playButton.SetActive(true);

        fishCreate.play = false;
        pauseButton.SetActive(false);
        restartButton.SetActive(false);

        


        
       
        
    }

    public void restart()
    {
        seviyeGosterildi = false;
        SceneManager.LoadScene("game", LoadSceneMode.Single);
       
       
    }



    void seviyeGoster()
    {
        seviyeYazisi.SetActive(true);    
        
        
        this.Wait(1.8f, () =>
        {
           fishCreate.play = true;
           seviyeYazisi.SetActive(false);
           touchTime.sureOlc = false;
           time.SetActive(true);


        });

    }


    [SerializeField] private GameObject bombaObj;
    [SerializeField] private GameObject bombaYazisi;
    [SerializeField] private GameObject konum;
    [SerializeField] private Vector2 konumTemp;
    [SerializeField] private GameObject patlama;
    


    


}

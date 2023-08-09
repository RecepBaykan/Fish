using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using GoogleMobileAds;


public class eventClass : MonoBehaviour 
{
    public static bool GameOver;
    public static bool seviyeAtla;

    public static bool DragAndDrop;
    
    [SerializeField] private GameObject highScore;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private TextMeshProUGUI playButtonText;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject restartButton;

    [SerializeField] private GameObject adsPlayButton;
 

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


    public static int fishing;
    

    

    
    void Start()
    {
        

        if(PlayerPrefs.GetString("high") == null)
        {
            highScoreText.text = "0";
            
        }else
        {
            highScoreText.text = PlayerPrefs.GetString("high");
        }

        fishing = 0;
        LoadInterstitialAd();
        LoadRewardedAd();
        GameOver = false;
        gameOver.SetActive(false);
        level = 1;
        hedefScoreYazisi.text = $"{hedefScore}";
      
        
        
    }


    public void adsButton()
    {
        //ShowAd();
        ShowAd();
        RegisterEventHandlers(interstitialAd);
        
     // yeni reklamı yeniden yükle
       
        


        
       
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
                
                hedefScore = (int)(hedefScore + hedefScore*0.6);
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
            restartButton.SetActive(false);
            pauseButton.SetActive(false);
            gameOverScore.text = lastestScore.text;
            fishCreate.play = false;
            if(PlayerPrefs.GetString("high") == null)
            {
                PlayerPrefs.SetString("high", lastestScore.text);
            }else
            {
                if(int.Parse(PlayerPrefs.GetString("high"))<int.Parse(lastestScore.text))
                {
                    PlayerPrefs.SetString("high", lastestScore.text);
                    highScoreText.text =  PlayerPrefs.GetString("high");
                }
            }
            highScore.SetActive(true);

            
            if(interstitialAd.CanShowAd())
            {
                adsPlayButton.SetActive(true);
            }else
            {
                adsPlayButton.SetActive(false);
            }
           
           
            
            
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
        fishCreate.play = true;
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
        touchTime.sureOlc = false;
        
     
        
       
       
        

        

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


    private InterstitialAd interstitialAd;
     private string _adUnitId = "ca-app-pub-3940256099942544/5224354917";


   

     public void LoadInterstitialAd()
  {
      // Clean up the old ad before loading a new one.
      if (interstitialAd != null)
      {
            interstitialAd.Destroy();
            interstitialAd = null;
      }

      Debug.Log("Loading the interstitial ad.");

      // create our request used to load the ad.
      var adRequest = new AdRequest();
      adRequest.Keywords.Add("unity-admob-sample");

      // send the request to load the ad.
      InterstitialAd.Load(_adUnitId, adRequest,
          (InterstitialAd ad, LoadAdError error) =>
          {
              // if error is not null, the load request failed.
              if (error != null || ad == null)
              {
                  Debug.LogError("interstitial ad failed to load an ad " +
                                 "with error : " + error);
                  return;
              }

              Debug.Log("Interstitial ad loaded with response : "
                        + ad.GetResponseInfo());

              interstitialAd = ad;
          });
  }

    public static bool showAds;
    public void ShowAd()
    {
    if (interstitialAd != null && interstitialAd.CanShowAd())
    {
        
        Debug.Log("Showing interstitial ad.");
        interstitialAd.Show();
        
    
        
    }
    else
    {
        
        Debug.LogError("Interstitial ad is not ready yet.");
        showAds = false;
        
    }
}




    /*[SerializeField] private GameObject bombaObj;
    [SerializeField] private GameObject bombaYazisi;
    [SerializeField] private GameObject konum;
    [SerializeField] private Vector2 konumTemp;
    [SerializeField] private GameObject patlama;*/

    private RewardedAd rewardedAd;


  public void LoadRewardedAd()
  {
      // Clean up the old ad before loading a new one.
      if (rewardedAd != null)
      {
            rewardedAd.Destroy();
            rewardedAd = null;
      }

      Debug.Log("Loading the rewarded ad.");

      // create our request used to load the ad.
      var adRequest = new AdRequest();
      adRequest.Keywords.Add("unity-admob-sample");

      // send the request to load the ad.
      RewardedAd.Load(_adUnitId, adRequest,
          (RewardedAd ad, LoadAdError error) =>
          {
              // if error is not null, the load request failed.
              if (error != null || ad == null)
              {
                  Debug.LogError("Rewarded ad failed to load an ad " +
                                 "with error : " + error);
                  return;
              }

              Debug.Log("Rewarded ad loaded with response : "
                        + ad.GetResponseInfo());

              rewardedAd = ad;
          });
  }
    

    private void RegisterEventHandlers(InterstitialAd ad)
    {
    
    // Raised when the ad closed full screen content.
    ad.OnAdFullScreenContentClosed += () =>
    {
        interstitialAd.Destroy();
        LoadInterstitialAd();
        GameOver = false;
        gameOver.SetActive(false);
        pause();
    };
    
}

public void ShowRewardedAd()
{
    const string rewardMsg =
        "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

    if (rewardedAd != null && rewardedAd.CanShowAd())
    {
        rewardedAd.Show((Reward reward) =>
        {
            // TODO: Reward the user.
            //Debug.Log(string.Format(rewardMsg, reward.Type, reward.Amount));
        });
    }
}
   
    


}

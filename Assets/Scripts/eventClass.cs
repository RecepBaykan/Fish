using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class eventClass : MonoBehaviour 
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private TextMeshProUGUI playButtonText;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject restartButton;

    
    public void play()
    {
        fishCreate.play = true;
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        restartButton.SetActive(true);
        

    }

    public void pause()
    {
    
        playButtonText.text = "resume";
         playButton.SetActive(true);

         fishCreate.play = false;
         pauseButton.SetActive(false);
         restartButton.SetActive(false);
        


        
    }

    public void restart()
    {
         SceneManager.LoadScene("game", LoadSceneMode.Single);
       
    }


}

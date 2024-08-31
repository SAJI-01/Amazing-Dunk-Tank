using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Button ballButton;
    public Button balloonButton;
    public Button plankButton;
    public Button forceReleaserButton;
    public Button playEditButton;
    
    private void Start()
    {
        ballButton.onClick.AddListener(OnBallButtonClicked);
        balloonButton.onClick.AddListener(OnBalloonButtonClicked);
        plankButton.onClick.AddListener(OnPlankButtonClicked);
        forceReleaserButton.onClick.AddListener(OnForceReleaserButtonClicked);
        playEditButton.onClick.AddListener(OnPlayEditButtonClicked);
    }
    
    private void OnBallButtonClicked()
    {
        Debug.Log("Ball Button Clicked");
    }
    
    private void OnBalloonButtonClicked()
    {
        Debug.Log("Balloon Button Clicked");
    }
    
    private void OnPlankButtonClicked()
    {
        Debug.Log("Plank Button Clicked");
    }
    
    private void OnForceReleaserButtonClicked()
    {
        Debug.Log("Force Releaser Button Clicked");
    }
    
    private void OnPlayEditButtonClicked()
    {
        Debug.Log("Play Edit Button Clicked");
    }
    
    
}

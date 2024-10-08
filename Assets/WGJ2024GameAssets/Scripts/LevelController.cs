using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    
    [SerializeField] public  AtaquesMagoSO attackSet;
    
    
    public static UnityAction OnPauseEvent;
    public static UnityAction OnPlayEvent;

    [SerializeField] private string creditScene;
    
    [Header("GameSettings")]
    public Vector3 distanceVector;
    private Vector3 playerInitialPosition;
    public float stepDistance;
    
    
    public static LevelController Instance { get; private set; }

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this.gameObject); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        playerInitialPosition = PlayerController.Instance.transform.position;
        distanceVector = Magocontroller.Instance.transform.position -playerInitialPosition;
        stepDistance = ((distanceVector).magnitude)/attackSet.attacks.Count;
       
    }

    public void StartGame()
    {
        //LeanTween.cancelAll();
        Magocontroller.Instance.ResetMago();
        PlayerController.Instance.ResetPlayer(playerInitialPosition);
        BeatManager.Instance.PlaySong();
    }

    public void EndGame()
    {
        BeatManager.Instance.StopSong();
        SceneManager.LoadScene(creditScene);
    }
    
}

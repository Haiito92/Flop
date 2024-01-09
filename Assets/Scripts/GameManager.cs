using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Ref Game objects

    // GameStatus Fields
    private int _currentBossFight = 1;
    private int _currentSegment = 1;

    // GameEvents
    public Action OnNextSegment;
    public Action OnNextBossFight;
    public Action OnResetBossFight;

    #region Properties
    public int CurrentBossFight
    {
        get { return _currentBossFight; }
        set 
        { 
            _currentBossFight = value;
        }
    }
    public int CurrentSegment
    {
        get { return _currentSegment; }
        set 
        { 
            _currentSegment = value;
            
        }
    }
    #endregion

    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    void InitSingleton()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    private void Awake()
    {
        InitSingleton();
    }

    public void ToNextSegment()
    {
        CurrentSegment++;
        if (CurrentSegment == 11)
        {
            ToNextBossFight();
        }
        else
        {
            OnNextSegment?.Invoke();
        }

    }

    public void ToNextBossFight()
    {
        CurrentBossFight++;
        CurrentSegment = 1;
        OnNextBossFight?.Invoke();
    }
    public void ResetBossFight()
    {
        OnResetBossFight?.Invoke();
    }
}

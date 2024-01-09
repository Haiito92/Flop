using System;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    //Refs Databases

    
    //Ref Game objects
    [SerializeField] PlayerAttack _playerAttack;

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
    private static FightManager _instance;
    public static FightManager Instance => _instance;
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
        OnNextSegment?.Invoke();
        if (CurrentSegment == 11)
        {
 
            ToNextBossFight();
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

using Unity.VisualScripting;
using UnityEngine;

public delegate void DamageEvent(long damage);
public delegate void GameEvent();

public class GameManager : MonoBehaviour
{
    // GameStatus Fields
    private int _currentBossFight = 1;
    private int _currentSegment = 1;

    // DamageEvents
    public static DamageEvent onClickDamage;
    public static DamageEvent onPlayerDamage;
    public static DamageEvent onHeroDamage;

    // GameEvents
    public static GameEvent onNextSegment;
    public static GameEvent onNextBossFight;
    public static GameEvent onResetBossFight;

    private static GameManager _instance;
    public static GameManager Instance => _instance;

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

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    public void NextSegment()
    {
        CurrentSegment++;
        UIManager.Instance.SegmentNumber.text = "Segment : " + CurrentSegment.ToString();
        onNextSegment?.Invoke();

        if (CurrentSegment == 11)
        {
            CurrentSegment = 1;
            UIManager.Instance.SegmentNumber.text = "Segment : " + CurrentSegment.ToString();
            NextBossFight();
        }
    }

    public void NextBossFight()
    {
        CurrentBossFight++;
        UIManager.Instance.BossFightNumber.text = "BossFight : " + CurrentBossFight.ToString();
        UIManager.Instance.UpdateBossFightUI();
    }
    public void ResetBossFight()
    {
        onResetBossFight?.Invoke();
    }
}

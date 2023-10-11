using UnityEngine;

public delegate void DamageEvent(long damage);

public class GameManager : MonoBehaviour
{
    #region Properties
    public int CurrentBossFight
    {
        get { return _currentBossFight; }
        set 
        { 
            _currentBossFight = value;
            UIManager.Instance.BossFightNumber.text = "BossFight : " + _currentBossFight.ToString();
        }
    }
    public int CurrentSegment
    {
        get { return _currentSegment; }
        set 
        { 
            _currentSegment = value;
            UIManager.Instance.SegmentNumber.text = "Segment : " + _currentSegment.ToString();
            if(_currentSegment == 11)
            {
                _currentSegment = 1;
                UIManager.Instance.SegmentNumber.text = "Segment : " + _currentSegment.ToString();
                NextBossFight();
            }
        }
    }
    #endregion

    private int _currentBossFight = 1;
    private int _currentSegment = 1;

    public static DamageEvent onClickDamage;
    public static DamageEvent onPlayerDamage;
    public static DamageEvent onHeroDamage;

    private static GameManager _instance;
    public static GameManager Instance => _instance;

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
    }

    public void NextBossFight()
    {
        CurrentBossFight++;
        UIManager.Instance.UpdateBossFightUI();
    }
}

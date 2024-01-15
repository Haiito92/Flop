using System;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    //Databases
    int _enemyDataIndex = 0;

    //Refs Scene objects
    [SerializeField] PlayerBrains _playerBrain;
    [SerializeField] CharacterHealth _playerHealth;
    [SerializeField] Transform _enemySpot;

    //Refs UI
    [SerializeField] HealthBar _enemyHealthBar;

    //Prefabs
    [SerializeField] GameObject _enemyController;

    // GameStatus Fields
    private int _currentBossFight = 1;
    private int _currentSegment = 1;

    // GameEvents
    public event Action<int> OnNextSegment;
    public event Action<int> OnNextBossFight;
    public event Action OnResetBossFight;

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

    void SpawnNewEnemy()
    {
        EnemyData tempData = DatabasesManager.Instance.EnemyDatabase.EnemyDatas[_enemyDataIndex];
        GameObject tempGo = Instantiate(_enemyController, _enemySpot);

        tempGo.GetComponent<EnemyInitializer>().Initialize(tempData, _playerHealth);

        CharacterHealth enemyHealth = tempGo.GetComponent<CharacterHealth>();

        _enemyHealthBar.SetNewCharacter(enemyHealth);

        _playerBrain.SetCurrentBrainTarget(enemyHealth);

        _enemyDataIndex = (_enemyDataIndex + 1) % DatabasesManager.Instance.EnemyDatabase.EnemyDatas.Count;
    }

    private void Start()
    {
        SpawnNewEnemy();
    }

    public void ToNextSegment()
    {
        CurrentSegment++;
        if (CurrentSegment == 11)
        {
            CurrentSegment = 1;
            ToNextBossFight();
        }
        OnNextSegment?.Invoke(CurrentSegment);
        SpawnNewEnemy();
    }

    public void ToNextBossFight()
    {
        CurrentBossFight++;
        OnNextBossFight?.Invoke(CurrentBossFight);
    }
    public void ResetBossFight()
    {
        OnResetBossFight?.Invoke();
    }
}

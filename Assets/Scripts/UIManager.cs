using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bossFightNumber;
    [SerializeField] private TextMeshProUGUI _segmentNumber;

    #region Properties
    #endregion

    #region Singleton
    private static UIManager _instance;
    public static UIManager Instance => _instance;
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

    private void Start()
    {
        FightManager.Instance.OnNextSegment += UpdateSegmentUI;
        FightManager.Instance.OnNextBossFight += UpdateBossFightUI;
    }

    void UpdateSegmentUI(int currentSegment)
    {
        _segmentNumber.text = "Segment : " + currentSegment;
    }

    public void UpdateBossFightUI(int currentBossFight, int currentSegment)
    {
        _bossFightNumber.text = "BossFight : " + currentBossFight;
        UpdateSegmentUI(currentSegment);
    }
}

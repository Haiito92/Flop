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
        GameManager.Instance.OnNextSegment += UpdateSegmentUI;
        GameManager.Instance.OnNextBossFight += UpdateBossFightUI;
    }

    void UpdateSegmentUI()
    {
        _segmentNumber.text = "Segment : " + GameManager.Instance.CurrentSegment.ToString();
    }

    public void UpdateBossFightUI()
    {
        _bossFightNumber.text = "BossFight : " + GameManager.Instance.CurrentBossFight.ToString();
        UpdateSegmentUI();
    }
}

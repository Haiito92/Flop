using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bossFightNumber;
    [SerializeField] private TextMeshProUGUI _segmentNumber;

    #region Properties
    public TextMeshProUGUI BossFightNumber
    {
        get { return _bossFightNumber; }
        set { _bossFightNumber = value; }
    }
    public TextMeshProUGUI SegmentNumber
    {
        get { return _segmentNumber; }
        set { _segmentNumber = value; }
    }
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

    public void UpdateBossFightUI()
    {

    }
}

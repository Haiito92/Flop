using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bossFightNumber;
    [SerializeField] private TextMeshProUGUI _segmentNumber;

    [SerializeField] private Image _playerHealthFill;
    [SerializeField] private Image _heroHealthFill;

    private static UIManager _instance;
    public static UIManager Instance => _instance;

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
    public Image PlayerHealthFill
    {
        get { return _playerHealthFill; }
        set { _playerHealthFill = value; }
    }
    public Image HeroHealthFill
    {
        get { return _heroHealthFill; }
        set { _heroHealthFill = value; }
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

    public void UpdateBossFightUI()
    {

    }
}

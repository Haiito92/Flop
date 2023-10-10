using NaughtyAttributes;
using UnityEngine;

public delegate void DamageEvent(long damage);

public class GameManager : MonoBehaviour
{
    [SerializeField, Expandable] private PlayerData _playerData;

    public static DamageEvent onClickDamage;
    public static DamageEvent onPlayerDamage;

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

    public void OnClickInClickArea()
    {
        Debug.Log("Clicked");
        onClickDamage?.Invoke(_playerData.ClickDamage);
    }
}

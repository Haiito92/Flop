using NaughtyAttributes;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Expandable] private TestData _playerData;

    public delegate void OnClick(long clickDamage);
    public static OnClick OnClickCallBack;

    public void OnClickInClickArea()
    {
        Debug.Log("Clicked");
        OnClickCallBack?.Invoke(_playerData.Damage);
    }
}

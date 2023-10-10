using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Champs
    public long souls;
    

    //Methodes
    public void OnClickInClickArea()
    {
        Debug.Log("Click in the good spot");
    }

    public void AddSouls(long amount)
    {
        souls += amount;
    }

    public void ConsumeSouls(long amount)
    {
        souls -= amount;
    }
}

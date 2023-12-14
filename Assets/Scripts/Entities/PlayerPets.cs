using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPets : MonoBehaviour
{
    [SerializeField] List<Pet> _pets;

    //Properties
    #region Properties
    public List<Pet> Pets
    {
        get { return _pets; }
        set { _pets = value; }
    }
    #endregion
}

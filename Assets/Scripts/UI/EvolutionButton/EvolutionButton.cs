using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionButton : MonoBehaviour
{
    [SerializeField] BrainBinding _playerBrainBinding;
    [SerializeField] CharacterBrain _evolutionBrain;


    public void Evolution()
    {
        _playerBrainBinding.ChangeBrain(_evolutionBrain);
    }
}

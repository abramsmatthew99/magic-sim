using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTurnPhase", menuName = "TurnBasedGame/TurnPhase", order = 2)]
public class TurnPhase : ScriptableObject
{
    public string phaseName;
    public List<TurnStep> steps;
}

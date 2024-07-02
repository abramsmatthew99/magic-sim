using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTurnStep", menuName = "TurnBasedGame/TurnStep", order = 1)]
public class TurnStep : ScriptableObject
{
    public string stepName;
    public List<string> componentTypes;
}

using UnityEngine;

public class TurnPhaseListener : MonoBehaviour
{
    private TurnStateManager turnStateManager;

    private void Start()
    {
        turnStateManager = FindObjectOfType<TurnStateManager>();
        turnStateManager.OnPhaseChanged += OnPhaseChanged;
    }

    private void OnDestroy()
    {
        turnStateManager.OnPhaseChanged -= OnPhaseChanged;
    }

    private void OnPhaseChanged(TurnPhase newPhase)
    {
        // Add logic to handle phase-specific actions
        Debug.Log($"Phase changed to: {newPhase}");
    }
}

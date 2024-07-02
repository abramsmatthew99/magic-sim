using System;
using System.Collections.Generic;
using UnityEngine;

public class TurnStepListener : MonoBehaviour
{
    private TurnStepManager stepManager;

    private void Start()
    {
        stepManager = FindObjectOfType<TurnStepManager>();
        stepManager.OnStepChanged += OnStepChanged;
    }

    private void OnDestroy()
    {
        stepManager.OnStepChanged -= OnStepChanged;
    }

    private void OnStepChanged(TurnStep newStep)
    {
        Debug.Log($"Step changed to {newStep}");
        foreach (var componentType in newStep.componentTypes)
        {
            Type type = Type.GetType(componentType);
            if (type != null)
            {
                var component = gameObject.AddComponent(type) as MonoBehaviour;
                if (component != null)
                {
                    var method = type.GetMethod("Execute");
                    if (method != null)
                    {
                        method.Invoke(component, null);
                    }
                    Destroy(component); // Optionally destroy component after execution
                }
            }
        }
    }
}

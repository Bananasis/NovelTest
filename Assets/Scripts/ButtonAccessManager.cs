using Naninovel;
using Naninovel.Commands;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(CustomVariableTrigger))]
public class ButtonAccessManager : MonoBehaviour
{
    private Button button;
    private CustomVariableTrigger trigger;
    private ICustomVariableManager vManager;

    public void Awake()
    {
        trigger = GetComponent<CustomVariableTrigger>();
        button = GetComponent<Button>();
        vManager = Engine.GetService<ICustomVariableManager>();
    }

    public void SetInteractable(bool interactable)
    {
        var boolVar = vManager.GetVariableValue(trigger.CustomVariableName);
        if (!bool.TryParse(boolVar, out var boolean)) return;
        button.interactable = boolean;
    }
}
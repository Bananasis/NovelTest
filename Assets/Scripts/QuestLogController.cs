using System;
using System.Collections;
using System.Collections.Generic;
using Naninovel;
using TMPro;
using UnityEngine;


public class QuestLogController : MonoBehaviour
{
    private ICustomVariableManager vManager;
    private ILocalizationManager lManager;

    [SerializeField] private TMP_Text log;

    [ManagedText] public static string QuestText = ";a ;0; afkkfkfk;";

   

    private readonly List<string> _parsed = new();

    private void Parse(string _)
    {
        _parsed.Clear();
        _parsed.AddRange(QuestText.Split(";"));
    }

    void Awake()
    {
        vManager = Engine.GetService<ICustomVariableManager>();
        lManager = Engine.GetService<ILocalizationManager>();
       
    }

    private void OnEnable()
    {
        lManager.OnLocaleChanged += Parse;
        Parse("");
    }

    private void OnDisable()
    {
        lManager.OnLocaleChanged -= Parse;
    }

    public void OnChange()
    {
        var questState = vManager.GetVariableValue("quest_state");
        if (!int.TryParse(questState, out int state)) return;
        _state = state;
        UpdateQuestLog();
    }

   

    private int _state;

    private void UpdateQuestLog()
    {

        var logText = _parsed.Count <= _state ? "" : _parsed[_state];
        log.text = logText;
    }
}
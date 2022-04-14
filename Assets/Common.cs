using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonControll
{
    public static GUIState guiState { get; set; } = GUIState.Close;
}

public enum GUIState
{
    Close,
    Menu,
    Config, 
    Explan,
    Ads,
    Other,
}

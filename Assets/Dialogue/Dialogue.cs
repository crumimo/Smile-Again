using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public DialogVemeklis[] dialogVemeklis;
    public DialogVemeklis[] secondDialogVemeklis; // Второй диалог
    public bool shouldLoadNextScene; // Поле, указывающее, нужно ли загружать следующую сцену после завершения диалога
    public string sceneToLoad;
}

[System.Serializable]
public class DialogVemeklis
{
    public string speakerName;
    [TextArea(3, 10)] 
    public string sentence;
}

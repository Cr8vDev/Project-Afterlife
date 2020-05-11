using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueSequence : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private bool showNext;

    [SerializeField]
    private SpeechUI speechUI;



    public void OnPointerClick(PointerEventData data)
    {
        if (showNext)
        {
            speechUI.MessageNext();
        }
        else
        {
            speechUI.MessagePrevious();
        }
    }
}

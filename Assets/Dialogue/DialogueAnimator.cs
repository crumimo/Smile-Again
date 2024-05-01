using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (startAnim != null)
        {
            startAnim.SetBool("startOpen", true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (startAnim != null)
        {
            startAnim.SetBool("startOpen", false);
        }

        if (dm != null)
        {
            dm.EndDialogue();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;
    public Animator boxAnim;
    public Animator startAnim;
    private Queue<DialogVemeklis> sentences;
    private Dialogue currentDialogue;
    public DialogueSceneLoader sceneLoader; 
    public GameObject player;

   
    
    private bool firstDialogueShown = false; // Флаг для отслеживания показа первого диалога

    private void Start()
    {
        sentences = new Queue<DialogVemeklis>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        player.GetComponent<PlayerController>().enabled = false;
        boxAnim.SetBool("boxOpen", true);
        startAnim.SetBool("startOpen", false);

        sentences.Clear();
        currentDialogue = dialogue; // Сохраняем текущий диалог

        // Выбираем, какой диалог показать
        if (!firstDialogueShown)
        {
            foreach (DialogVemeklis sentence in dialogue.dialogVemeklis)
            {
                sentences.Enqueue(sentence);
            }
            firstDialogueShown = true;
        }
        else
        {
            foreach (DialogVemeklis sentence in dialogue.secondDialogVemeklis)
            {
                sentences.Enqueue(sentence);
            }
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogVemeklis sentence = sentences.Dequeue();
        dialogueText.text = sentence.sentence;
        nameText.text = sentence.speakerName;
    }

    public void EndDialogue()
    {
        if (boxAnim != null)
        {
            boxAnim.SetBool("boxOpen", false);
        }

        if (currentDialogue != null && currentDialogue.shouldLoadNextScene)
        {
            sceneLoader.LoadNextScene(currentDialogue.sceneToLoad);
        }
        player.GetComponent<PlayerController>().enabled = true;
    }
}

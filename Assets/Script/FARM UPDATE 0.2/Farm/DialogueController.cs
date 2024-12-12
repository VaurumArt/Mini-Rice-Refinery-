//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class DialogueController : MonoBehaviour
//{
//    public TextMeshProUGUI DialogueText;
//    public string[] Sentence;
//    private int Index = 0;
//    public float DialogueSpeed;
//    private bool canProceed = true;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            NextSentence();
//        }
//    }

//    void NextSentence()
//    {
//        if (Index <= Sentence.Length - 1)
//        {
//            DialogueText.text = " ";
//            StartCoroutine(WriteSentence());
//        }
//    }


//    IEnumerator WriteSentence()
//    {
//        foreach(char Character in Sentence[Index].ToCharArray())
//        {
//            DialogueText.text += Character;
//            yield return new WaitForSeconds(DialogueSpeed);
//        }
//        Index++;
//    }


//}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText; // The UI Text for displaying dialogue
    public string[] Sentences; // The array of sentences for the dialogue
    private int index = 0; // Tracks the current sentence
    public float DialogueSpeed = 0.05f; // Speed at which characters appear
    private bool isTyping = false; // Prevents skipping while a sentence is typing

    public GameObject TutorialDialogueUI;


    // Start is called before the first frame update
    void Start()
    {
        if (Sentences.Length > 0)
        {
            TutorialDialogueUI.SetActive(true);

            StartDialogue(); // Start the dialogue automatically
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            NextSentence();
        }
    }

    // Starts the dialogue by displaying the first sentence
    void StartDialogue()
    {
        index = 0; // Reset the index for new dialogue
        DisplaySentence();
    }

    // Advances to the next sentence or ends the dialogue
    void NextSentence()
    {
        if (index < Sentences.Length)
        {
            DisplaySentence();
        }
        else
        {
            EndDialogue();
        }
    }

    // Displays the current sentence letter by letter
    void DisplaySentence()
    {
        DialogueText.text = ""; // Clear the previous sentence
        StartCoroutine(WriteSentence(Sentences[index]));
        index++; // Move to the next sentence for future input
    }

    // Coroutine to type out the sentence
    IEnumerator WriteSentence(string sentence)
    {
        isTyping = true; // Prevent skipping while typing
        foreach (char character in sentence.ToCharArray())
        {
            DialogueText.text += character;
            yield return new WaitForSeconds(DialogueSpeed);
        }
        isTyping = false; // Allow proceeding after typing finishes
    }

    // Ends the dialogue
    void EndDialogue()
    {
        DialogueText.text = " "; // Placeholder for ending dialogue
        TutorialDialogueUI.SetActive(false); // Disable the GameObject this script is attached to
        // Add additional logic here, e.g., close dialogue box, trigger event, etc.
    }
}


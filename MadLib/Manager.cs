using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] Canvas inputUI;        // UI elements visible when taking in user input
    [SerializeField] Canvas sentenceUI;     // UI elements visible when displaying completed mad lib

    private List<SentenceObject> Sentences;
    private SentenceObject currentSentence;
    private InputField inputField;
    private Text prompt;
    private int blankIndex;

    private Text sentenceOutput;


    // Start is called before the first frame update
    void Start()
    {
        PopulateSentences();
        currentSentence = Sentences[0];

        // get heirarchy objects that will need to be accessed
        inputField = inputUI.GetComponentInChildren<InputField>();
        prompt = inputUI.GetComponentsInChildren<Text>()[2];
        sentenceOutput = sentenceUI.GetComponentInChildren<Text>();

        WritePrompt();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // this is where the sentences and the prompt lists are defined and added to the sentences list
    void PopulateSentences()
    {
        Sentences = new List<SentenceObject>();
        string sentence;
        string[] blanks;

        sentence = "It was a {0}, cold November day. I woke up to the {1} smell of {2} roasting in the {3} downstairs.";
        sentence += " I {4} down the stairs to see if I could help {5} the dinner.";
        sentence += " My mom said, \" See if {6} needs a fresh {7}.\" So I carried a tray of glasses full of {8} into the {9} room.";
        sentence += " When I got there, I couldn't believe my {10}! There were {11} {12} on the {13}!";
        blanks = new string[]{ "adjective", "adjective", "type of bird", "room in a house", "verb (past tense)", "verb", "relative's name", "noun", "liquid", "verb ending in -ing", "part of the body (plural)", "plural noun", "verb ending in -ing", "noun" };
        Sentences.Add(new SentenceObject(sentence, blanks));
    }

    // called from the input field On Edit End event, used to set the user inputs
    public void AddInput(string s)
    {
        currentSentence.inputs.Add(s.ToUpper());

        // reset prompt
        blankIndex++;
        if (blankIndex < currentSentence.blanks.Length)
        {
            WritePrompt();
            inputField.text = "";

            // re-enter input field after submission
            inputField.ActivateInputField();
            inputField.Select();
        }
        else ShowSentence();
    }

    // helper function for writing the text prompt text
    void WritePrompt()
    {
        string word = currentSentence.blanks[blankIndex];
        string article = "aeiouAEUIO".IndexOf(word[0]) >= 0 ? "an" : "a";
        prompt.text = string.Format("Enter {0} {1}...", article, word);
    }

    // switches canvases to show the sentence
    void ShowSentence()
    {
        sentenceUI.enabled = true;
        inputUI.enabled = false;

        sentenceOutput.text = string.Format(currentSentence.sentence, currentSentence.inputs.ToArray());
    }
}

// object representing a mad lib
public class SentenceObject
{
    public string sentence;         // the sentence template to be filled in
    public string[] blanks;         // the prompts for the blank spaces of a mad lib (adjective, verb, etc.)
    public List<string> inputs;     // user responses to the blanks/prompts

    public SentenceObject(string InSentence, string[] InBlanks)
    {
        sentence = InSentence;
        blanks = InBlanks;
        inputs = new List<string>();
    }
}

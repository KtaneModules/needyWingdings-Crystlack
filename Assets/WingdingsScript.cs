using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;

public class WingdingsScript : MonoBehaviour
{
    public KMAudio audio;
    public KMBombInfo bomb;
    public KMNeedyModule needyWingdings;

    //Interactables
    public KMSelectable[] cyclers;
    public KMSelectable submit;
    public GameObject display;

    //Variables
    public string[] words;
    string answer;
    int answerIndex;
    int ansIndex;
    int index;
    int currentIndex = 0;
    string[] choices = {" ", " ", " ", " ", " "};
    List<int> usedIndices = new List<int>();
  

    //Logging
    static int moduleCounter = 1;
    int moduleId;
    private bool moduleSolved;

    void Awake()
    {
        moduleId = moduleCounter++;
        needyWingdings = GetComponent<KMNeedyModule>();
        needyWingdings.OnNeedyActivation += OnNeedyActivation;
        needyWingdings.OnNeedyDeactivation += OnNeedyDeactivation;
        needyWingdings.OnTimerExpired += OnTimerExpired;
        foreach(KMSelectable cycler in cyclers)
        {
            cycler.OnInteract += delegate () { CycleWords(cycler); return false; };
        }
        submit.OnInteract += delegate () { SubmitWord(); return false; };

    }

    void Start()
    {

    }

    void OnNeedyActivation()
    {
        currentIndex = 0;
        usedIndices.Clear();
        answerIndex = UnityEngine.Random.Range(0, words.Length);
        answer = words[answerIndex];
        ansIndex = UnityEngine.Random.Range(0, 5);
        choices[ansIndex] = answer;
        usedIndices.Add(answerIndex);
        for(int i = 0; i < 5; i++)
        {
            if(i != ansIndex)
            {
                do
                {
                    index = UnityEngine.Random.Range(0, words.Length);
                } while (usedIndices.Contains(index));
                usedIndices.Add(index);
                choices[i] = words[index];
            }
        }
        display.GetComponent<TextMesh>().text = answer;
        submit.GetComponentInChildren<TextMesh>().text = choices[currentIndex];
        Debug.LogFormat("[Needy Wingdings #{0}] Possible words are {1}, {2}, {3}, {4}, {5}", moduleId, choices[0], choices[1], choices[2], choices[3], choices[4]);
        Debug.LogFormat("[Needy Wingdings #{0}] Correct word is: {1}", moduleId, choices[ansIndex]);
    }

    void OnNeedyDeactivation()
    {
        needyWingdings.HandlePass();
    }
   
    void OnTimerExpired()
    {
        Debug.LogFormat("[Needy Wingdings #{0}] Strike! You ran out of time", moduleId);
        needyWingdings.HandleStrike();
        OnNeedyDeactivation();
    }

    void CycleWords(KMSelectable cycler)
    {
        if(cycler == cyclers[0])
        {
            if(currentIndex != 4)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
        }
        else
        {
            if(currentIndex != 0)
            {
                currentIndex--;
            }
            else
            {
                currentIndex = 4;
            }
        }
        submit.GetComponentInChildren<TextMesh>().text = choices[currentIndex];
    }

    void SubmitWord()
    {
        if (choices[currentIndex] == words[answerIndex])
        {
            Debug.LogFormat("[Needy Wingdings #{0}] Correct answer submitted, module defuse... For now", moduleId);
            OnNeedyDeactivation();
        }
        else
        {
            Debug.LogFormat("[Needy Wingdings #{0}] Wrong answer submitted, strike received.", moduleId);
            needyWingdings.HandleStrike();
            Debug.LogFormat("[Needy Wingdings #{0}] Resetting module...", moduleId);
            OnNeedyActivation();
        }
    }
}

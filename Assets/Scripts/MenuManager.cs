using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{

    public TMP_InputField nameInput;

    public TMP_Text TopscoreText;

    private GameController GC;


    // Start is called before the first frame update
    void Start()
    {
        GC = GameObject.Find("GameController").GetComponent<GameController>().Self;
        GC.LoadLastPlayer();
        GC.LoadTopscore();

        SetTopScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        string currentPlayer = GC.GetCurrentName();

        if (nameInput != null && nameInput.text != null && nameInput.text.Trim() != "")
        {
            string newPlayer = nameInput.text.Trim();

            if (newPlayer!=currentPlayer)
            {
                GC.SetCurrentName(newPlayer);
                GC.SaveLastPlayer();
            }
        }
        
        SceneManager.LoadScene("main");
    }


    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void SetTopScoreText()
    {
        string currentname = "?";
        string topscorename = "?";
        int topscorevalue = 0;

        if (GC.GetCurrentName() != "") currentname = GC.GetCurrentName();
        if (GC.GetTopscoreName() != "") topscorename = GC.GetTopscoreName();
        if (GC.GetTopscore() > 0) topscorevalue = GC.GetTopscore();

        TopscoreText.text = "You are " + currentname + ", TopScore '" + topscorevalue + "' is from " + topscorename;

    }

}

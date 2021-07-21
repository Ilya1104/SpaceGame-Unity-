using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreFromFile : MonoBehaviour
{
    public GameObject ScoreText;
    public GameObject inputText;
    public GameObject Hide;
    string filePath = @"score.txt";
    void Loading()
    {       
        if (File.Exists(filePath))
        {
            int index = 1;
            string[] readText = File.ReadAllLines(filePath);
            foreach (string s in readText)
            {
                ScoreText.GetComponent<Text>().text += $"{index} {s} \n";
                index++;
            }
        }
    }
    private void Hiding()
    {
       
    }
   
    public void Writing()
    {
       
        using (StreamWriter file = new StreamWriter(filePath, true))
        {
            var data = new Data();
            file.WriteLine(inputText.GetComponent<Text>().text+", Score: "+ PlayerPrefs.GetFloat("score").ToString());
        }
        ScoreText.GetComponent<Text>().text = null;
        Loading();
    }
    public void LoadMenu()
    {
        
            SceneManager.LoadScene("Menu");
        
    }
    // Start is called before the first frame update
    void Start()
    {
     //   Hide.gameObject.enabled = false;
        ScoreText.GetComponent<Text>().text = null;
        Loading();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
}

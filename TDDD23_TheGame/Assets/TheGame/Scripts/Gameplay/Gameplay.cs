﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    // Start is called before the first frame update
    
	public TextAsset textFile; 
	private string text = null;
    void Start()
    {
        //text = textFile.text;  //this is the content as string
        if (text == null){
            string[] stringList = textFile.text.Split('\n');
            text = stringList[Mathf.RoundToInt(Random.Range(0, stringList.Length))].Trim();
            gameObject.GetComponent<BaseMovment>().SetHP(text.Length);

        }
        //Print the text from the file
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetText(string newText){
        text = newText;
        gameObject.GetComponent<BaseMovment>().SetHP(newText.Length);
    }

    public string GetText(){
        return text;
    }

    public void UpdateText(){
        if (text.Length > 0){
            text = text.Substring(1);
        }
    }
}

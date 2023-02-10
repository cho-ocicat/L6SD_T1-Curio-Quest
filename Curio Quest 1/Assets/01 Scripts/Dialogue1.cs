using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue1 : MonoBehaviour
{
    //ref to TextMeshPro
    public TextMeshProUGUI textComponent;
    //for collections of different sentences
    public string[] lines;
    //text speed
    public float textSpeed;
    //track where we are in the convo
    public int index;

    public GameObject warrior;

    public GameObject Ma1;
    public GameObject Ma2;
    public GameObject Ma3;
    public GameObject Ma4;

    // Start is called before the first frame update
    void Start()
    {
        warrior.SetActive(false);

        Ma1.SetActive(true);
        Ma2.SetActive(false);
        Ma3.SetActive(false);
        Ma4.SetActive(false);

        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            ForNextButton();
        }
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        //Takes string and breaks it down to char
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            WarriorSprite();
            MaSprite();
            StartCoroutine(TypeLine());
            
        }
        else
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }

    public void ForNextButton()
    {
        //if the line finished appearing, go to next line. If not, put the whole line instantly
        if(textComponent.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }

    //show Warrior Sprite at specific lines.
    public void WarriorSprite () 
    {
       if(index == 2 || index == 4 || index == 9)
       {
            warrior.SetActive(true);
       } 
       else
       {
            warrior.SetActive(false);
       }
    }

    public void MaSprite()
    {
        if(index == 0){
            Ma1.SetActive(true);
        }
        else if (index == 1 || index == 3 || index == 5)
        {
            Ma1.SetActive(false);
            Ma2.SetActive(true);            
        }
        else if(index == 2 || index == 4 || index == 6 || index == 7 || index == 8 || index == 9)
        {
            Ma1.SetActive(false);
            Ma2.SetActive(false);
            Ma3.SetActive(true);
        }
        else
        {
            Ma1.SetActive(false);
            Ma2.SetActive(false);
            Ma3.SetActive(false);
            Ma4.SetActive(true);
        }

    }
}

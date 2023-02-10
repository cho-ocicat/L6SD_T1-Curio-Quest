using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUp_System : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator anim;
    public TMP_Text popUpText;

    private void Start() {
        popUpBox.SetActive(false);
    }

    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        anim.SetTrigger("PopUp");
    }
}

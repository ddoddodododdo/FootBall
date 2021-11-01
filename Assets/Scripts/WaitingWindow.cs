using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingWindow : MonoBehaviour
{
    public Text waitingText;
    public static string[] textArray = new string[3]
                        {"������ ��ٸ��� ��."
                        , "������ ��ٸ��� ��.."
                        , "������ ��ٸ��� ��..." };

    private WaitForSeconds textChangeTime = new WaitForSeconds(0.5f);
    private int changeIndex = 0;


    private void Start()
    {
        StartCoroutine(ManageText());
    }

    IEnumerator ManageText()
    {
        while (true)
        {
            waitingText.text = textArray[changeIndex++];

            if (changeIndex >= textArray.Length) 
                changeIndex = 0;

            yield return textChangeTime;
        }
    }

}

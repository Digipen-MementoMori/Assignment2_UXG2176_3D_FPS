using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI text;
    public DialogueSO dialogs;
    int dialogIndex =0;
    public GameObject gameoverImage;
    // Start is called before the first frame update
    void Start()
    {
        text.text = dialogs.dialogues[dialogIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= 8 && Input.GetKeyDown(KeyCode.G)) Talk();
    }

    private void Talk()
    {
        if(dialogIndex < dialogs.dialogues.Count - 1){
            dialogIndex++;
            text.text = dialogs.dialogues[dialogIndex];
        }
        else
        {
            Victory();
        }
    }

    private void Victory()
    {
        Debug.Log("WIN!");
        gameoverImage.SetActive(true);
    }
}

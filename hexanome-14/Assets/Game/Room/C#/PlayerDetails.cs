﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDetails : MonoBehaviour
{

    public Text nameLabel;
    public Text heroLabel;
    public Button readyButton;
    public Transform mainContainer;

    private bool ready = false;


    public void setReady(bool r)
    {
        ColorBlock buttonColors = readyButton.colors;

        this.ready = r;
        if (r)
        {
            buttonColors.normalColor = new Color32(95, 255, 95, 255);
            buttonColors.highlightedColor = new Color32(142, 253, 142, 255);
            buttonColors.pressedColor = new Color32(182, 255, 182, 255);
            buttonColors.selectedColor = new Color32(206, 255, 206, 255);
            buttonColors.disabledColor = new Color32(95, 255, 95, 255);
        }
        else
        {
            buttonColors.normalColor = new Color32(255, 95, 95, 255);
            buttonColors.highlightedColor = new Color32(253, 142, 142, 255);
            buttonColors.pressedColor = new Color32(255, 182, 182, 255);
            buttonColors.selectedColor = new Color32(255, 206, 206, 255);
            buttonColors.disabledColor = new Color32(255, 95, 95, 255);
        }
        readyButton.colors = buttonColors;
    }


    public void readyClick()
    {
        this.ready = !this.ready;
        Game.myPlayer.ready = this.ready;
        Game.updatePlayer(Game.myPlayer);

        Debug.Log("Ready Pressed! Current state: " + this.ready);

        setReady(this.ready);
    }
}

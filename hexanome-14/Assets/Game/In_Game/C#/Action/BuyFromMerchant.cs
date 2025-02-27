﻿using System;
using UnityEngine;

[System.Serializable]
public class BuyFromMerchant : Action
{
    string[] players;
    Type type;
    private string saleItemStr;

    public BuyFromMerchant(string[] players, string saleItem)
    {

        type = Type.BuyFromMerchant;
        this.players = new string[1];
        this.players = players;
        this.saleItemStr = saleItem;
    }

    public Type getType()
    {
        return this.type;
    }
    public string[] playersInvolved()
    {
        return players;
    }

    public bool isLegal(GameState gs)
    {
        //only if they are on the same space as a merchant
        return true;
    }

    public void execute(GameState gs)
    {
        Hero client = Game.gameState.getPlayer(players[0]).getHero();
        String herotype = Game.gameState.getPlayer(players[0]).getHeroType();
        
        //decrement gold
        if (client.getGold() - 2 >= 0)
        {

            Debug.Log(saleItemStr + " !!!");

            if (saleItemStr != "Strength")
            {
                //remove item from inventory
                Article saleItem = Game.gameState.removeFromEquimentBoard(saleItemStr);
                //add item to heroes articles
                client.addArticle(saleItem);
                Debug.Log(client.allArticlesAsString());
                client.decreaseGold(2);
            }
            else
            {
                client.increaseStrength(1);
                Debug.Log(client.getStrength());
                if ((herotype == "Male Dwarf" || herotype == "Female Dwarf") && gs.getPlayerLocations()[(players[0])] == 71)
                {
                    client.decreaseGold(1);
                }
                else
                {
                    client.decreaseGold(2);
                }
            }
            
        }
        else
        {
            //GameController.instance.cannotBuyFromMerchant
        }



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData  {

    private static GameData instance;
    public static GameData Instance{

        get{

            if (instance == null)
                instance = new GameData();
            return instance;
        }
    }

    public GameData(){

        coinNum = 1000;
    }

    private int coinNum;

    public int CoinNum{
    
        get{

            return coinNum;
        }
    }

    public void addCoin(int Num){
    
        coinNum += Num; 
    }

    public void  reduceCoin(int Num){

        coinNum -= Num;
        if (coinNum <= 0)
            coinNum = 0;
    }

}

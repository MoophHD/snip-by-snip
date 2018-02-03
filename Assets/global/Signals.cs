using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signals : MonoBehaviour {

    public delegate void _onNewGame();
    public static event _onNewGame onNewGame;
    public static void newGame() {onNewGame();}

    public delegate void _onGameStart();
    public static event _onGameStart onGameStart;
    public static void gameStart() {onGameStart();}


    //with params
    // public delegate void _onTest(string str);
    // public static event _onTest onTest;
    // public static void test(string str) {onTest(str);}
}

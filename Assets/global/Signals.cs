using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signals : MonoBehaviour {

	public delegate void _onJump();
    public static event _onJump onJump;
    public static void jump() {onJump();}


    public delegate void _onNewGame();
    public static event _onNewGame onNewGame;
    public static void newGame() {onNewGame();}


    //with params
    // public delegate void _onTest(string str);
    // public static event _onTest onTest;
    // public static void test(string str) {onTest(str);}
}

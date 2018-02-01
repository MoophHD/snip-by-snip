using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signals : MonoBehaviour {

	public delegate void _onJump();
    public static event _onJump onJump;
}

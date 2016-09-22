using UnityEngine;
using System.Collections;
using Uniduino;

public class PuzzleManager : MonoBehaviour {

	public Arduino arduino;
	public Arduino arduino2;

	[SerializeField]private int  puzzleSovled;

	private int[] pinValue = new int[4];
	private int[] pinValue2 = new int[4];

	// Use this for initialization
	void Start () {
 		
		arduino.Connect ();
		arduino2.Connect ();
		arduino.Setup (ConfigurePins);
		arduino2.Setup (ConfigurePinsTwo);
		puzzleSovled = 0;

		for (int i = 0; i < 4; i++) {
			pinValue [i] = 1000;
			pinValue2 [i] = 1000;
		}

	}

	void ConfigurePinsTwo(){
		arduino2.pinMode (0, PinMode.ANALOG);
		arduino2.reportAnalog (0, 1);
		arduino2.pinMode (1, PinMode.ANALOG);
		arduino2.reportAnalog (1, 1);
		arduino2.pinMode (2, PinMode.ANALOG);
		arduino2.reportAnalog (2, 1);
		arduino2.pinMode (3, PinMode.ANALOG);
		arduino2.reportAnalog (3, 1);
		arduino2.pinMode (13, PinMode.OUTPUT);
	}

	void ConfigurePins(){
		arduino.pinMode (0, PinMode.ANALOG);
		arduino.reportAnalog (0, 1);
		arduino.pinMode (1, PinMode.ANALOG);
		arduino.reportAnalog (1, 1);
		arduino.pinMode (2, PinMode.ANALOG);
		arduino.reportAnalog (2, 1);
		arduino.pinMode (3, PinMode.ANALOG);
		arduino.reportAnalog (3, 1);
		arduino.pinMode (13, PinMode.OUTPUT);
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < 4; i++) {
			pinValue [i] = arduino.analogRead (i);
			pinValue2 [i] = arduino2.analogRead (i);
		}

		Debug.Log ("0:" + pinValue[0] + " 1:" + pinValue[1] + " 2:" + pinValue[2] + " 3:" + pinValue[3]);

		Debug.Log ("4:" + pinValue2[0] + " 5:" + pinValue2[1] + " 6:" + pinValue2[2] + " 7:" + pinValue2[3]);

		Debug.Log (puzzleSovled);

		if (pinValue[0] < 10 && pinValue[1] < 10 && pinValue[2] < 10 && pinValue[3] < 10) {
//			arduino.digitalWrite(13,Arduino.HIGH);
			puzzleSovled = 1;
	} else if (pinValue2[0] < 10 && pinValue2[1] < 10 && pinValue2[2] < 10 && pinValue2[3] < 10) {
			puzzleSovled = 2;
		}
		else{
			puzzleSovled = 0;
		}

	}

	public int getPuzzleNum(){
		return puzzleSovled;
	}

	public void setPuzzleNum(int puzzleNum){
		puzzleSovled = puzzleNum;
	}
}

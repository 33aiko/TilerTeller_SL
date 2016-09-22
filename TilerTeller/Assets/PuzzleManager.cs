using UnityEngine;
using System.Collections;
using Uniduino;

public class PuzzleManager : MonoBehaviour {

	public Arduino arduino;
	public Arduino arduino2;

	[SerializeField]private int  puzzleSovled;

	// Use this for initialization
	void Start () {
 		
		arduino.Connect ();
		arduino2.Connect ();
		arduino.Setup (ConfigurePins);
		arduino2.Setup (ConfigurePinsTwo);
		puzzleSovled = 0;
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



		int pinValue0 = arduino.analogRead (0);
		int pinValue1 = arduino.analogRead (1);
		int pinValue2 = arduino.analogRead (2);
		int pinValue3 = arduino.analogRead (3);

		int pinValue4 = arduino2.analogRead (0);
		int pinValue5 = arduino2.analogRead (1);
		int pinValue6 = arduino2.analogRead (2);
		int pinValue7 = arduino2.analogRead (3);

		Debug.Log ("0:" + pinValue0 + " 1:" + pinValue1 + " 2:" + pinValue2 + " 3:" + pinValue3);

		Debug.Log ("4:" + pinValue4 + " 5:" + pinValue5 + " 6:" + pinValue6 + " 7:" + pinValue7);

		Debug.Log (puzzleSovled);

		if (pinValue0 < 10 && pinValue1 < 10 && pinValue2 < 10 && pinValue3 < 10) {
//			arduino.digitalWrite(13,Arduino.HIGH);
			puzzleSovled = 1;
		} else if (pinValue4 < 10 && pinValue5 < 10 && pinValue6 < 10 && pinValue7 < 10) {
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

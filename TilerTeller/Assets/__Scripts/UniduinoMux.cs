using UnityEngine;
using System.Collections;
using Uniduino;

public class UniduinoMux : MonoBehaviour {

	public Arduino arduino;
	int[] mux0array;

	// Use this for initialization
	void Start () {
		arduino = Arduino.global;
		arduino.Setup (ConfigurePins);

		mux0array = new int[16];
	}
	
	// Update is called once per frame
	void Update () {

//		for (int i = 0; i < 16; i++) {
//			if (((i & 15) >> 3) == 1)
//				arduino.digitalWrite (5, Arduino.HIGH);
//			else if (((i & 15) >> 3) == 0)
//				arduino.digitalWrite (5, Arduino.LOW);
//				
//			if(((i & 7) >> 2)==1) 
//				arduino.digitalWrite (4, Arduino.HIGH);
//			else if (((i & 7) >> 2)==0) 
//				arduino.digitalWrite (4, Arduino.HIGH);
//
//			if (((i & 3) >> 1)==1)
//				arduino.digitalWrite (3, Arduino.HIGH);
//			else if (((i & 3) >> 1)==0)
//				arduino.digitalWrite (3, Arduino.LOW);
//
//			if((i&1) == 1)
//				arduino.digitalWrite (2, Arduino.HIGH);
//			else if((i&1) == 0)
//				arduino.digitalWrite (2, Arduino.LOW);
//
//			mux0array [i] = arduino.analogRead (0);
//
//		}

		arduino.digitalWrite (5, Arduino.LOW);
		arduino.digitalWrite (4, Arduino.LOW);
		arduino.digitalWrite (3, Arduino.LOW);
		arduino.digitalWrite (2, Arduino.LOW);
		mux0array [0] = arduino.analogRead (0);

		arduino.digitalWrite (5, Arduino.LOW);
		arduino.digitalWrite (4, Arduino.LOW);
		arduino.digitalWrite (3, Arduino.LOW);
		arduino.digitalWrite (2, Arduino.LOW);
		mux0array [1] = arduino.analogRead (1);

		arduino.digitalWrite (5, Arduino.LOW);
		arduino.digitalWrite (4, Arduino.LOW);
		arduino.digitalWrite (3, Arduino.LOW);
		arduino.digitalWrite (2, Arduino.HIGH);
		mux0array [2] = arduino.analogRead (0);

		Debug.Log (mux0array[0]+","+mux0array[1]+","+mux0array[2]+","+mux0array[3]+","+mux0array[4]);
	
	}

	void ConfigurePins(){
		arduino.pinMode (0, PinMode.ANALOG);
		arduino.reportAnalog (0, 1);
		arduino.pinMode (1, PinMode.ANALOG);
		arduino.reportAnalog (1, 1);
		arduino.pinMode (5, PinMode.OUTPUT);
		arduino.pinMode (4, PinMode.OUTPUT);
		arduino.pinMode (3, PinMode.OUTPUT);
		arduino.pinMode (2, PinMode.OUTPUT);
	}

}

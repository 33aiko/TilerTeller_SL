using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class StarLighter : MonoBehaviour {

	class Star{

		public GameObject mystar;
		public ArrayList fireflys;

		private int starNum;
		private	Dictionary<string,Sprite> dictSprites = new Dictionary<string,Sprite> ();


		public Star(int num){
			fireflys = new ArrayList(4);
			starNum = num;

			Sprite[] sprites = Resources.LoadAll<Sprite>("S2_P3_atlas1");
			foreach (Sprite sprite in sprites) {
				dictSprites.Add (sprite.name, sprite);
//				Debug.Log (sprite.name);
			}
		}
			

		public void lightStar(int num){
//			if (starNum == 0)
//				return;

			if (num > starNum)
				return;

			for (int i = 1; i < num+1; i++) {
				if (fireflys [i] != null) {
					SpriteRenderer myfirefly = (SpriteRenderer)fireflys [i];
					myfirefly.DOFade (1, 1);
				}
			}

			if (num == starNum) {
				switch (starNum) {
				case 1:
					mystar.GetComponent<SpriteRenderer> ().sprite = dictSprites ["S2_P3_star1"];
					break;
				case 2:
					mystar.GetComponent<SpriteRenderer> ().sprite = dictSprites ["S2_P3_star2"];
					break;
				case 3:
					mystar.GetComponent<SpriteRenderer> ().sprite = dictSprites ["S2_P3_star3"];
					break;
				case 4:
					mystar.GetComponent<SpriteRenderer> ().sprite = dictSprites ["S2_P3_star4"];
					break;
				}
			}
		}

	}

	public GameObject[] stars;
	private  int[] buttonCounter = { 0, 0, 0, 0 };
	private Star[] mystars = new Star[4];



	void Awake(){
		mystars = new Star[4];

		for (int i = 0; i < 4; i++) {
			
			mystars [i] = new Star (i+1);
			mystars [i].mystar = stars [i];

			Component[] myfireflys = mystars[i].mystar.GetComponentsInChildren (typeof(SpriteRenderer));
			if (myfireflys != null) {
				foreach (SpriteRenderer firefly in myfireflys)
					mystars [i].fireflys.Add (firefly);
			}

		}
	}


	void Start () {
		

	}
	

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			buttonCounter [0]++;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			buttonCounter [1]++;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			buttonCounter [2]++;
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			buttonCounter [3]++;
		}

		for (int i = 0; i < 4; i++) {
			if (mystars [i] != null) {
				mystars [i].lightStar (buttonCounter [i]);
			}
		}
//		Debug.Log(buttonCounter[0]+","+buttonCounter[1]+","+buttonCounter[2]+","+buttonCounter[3]);
	}
}

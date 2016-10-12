using UnityEngine;
using System.Collections;

public class storySelector : MonoBehaviour {

	public int storyNum;

	public void selectStory(int story){
		Application.LoadLevel (story);
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pageManager : MonoBehaviour {


	public GameObject[] pages;
	public GameObject hintPage;

	private int pageNum;
	private int pageCount;
	private int currentPage;
	private bool isWaiting;

	private int[] pageRead;

	private GameObject lastBtn;
	private GameObject nextBtn;

	void Start () {

		lastBtn = GameObject.Find("/Canvas/last");
		nextBtn = GameObject.Find ("/Canvas/next");
		
		pageNum = pages.Length;
		pageCount = 0;
		currentPage = 0;
		isWaiting = false;

		pageRead = new int[pageNum];
		pageRead [0] = 0;
	}


	void Update () {
		lastBtn.SetActive (true);
		nextBtn.SetActive (true);
		if (isWaiting) {
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				pageRead [pageCount] = 1;
				currentPage = 1;
				hideHintPage ();
				isWaiting = false;
			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				pageRead [pageCount] = 2;
				currentPage = 2;
				hideHintPage ();
				isWaiting = false;
			} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
				pageRead [pageCount] = 3;
				currentPage = 3;
				hideHintPage ();
				isWaiting = false;
			}
		}

		for (int i = 0; i < pageNum; i++) {
			if (i == currentPage && pages [i] != null) {
				pages [i].SetActive (true);
				if (pages [i].GetComponent<AudioSource> () != null && pages [i].GetComponent<AudioSource> ().isPlaying != true) {
					pages [i].GetComponent<AudioSource> ().Play ();}
			} else {
				pages[i].SetActive(false);
			}
		}
		if (currentPage == 0) {
			lastBtn.SetActive (false);
		}
		if (currentPage == pageNum - 1) {
			nextBtn.SetActive (false);
		}

	}

	public void turnNextPage(){

		if (pageCount == pageNum - 2) {
			currentPage = pageNum - 1;
			pageRead [pageNum - 1] = currentPage;
			for (int j = 0; j < pageNum; j++) {
				Debug.Log (pageRead [j]);
			}

		} else if (pageRead [pageCount + 1] != 0) {
			currentPage = pageRead [pageCount + 1];
			pageCount++;
			return;
		}

		else {
			showHintPage ();
		}
		pageCount++;
		
	}

	public void turnLastPage(){
		if (currentPage == 0) {
			return;
		} else {
			pageCount--;
			currentPage = pageRead [pageCount];
		}
	}

	void showHintPage(){
		if (hintPage != null) {
			hintPage.SetActive (true);
			Debug.Log ("next page");
			isWaiting = true;
		}

	}

	void hideHintPage(){
		hintPage.SetActive (false);
	}


}

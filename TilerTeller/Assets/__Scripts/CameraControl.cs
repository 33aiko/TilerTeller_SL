using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour {

	[SerializeField] float moveTime = 1f;
//	[SerializeField] float defaultFOV = 60f;
	[SerializeField] float zoomInFOV = 30f;
	[SerializeField] Canvas dialogue;
	[SerializeField] Animator  cubeAnim;
	public Text text;

	public enum State
	{
		None = 0,
		SquareOne = 1,
		SquareTwo = 2,
		SquareThree = 3,
		SquareFour = 4,
		Fold = 5,
		Folded = 6,
	}
	private State m_state = State.None;
	public State state
	{
		get { return m_state; }
		set { 
			if (((int)value) >= 1 && ((int)value) <= 4) {
				int index = (int)value - 1;
				if (focusList.Length > index) {
					Vector3 toPosition = focusList [index].position - new Vector3(0,0.8f,0);
					toPosition.z = transform.position.z;

					transform.DOMove (toPosition, moveTime);
					if (m_camera != null)
						m_camera.DOFieldOfView (zoomInFOV, moveTime);
				}
						
			}
			if ( value == State.Fold )
			{
				m_camera.DOFieldOfView( defaultFOV,moveTime);
				transform.DOMove (defaultPos , moveTime);
			}

			if (value == State.Folded) 
			{
				Debug.Log ("S1");
				if (cubeAnim != null) {
					if (cubeAnim.GetCurrentAnimatorStateInfo (0).IsName ("Default")) {
						Debug.Log ("S2");
						cubeAnim.SetTrigger ("Start");
					}
					
				}
			}


			nextIcon.DOFade (0, 0);

			int textIndex = (int)value - 1;
			if (textIndex < textList.Length) {
				text.text = textList [textIndex];
				text.DOFade (0, 0);
				text.DOFade (1, 1.5f);
				nextIcon.DOFade (1, 0.5f).SetDelay(2);
			}


				
			m_state = value;
		}
	}

	private Camera m_camera;
	private float defaultFOV;
	private Vector3 defaultPos;
	private GameObject continueBtn;
	private Image nextIcon;


	[SerializeField] GameObject[] squares;
	[SerializeField] Transform[] focusList;
	[SerializeField] string[] textList;


	void Awake()
	{
		m_camera = GetComponent<Camera> ();	
		if (m_camera != null)
			defaultFOV = m_camera.fieldOfView;
		defaultPos = transform.position;
		continueBtn = GameObject.Find ("continue");
		continueBtn.SetActive(false);
		nextIcon = GameObject.Find ("next").GetComponent<Image>();
		nextIcon.DOFade (0, 0);
	}

	void Start(){

		for (int i = 0; i < squares.Length; i++) {
			squares [i].GetComponent<SpriteRenderer> ().DOFade (1, 2);
		}
		GameObject[] dialogues = GameObject.FindGameObjectsWithTag ("UI");
		foreach (GameObject dialogue in dialogues) {
			dialogue.GetComponent<RectTransform> ().DOScale (1, 0.5f).SetDelay(1f);
		}
		nextIcon.DOFade (1, 0.5f).SetDelay(2);
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) {
			state++;
		}
		if (cubeAnim.GetCurrentAnimatorStateInfo (0).IsName ("Finished")) {
			continueBtn.SetActive (true);
		}
	}
}

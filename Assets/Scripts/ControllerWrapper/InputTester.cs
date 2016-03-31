using UnityEngine;
using UnityEngine.SceneManagement;

public class InputTester : MonoBehaviour {

	public static InputTester instance;

	public Sprite XBOX_A, PS4_A, KEY_A, XBOX_B, PS4_B, KEY_B, XBOX_START, PS4_START, KEY_START, JOYLEFT, KEY_UPDOWNLEFTRIGHT;

	private ControllerManager cm;

    void Awake()
    {
        if (instance == null)
        {
//			DontDestroyOnLoad(this);
            instance = this;
            cm = new ControllerManager();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

	void Update() {
		if(SceneManager.GetActiveScene().name.Contains("Testing"))
			cm.AddPlayer(ControllerInputWrapper.Buttons.Start);
	}
}

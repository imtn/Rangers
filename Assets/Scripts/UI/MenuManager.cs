using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Scripts.Data;
using Assets.Scripts.Util;

namespace Assets.Scripts.UI
{
    public class MenuManager : MonoBehaviour
    {
        public static MenuManager instance;

        public static Enums.UIStates state = Enums.UIStates.Splash;

        private float hTimer, vTimer, delay = 0.1f;

        private Transform activePanel;

        private bool dpadPressed;

        [SerializeField]
        private Transform SplashPanel, MainPanel, SinglePanel, MultiPanel, SettingPanel, AudioPanel, VideoPanel;

        
        void Awake()
        {
            if(instance == null)
            {
                DontDestroyOnLoad(gameObject);
                instance = this;
                UpdatePanels(SplashPanel);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        void Update()
        {
            switch(state)
            {
                case Enums.UIStates.Splash:
                    Splash();
                    break;
                case Enums.UIStates.Main:
                    Main();
                    break;
                case Enums.UIStates.SinglePlayer:
                    SinglePlayer();
                    break;
                case Enums.UIStates.Multiplayer:
                    Multiplayer();
                    break;
                case Enums.UIStates.Settings:
                    Settings();
                    break;
                case Enums.UIStates.Audio:
                    Audio();
                    break;
                case Enums.UIStates.Video:
                    Video();
                    break;
                case Enums.UIStates.None:
                    break;
            }
        }

        private void Splash()
        {
			if(ControllerManager.instance.GetButton(ControllerInputWrapper.Buttons.Start, PlayerID.One))
            {
                if (GameManager.instance.AllPlayers.Count == 0)
                {
                    state = Enums.UIStates.Signin;
                    //UpdatePanels();
                }
                else
                {
                    state = Enums.UIStates.Main;
                    UpdatePanels(MainPanel);
                }
            }
			if(ControllerManager.instance.GetButton(ControllerInputWrapper.Buttons.B, PlayerID.One))
            {
                ExitGame();
            }
        }

        private void Main()
        {
            Navigate(); 
        }

        private void SinglePlayer()
        {
            Navigate();
			if (ControllerManager.instance.GetButton(ControllerInputWrapper.Buttons.B, PlayerID.One))
            {
                state = Enums.UIStates.Main;
                UpdatePanels(MainPanel);
            }
        }

        private void Multiplayer()
        {
            Navigate();
			if (ControllerManager.instance.GetButton(ControllerInputWrapper.Buttons.B, PlayerID.One))
            {
                state = Enums.UIStates.Main;
                UpdatePanels(MainPanel);
            }
        }

        private void Settings()
        {
            Navigate();
			if (ControllerManager.instance.GetButton(ControllerInputWrapper.Buttons.B, PlayerID.One))
            {
                state = Enums.UIStates.Main;
                UpdatePanels(MainPanel);
            }
        }

        private void Audio()
        {
            Navigate();
			if (ControllerManager.instance.GetButton(ControllerInputWrapper.Buttons.B, PlayerID.One))
            {
                state = Enums.UIStates.Settings;
                UpdatePanels(SettingPanel);
            }
        }

        private void Video()
        {
            Navigate();
			if (ControllerManager.instance.GetButton(ControllerInputWrapper.Buttons.B, PlayerID.One))
            {
                state = Enums.UIStates.Settings;
                UpdatePanels(SettingPanel);
            }
        }

        private void None()
        {

        }

        private void HideAllPanels()
        {
            state = Enums.UIStates.None;
            SplashPanel.gameObject.SetActive(false);
            MainPanel.gameObject.SetActive(false);
            SinglePanel.gameObject.SetActive(false);
            MultiPanel.gameObject.SetActive(false);
            SettingPanel.gameObject.SetActive(false);
            AudioPanel.gameObject.SetActive(false);
            VideoPanel.gameObject.SetActive(false);
        }

        private void Navigate()
        {
            // No axis is being pressed
			if (ControllerManager.instance.GetAxis(ControllerInputWrapper.Axis.RightStickX,PlayerID.One) == 0)
            {
                // Reset the timer so that we don't continue scrolling
                hTimer = 0;
            }
            // Horizontal joystick is held right
            // Use > 0.5f so that sensitivity is not too high
			else if (ControllerManager.instance.GetAxis(ControllerInputWrapper.Axis.RightStickX,PlayerID.One) > 0.5f)
            {
                // If we can move and it is time to move
                if (hTimer >= delay || hTimer == 0)
                {
                    // Move and reset timer
                    Navigator.Navigate(Enums.MenuDirections.Right);
                    hTimer = 0;
                }
                hTimer += Time.deltaTime;
            }
            // Horizontal joystick is held left
            // Use > 0.5f so that sensitivity is not too high
			else if (ControllerManager.instance.GetAxis(ControllerInputWrapper.Axis.RightStickX,PlayerID.One) < -0.5f)
            {
                // If we can move and it is time to move
                if (hTimer >= delay || hTimer == 0)
                {
                    // Move and reset timer
                    Navigator.Navigate(Enums.MenuDirections.Left);
                    hTimer = 0;
                }
                hTimer += Time.deltaTime;
            }

            // No axis is being pressed
			if (ControllerManager.instance.GetAxis(ControllerInputWrapper.Axis.RightStickY,PlayerID.One) == 0)
            {
                // Reset the timer so that we don't continue scrolling
                vTimer = 0;
            }
            // Horizontal joystick is held right
            // Use > 0.5f so that sensitivity is not too high
			else if (ControllerManager.instance.GetAxis(ControllerInputWrapper.Axis.RightStickY,PlayerID.One) > 0.5f)
            {
                // If we can move and it is time to move
                if (vTimer >= delay || vTimer == 0)
                {
                    // Move and reset timer
                    Navigator.Navigate(Enums.MenuDirections.Up);
                    vTimer = 0;
                }
                vTimer += Time.deltaTime;
            }
            // Horizontal joystick is held left
            // Use > 0.5f so that sensitivity is not too high
			else if (ControllerManager.instance.GetAxis(ControllerInputWrapper.Axis.RightStickY,PlayerID.One) < -0.5f)
            {
                // If we can move and it is time to move
                if (vTimer >= delay || vTimer == 0)
                {
                    // Move and reset timer
                    Navigator.Navigate(Enums.MenuDirections.Down);
                    vTimer = 0;
                }
                vTimer += Time.deltaTime;
            }

            // Have dpad functionality so that player can have precise control and joystick quick navigation
            // Check differently for Windows vs OSX

            // No dpad button is pressed
			if (ControllerManager.instance.GetAxis(ControllerInputWrapper.Axis.DPadX,PlayerID.One) == 0 && (ControllerManager.instance.GetAxis(ControllerInputWrapper.Axis.DPadY,PlayerID.One) == 0)) dpadPressed = false;
            // Dpad right is pressed; treating as DPADRightOnDown
			if (ControllerManager.instance.GetAxis(ControllerInputWrapper.Axis.DPadX,PlayerID.One) > 0 && !dpadPressed)
            {
                dpadPressed = true;
                Navigator.Navigate(Enums.MenuDirections.Right);
            }
            // Dpad right is pressed; treating as DPADLeftOnDown
			if (ControllerManager.instance.GetAxis(ControllerInputWrapper.Axis.DPadX,PlayerID.One) < 0 && !dpadPressed)
            {
                dpadPressed = true;
                Navigator.Navigate(Enums.MenuDirections.Left);
            }
            // Dpad up is pressed; treating as DPADUpOnDown
			if (ControllerManager.instance.GetAxis(ControllerInputWrapper.Axis.DPadY,PlayerID.One) > 0 && !dpadPressed)
            {
                dpadPressed = true;
                Navigator.Navigate(Enums.MenuDirections.Up);
            }
            // Dpad down is pressed; treating as DPADDownOnDown
			if (ControllerManager.instance.GetAxis(ControllerInputWrapper.Axis.DPadY,PlayerID.One) < 0 && !dpadPressed)
            {
                dpadPressed = true;
                Navigator.Navigate(Enums.MenuDirections.Down);
            }
            

			if (ControllerManager.instance.GetButton(ControllerInputWrapper.Buttons.A, PlayerID.One)) Navigator.CallSubmit();
        }

        public void CallSinglePlayer()
        {
            state = Enums.UIStates.SinglePlayer;
            UpdatePanels(SinglePanel);
        }

        public void CallMultiPlayer()
        {
            state = Enums.UIStates.Multiplayer;
            UpdatePanels(MultiPanel);
        }

        public void CallSettings()
        {
            state = Enums.UIStates.Settings;
            UpdatePanels(SettingPanel);
        }

        public void CallAudio()
        {
            state = Enums.UIStates.Audio;
            UpdatePanels(AudioPanel);
        }

        public void CallVideo()
        {
            state = Enums.UIStates.Video;
            UpdatePanels(VideoPanel);
        }

        public void ExitGame()
        {
             if(!Application.platform.ToString().Contains("Web")) Application.Quit();
        }

        private void UpdatePanels(Transform panel)
        {
            if (panel)
            {
                panel.gameObject.SetActive(true);
                panel.SetAsLastSibling();
            }
            GameObject defaultButton = panel.GetComponent<MenuOption>().DefaultButton;
            if (defaultButton)
            {
                EventSystem.current.SetSelectedGameObject(defaultButton);
                Navigator.defaultGameObject = defaultButton;
            }
            if (activePanel) activePanel.gameObject.SetActive(false);
            activePanel = panel;
        }
    } 
}

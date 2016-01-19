using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Scripts.Data;
using Assets.Scripts.Util;
using TeamUtility.IO;

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
            if(InputManager.GetButtonDown("Start_P1") || InputManager.GetButtonDown("Submit_P1"))
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
            if(InputManager.GetButtonDown("Cancel_P1"))
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
            if (InputManager.GetButtonDown("Cancel_P1"))
            {
                state = Enums.UIStates.Main;
                UpdatePanels(MainPanel);
            }
        }

        private void Multiplayer()
        {
            Navigate();
            if (InputManager.GetButtonDown("Cancel_P1"))
            {
                state = Enums.UIStates.Main;
                UpdatePanels(MainPanel);
            }
        }

        private void Settings()
        {
            Navigate();
            if (InputManager.GetButtonDown("Cancel_P1"))
            {
                state = Enums.UIStates.Main;
                UpdatePanels(MainPanel);
            }
        }

        private void Audio()
        {
            Navigate();
            if (InputManager.GetButtonDown("Cancel_P1"))
            {
                state = Enums.UIStates.Settings;
                UpdatePanels(SettingPanel);
            }
        }

        private void Video()
        {
            Navigate();
            if (InputManager.GetButtonDown("Cancel_P1"))
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
            if (InputManager.GetAxis("Horizontal_P1") == 0)
            {
                // Reset the timer so that we don't continue scrolling
                hTimer = 0;
            }
            // Horizontal joystick is held right
            // Use > 0.5f so that sensitivity is not too high
            else if (InputManager.GetAxis("Horizontal_P1") > 0.5f)
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
            else if (InputManager.GetAxis("Horizontal_P1") < -0.5f)
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
            if (InputManager.GetAxis("Vertical_P1") == 0)
            {
                // Reset the timer so that we don't continue scrolling
                vTimer = 0;
            }
            // Horizontal joystick is held right
            // Use > 0.5f so that sensitivity is not too high
            else if (InputManager.GetAxis("Vertical_P1") > 0.5f)
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
            else if (InputManager.GetAxis("Vertical_P1") < -0.5f)
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
            if (Application.platform.ToString().Contains("Windows") || Application.platform.ToString().Contains("Linux"))
            {
                // No dpad button is pressed
                if ((InputManager.GetAxis("DPADHorizontal_P1") == 0) && (InputManager.GetAxis("DPADVertical_P1") == 0)) dpadPressed = false;
                // Dpad right is pressed; treating as DPADRightOnDown
                if (InputManager.GetAxis("DPADHorizontal_P1") > 0 && !dpadPressed)
                {
                    dpadPressed = true;
                    Navigator.Navigate(Enums.MenuDirections.Right);
                }
                // Dpad right is pressed; treating as DPADLeftOnDown
                if (InputManager.GetAxis("DPADHorizontal_P1") < 0 && !dpadPressed)
                {
                    dpadPressed = true;
                    Navigator.Navigate(Enums.MenuDirections.Left);
                }
                // Dpad up is pressed; treating as DPADUpOnDown
                if (InputManager.GetAxis("DPADVertical_P1") > 0 && !dpadPressed)
                {
                    dpadPressed = true;
                    Navigator.Navigate(Enums.MenuDirections.Up);
                }
                // Dpad down is pressed; treating as DPADDownOnDown
                if (InputManager.GetAxis("DPADVertical_P1") < 0 && !dpadPressed)
                {
                    dpadPressed = true;
                    Navigator.Navigate(Enums.MenuDirections.Down);
                }
            }
            else if (Application.platform.ToString().Contains("OSX"))
            {
                // Just check buttons
                if (InputManager.GetButtonDown("DPADRight")) Navigator.Navigate(Enums.MenuDirections.Right);
                if (InputManager.GetButtonDown("DPADLeft")) Navigator.Navigate(Enums.MenuDirections.Left);
                if (InputManager.GetButtonDown("DPADUp")) Navigator.Navigate(Enums.MenuDirections.Up);
                if (InputManager.GetButtonDown("DPADDown")) Navigator.Navigate(Enums.MenuDirections.Down);
            }

            if (InputManager.GetButtonDown("Submit_P1")) Navigator.CallSubmit();
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

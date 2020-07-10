using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {
    public TMP_Text[] menuTexts;
    public int selection = 0;
    public Canvas pauseCanvas;

    public bool paused;

    public float yLastFrame = 0.0f;

    public float axisThreshold = 0.1f;

    private void Update() {
        if (Input.GetButtonDown("Cancel")) {
            if (paused) {
                Resume();
            } else {
                Pause();
            }
        }


        if (paused) {
            if (Input.GetAxisRaw("Vertical") > axisThreshold && yLastFrame <= axisThreshold) {
                selection--;
                if (selection < 0) {
                    selection = menuTexts.Length - 1;
                }
            }
            else if (Input.GetAxisRaw("Vertical") < -axisThreshold && yLastFrame >= -axisThreshold) {
                selection++;
                if (selection > menuTexts.Length - 1) {
                    selection = 0;
                }
            }

            yLastFrame = Input.GetAxisRaw("Vertical");

            foreach (TMP_Text menuText in menuTexts) {
                menuText.fontSize = 26;
                menuText.fontStyle = FontStyles.Normal;
            }

            menuTexts[selection].fontSize = 36;
            menuTexts[selection].fontStyle = FontStyles.Bold;

            if (Input.GetButtonDown("Submit")) {
                if (selection == 0) {
                    Resume();
                } else if (selection == 1) {
                    Resume();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                } else {
                    Resume();
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
    }

    private void Pause() {
        Time.timeScale = 0;
        pauseCanvas.enabled = true;
        paused = true;
    }

    private void Resume() {
        Time.timeScale = 1;
        pauseCanvas.enabled = false;
        paused = false;
    }
} 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadgeManager : MonoBehaviour
{
    //badges
    public static bool gallantKnight = false;
    public static bool wiseSolomon = false;
    public static bool defenderNinja = false;
    public static bool vigilantGuardian = false;

    public int badge;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "Player") {
            switch (badge) {
                case 1:
                    gallantKnight = true;
                    break;
                case 2:
                    wiseSolomon = true;
                    break;
                case 3:
                    defenderNinja = true;
                    break;
                case 4:
                    vigilantGuardian = true;
                    break;
                default:
                    break;
            }

            SceneManager.LoadScene("Hub");

        }
        
        
    }
    

}

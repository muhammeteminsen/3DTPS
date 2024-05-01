using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    public GameObject Lose;
    public GameObject Win;
    public GameObject Sure;
    public GameObject Boss;

    void Start()
    {
        Time.timeScale = 1;
        Lose.SetActive(false);
        Win.SetActive(false);
        Sure.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Sure.SetActive(true);
    }
    public void SurePanelFNC(string answer)
    {
        switch (answer)
        {
            case "yes":
                Application.Quit();
                break;
            case "no":
                Sure.SetActive(false);
                break;

        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);

    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoseFNC()
    {

        Lose.SetActive(true);
        Time.timeScale = 0f;

    }
    public void WinFNC()
    {
        if (Input.GetButton("Fire1"))
        {
            Win.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        
        Boss.GetComponent<Animator>().Play("Lose");

    }
    void Update()
    {
        if (PlayerMovement.mainHealth <= 0)
        {
            LoseFNC();
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

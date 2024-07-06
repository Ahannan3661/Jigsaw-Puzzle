using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneController : MonoBehaviour
{

    [SerializeField] GameObject[] startObjects;
    [SerializeField] GameObject[] selectObjects;
    [SerializeField] GameObject[] puzzleObjects;
    [SerializeField] GameObject[] puzzle1Objects;
    [SerializeField] GameObject[] puzzle2Objects;
    [SerializeField] GameObject[] puzzle3Objects;
    [SerializeField] GameObject[] puzzle4Objects;

    public Sprite p1Img;
    public Sprite p2Img;
    public Sprite p3Img;
    public Sprite p4Img;

    public VideoPlayer startVideoPlayer;

    public Sprite p1ImgSmall;
    public Sprite p2ImgSmall;
    public Sprite p3ImgSmall;
    public Sprite p4ImgSmall;

    public GameObject cheatImageShow;
    public GameObject cheatImageShowButton;

    public GameObject logo;
    public GameObject startButton;
    public GameObject endLogo;

    [SerializeField] GameObject[] cheatObjects;

    private GameObject[] usedPuzzle;
    [SerializeField] GameObject[] endObjects;

    private int score = 0;
    private Vector3 initialScale = new Vector3(0.1f,0.1f,0.1f);
    private Vector3 targetScale = new Vector3(1f, 1f, 1f);
    private float lerpTime = 3.0f;

    public void Start()
    {
        StartCoroutine(PopInAnimation(logo));
        StartCoroutine(PopInAnimation(startButton));

        string startVidPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Back Ground 2.mp4");
        startVideoPlayer.url = startVidPath;
        startVideoPlayer.Play();
    }

    public void SelectScreen()
    {
        foreach (GameObject obj in startObjects)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in selectObjects)
        {
            obj.SetActive(true);
        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2.0f);

        EndScreen();
    }

    private IEnumerator PopInAnimation(GameObject obj)
    {
        obj.transform.localScale = initialScale;
        float currentLerpTime = 0f;

        while (currentLerpTime < lerpTime)
        {
            currentLerpTime += Time.deltaTime;
            float perc = currentLerpTime / lerpTime;
            obj.transform.localScale = Vector3.Lerp(initialScale, targetScale, perc);
            yield return null;
        }

        // Ensure the final scale is exactly the target scale
        transform.localScale = targetScale;

    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene("SampleScene");
    }

        public void AddScore()
    {
        score++;

        if(score == 15)
        {
            StartCoroutine(EndGame());
        }
    }

    public void CloseCheat()
    {
        foreach (GameObject obj in cheatObjects)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in puzzleObjects)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in usedPuzzle)
        {
            obj.SetActive(true);
        }
    }

    public void CheatScreen()
    {
        foreach (GameObject obj in puzzleObjects)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in usedPuzzle)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in cheatObjects)
        {
            obj.SetActive(true);
        }
    }

    public void EndScreen()
    {
        foreach (GameObject obj in cheatObjects)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in puzzleObjects)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in usedPuzzle)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in endObjects)
        {
            obj.SetActive(true);
        }
        
        StartCoroutine(PopInAnimation(endLogo));

        StartCoroutine(RestartGame());
    }

    public void Puzzle()
    {
        foreach (GameObject obj in selectObjects)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in puzzleObjects)
        {
            obj.SetActive(true);
        }
    }

    public void Puzzle1()
    {
        Puzzle();
        foreach (GameObject obj in puzzle1Objects)
        {
            obj.SetActive(true);
        }
        usedPuzzle = puzzle1Objects;

        cheatImageShow.GetComponent<SpriteRenderer>().sprite = p1Img;
        cheatImageShowButton.GetComponent<SpriteRenderer>().sprite = p1ImgSmall;
    }

    public void Puzzle2()
    {
        Puzzle();
        foreach (GameObject obj in puzzle2Objects)
        {
            obj.SetActive(true);
        }
        usedPuzzle = puzzle2Objects;

        cheatImageShow.GetComponent<SpriteRenderer>().sprite = p2Img;
        cheatImageShowButton.GetComponent<SpriteRenderer>().sprite = p2ImgSmall;
    }

    public void Puzzle3()
    {
        Puzzle();
        foreach (GameObject obj in puzzle3Objects)
        {
            obj.SetActive(true);
        }
        usedPuzzle = puzzle3Objects;

        cheatImageShow.GetComponent<SpriteRenderer>().sprite = p3Img;
        cheatImageShowButton.GetComponent<SpriteRenderer>().sprite = p3ImgSmall;
    }

    public void Puzzle4()
    {
        Puzzle();
        foreach (GameObject obj in puzzle4Objects)
        {
            obj.SetActive(true);
        }
        usedPuzzle = puzzle4Objects;

        cheatImageShow.GetComponent<SpriteRenderer>().sprite = p4Img;
        cheatImageShowButton.GetComponent<SpriteRenderer>().sprite = p4ImgSmall;
    }

}

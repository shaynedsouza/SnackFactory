using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using underDOGS.SDKEvents;
public class GameManager : MonoBehaviour
{

    #region SingleTon
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion



    [Header("Cameras")]
    public GameObject Starting_Cam;
    public GameObject Peeling_Machine_Cam_Show;
    public GameObject Peeling_MachinecamFollow;
    public GameObject FriesCam;
    public GameObject FriesCamFollow;
    public GameObject FriesFrying;
    public GameObject FriesFryingFollow;
    public GameObject FinalCameraAngle;

    [Header("Parents")]
    public Transform objectParent;
    public Transform peeledParent;
    public Transform friesParent;
    public Transform FriesFryerParent;

    [Header("Spawnner GameObjects")]
    public Transform startingTrackerSpawnner;
    public Transform PeeledTrackerSpawnner;
    public Transform FriesTrackerSpawnner;
    public Transform FriesFryerTrackerSpawnner;

    [Header("Trackers GameObjects")]
    public GameObject startingTracker;
    public GameObject peelingTracker;
    public GameObject friesTrackre;
    public GameObject friesFryingTracker;

    [Header("Setups")]
    public GameObject StartingScene;
    public GameObject PeelingScene;
    public GameObject FriesScene;
    public GameObject FriesFryerScene;
    public GameObject lastSetup;


    [Header("Belts")]
    public ConveyorBelt[] conveyorBelt;




    [Header("Misc")]
    public GameObject confetti;
    int levelNo;
    private void Start()
    {
        FriesScene.SetActive(false);
        FriesFryerScene.SetActive(false);
        lastSetup.SetActive(false);
        levelNo = PlayerPrefs.GetInt("LEVELNO", 1);
        CanvasManager.Instance.SetLevel(levelNo);

        if (SDKManager.instance != null)
        {
            SDKEventData endData;
            endData.level = levelNo;
            endData.status = "start";
            SDKManager.instance.SendEvent(endData);
        }


    }

    public void ChangeCameraToPeeligMachine()
    {
        stopMovingBelt();
        Starting_Cam.SetActive(false);
        Peeling_Machine_Cam_Show.SetActive(true);
        //ConveyorBelt.Instance.startMove = true;
    }

    public void ChangeCameraToPeelingFollow()
    {
        StartMovingBelt();
        peelingTracker.SetActive(true);
        Peeling_Machine_Cam_Show.SetActive(false);
        Peeling_MachinecamFollow.SetActive(true);
        StartCoroutine(hidePeelingMachine());
    }

    public void ChangeCameraToFrieMachine()
    {
        stopMovingBelt();
        Peeling_MachinecamFollow.SetActive(false);
        FriesCam.SetActive(true);
    }

    public void ChangeCameraToFriesFollow()
    {
        StartMovingBelt();
        friesTrackre.SetActive(true);
        FriesFryerScene.SetActive(true);
        PeelingScene.SetActive(false);
        FriesCam.SetActive(false);
        FriesCamFollow.SetActive(true);
    }

    public void ChangeCameraToFriesFrying()
    {
        stopMovingBelt();
        FriesCamFollow.SetActive(false);
        FriesFrying.SetActive(true);
    }

    public void ChangeCameraToFriesFryingFollow()
    {
        StartMovingBelt();
        FriesScene.SetActive(false);
        lastSetup.SetActive(true);
        FriesFrying.SetActive(false);
        friesFryingTracker.SetActive(true);
        FriesFryingFollow.SetActive(true);
        //StartingScene.SetActive(false);
    }

    public void ChangeToFinalCameraAngle()
    {
        friesFryingTracker.SetActive(false);
        FriesFryingFollow.SetActive(false);
        FinalCameraAngle.SetActive(true);
        FriesFryingCount.Instance.isFinalScene = true;
    }

    IEnumerator hidePeelingMachine()
    {
        yield return new WaitForSeconds(0.2f);
        StartingScene.SetActive(false);
        FriesScene.SetActive(true);
    }

    void stopMovingBelt()
    {
        for (int i = 0; i < conveyorBelt.Length; i++)
        {
            conveyorBelt[i].startMove = true;
        }
    }

    void StartMovingBelt()
    {
        for (int i = 0; i < conveyorBelt.Length; i++)
        {
            conveyorBelt[i].startMove = false;

        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameWon()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.win);
        confetti.SetActive(true);
        CanvasManager.Instance.GameWon();
        if (SDKManager.instance != null)
        {
            SDKEventData endData;
            endData.level = levelNo;
            endData.status = "complete";
            SDKManager.instance.SendEvent(endData);
        }
        PlayerPrefs.SetInt("LEVELNO", levelNo + 1);
        PlayerPrefs.Save();

        for (int i = 0; i < conveyorBelt.Length; i++)
        {
            conveyorBelt[i].canMove = false;
        }
    }
    public void GameOver()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.lose, 0.1f);
        CanvasManager.Instance.GameLost();
        if (SDKManager.instance != null)
        {
            SDKEventData endData;
            endData.level = levelNo;
            endData.status = "fail";
            SDKManager.instance.SendEvent(endData);
        }


        for (int i = 0; i < conveyorBelt.Length; i++)
        {
            conveyorBelt[i].canMove = false;
        }
    }

}

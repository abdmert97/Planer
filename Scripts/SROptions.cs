
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SROptions
{
    
    [Category("PlaneController")]
    public bool VerticalControl
    {
        get => GameManager.Instance.planeController.vertical;
        set => GameManager.Instance.planeController.vertical = value;
    }

    [Category("PlaneController")]
    public float Sensivity
    {
        get => GameManager.Instance.planeController.distanceMultiplier;
        set => GameManager.Instance.planeController.distanceMultiplier = value;
    }
    
    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }

    [Category("CameraSettings")]
    public CameraSwitch.CameraType changeCamera
    {
        get => GameManager.Instance.cameraSwitch.activeCamera;
        set => GameManager.Instance.cameraSwitch.SwitchCamera(value);
    }
    [Category("MainCameraSettings")]
    public float CameraAngle
    {
        get => GameManager.Instance.cameraController.angle;
        set => GameManager.Instance.cameraController.angle = value;
    }
    [Category("MainCameraSettings")]
    public float CameraDistance
    {
        get => GameManager.Instance.cameraController.distance;
        set => GameManager.Instance.cameraController.distance = value;
    }
    [Category("AISettings")]
    public bool EnableAI
    {
        get => GameManager.Instance.botController.EnableBot;
        set => GameManager.Instance.botController.EnableBot = value;
    }
    [Category("AISettings")]
    public int AIStartPosition
    {
        get => GameManager.Instance.botController.StartPosition;
        set => GameManager.Instance.botController.StartPosition = value;
    }
    [Category("AISettings")]
    public float AISpeed
    {
        get => GameManager.Instance.botController.followSpeed;
        set => GameManager.Instance.botController.followSpeed = value;
    }
   /* public bool isSeasonDirty = false;
    public bool isCustomLevel = false;

    [Category("Level")]
    public bool IsCustomLevel
    {
        get { return isCustomLevel; }
        set 
        {
            isCustomLevel = value;
            isSeasonDirty = true;
        }
    }

    [NumberRange(1, 100)]
    [Category("Level")]
    [DisplayName("Current Level")]
    public int CurrentLevel
    {
        get { return LevelManager.CustomLevelID; }
        set
        {
            //SeasonManager.ForceChangeSeasonDatas(value, 1);
            LevelManager.CustomLevelID = value;
            isSeasonDirty = true;
        }
    }

    [Category("Level")]
    public string LevelConfig
    {
        get { return LevelManager.CustomLevelConfig; }
        set
        {
            LevelManager.CustomLevelConfig = value;
            isSeasonDirty = true;
        }
    }

    [Category("Game Play")]
    [DisplayName("Perfect Jump Enabled")]
    public bool IsPerfectJumpEnabled
    {
        get => FirebaseController.PerfectJumpEnabled;
        set => FirebaseController.PerfectJumpEnabled = value;
    }

    [Category("Save")]
    [DisplayName("Reset Save")]
    public void ResetSave()
    {
        SeasonManager.ResetSeasonSaveDatas();
        isSeasonDirty = true;
    }

    [NumberRange(0, 1)]
    [Category("Theme")]
    public int CharacterID
    {
        get { return ThemeChanger.Instance.ActiveCharacterID; }
        set { ThemeChanger.Instance.ChangeCharacterMesh(value); }
    }

    [NumberRange(8, 100)]
    [Category("Player")]
    public float PlayerMaxSpeed
    {
        get { return GameManager.Instance.controllerData.playerMaxSpeed; }
        set { GameManager.Instance.controllerData.playerMaxSpeed = value; }
    }

    [NumberRange(1, 9)]
    [Category("Player")]
    public int MinRankToWin
    {
        get { return ((BasicEliminationController)SeasonManager.ActiveEliminationController).MinWinnerRank; }
        set { ((BasicEliminationController)SeasonManager.ActiveEliminationController).ChangeMinWinnerRank(value); }
    }

    [NumberRange(1, 15)]
    [Category("AI")]
    public int AICountPerStage
    {
        get { return ((BasicEliminationController)SeasonManager.ActiveEliminationController).OpponentCountPerStage; }
        set { ((BasicEliminationController)SeasonManager.ActiveEliminationController).ChangeOpponentCountPerStage(value); }
    }

    [NumberRange(8, 100)]
    [Category("AI")]
    public float AIMaxSpeed
    {
        get { return GameManager.Instance.controllerData.aiMaxSpeed; }
        set
        {
            GameManager.Instance.controllerData.aiMaxSpeed = value;
            GamePlayManager.Instance.aiCentralManager.UpdateAISpeeds();
        }
    }

    [NumberRange(0, 50)]
    [Category("AI")]
    public float AISpeedVariationAmount
    {
        get { return GameManager.Instance.controllerData.aiSpeedVariationAmount; }
        set
        {
            GameManager.Instance.controllerData.aiSpeedVariationAmount = value;
            GamePlayManager.Instance.aiCentralManager.UpdateAISpeeds();
        }
    }

    [NumberRange(1, 250)]
    [Category("AI")]
    public float AIMaxStartDistance
    {
        get { return GameManager.Instance.controllerData.aiMaxStartDistance; }
        set { GameManager.Instance.controllerData.aiMaxStartDistance = value; }
    }

    [NumberRange(1, 100)]
    [Category("AI")]
    public int AIMaxStartLevelPercentage
    {
        get { return GameManager.Instance.controllerData.aiMaxStartLevelPercentage; }
        set { GameManager.Instance.controllerData.aiMaxStartLevelPercentage = value; }
    }

    [Category("AI - Catchup")]
    public bool IsCatchupEnabled
    {
        get { return GameManager.Instance.controllerData.isCatchupEnabled; }
        set { GameManager.Instance.controllerData.isCatchupEnabled = value; }
    }

    [NumberRange(1, 30)]
    [Category("AI - Catchup")]
    public float CatchupCheckTimeInterval
    {
        get { return GameManager.Instance.controllerData.catchupCheckTimeInterval; }
        set { GameManager.Instance.controllerData.catchupCheckTimeInterval = value; }
    }

    [NumberRange(1, 30)]
    [Category("AI - Catchup")]
    public int CatchupRespawnedAICount
    {
        get { return GameManager.Instance.controllerData.catchupRespawnedAICount; }
        set { GameManager.Instance.controllerData.catchupRespawnedAICount = value; }
    }

    [NumberRange(1, 30)]
    [Category("AI - Catchup")]
    public int RankRequiredForCatchup
    {
        get { return GameManager.Instance.controllerData.rankRequiredForCatchup; }
        set { GameManager.Instance.controllerData.rankRequiredForCatchup = value; }
    }

    [NumberRange(1, 100)]
    [Category("AI - Catchup")]
    public float DistanceRequiredForCatchup
    {
        get { return GameManager.Instance.controllerData.distanceRequiredForCatchup; }
        set { GameManager.Instance.controllerData.distanceRequiredForCatchup = value; }
    }

    [NumberRange(1, 100)]
    [Category("AI - Catchup")]
    public float CatchupRespawnDistance
    {
        get { return GameManager.Instance.controllerData.catchupRespawnDistance; }
        set { GameManager.Instance.controllerData.catchupRespawnDistance = value; }
    }

    [NumberRange(1, 3)]
    [Category("AI - Catchup")]
    public float CatchupBoostFactor
    {
        get { return GameManager.Instance.controllerData.catchupBoostFactor; }
        set { GameManager.Instance.controllerData.catchupBoostFactor = value; }
    }

    [NumberRange(0, 10)]
    [Category("AI - Catchup")]
    public float CatchupBoostDuration
    {
        get { return GameManager.Instance.controllerData.catchupBoostDuration; }
        set { GameManager.Instance.controllerData.catchupBoostDuration = value; }
    }

    [NumberRange(1, 50)]
    [Category("AI - Catchup")]
    public float CatchupBoostDeceleration
    {
        get { return GameManager.Instance.controllerData.catchupBoostDeceleration; }
        set { GameManager.Instance.controllerData.catchupBoostDeceleration = value; }
    }

    [NumberRange(1, 300)]
    [Category("AI - Catchup")]
    public float CatchupDisabledFinalDistance
    {
        get { return GameManager.Instance.controllerData.catchupDisabledFinalDistance; }
        set { GameManager.Instance.controllerData.catchupDisabledFinalDistance = value; }
    }

    [Category("AI")]
    public bool AINameTagsEnabled
    {
        get { return GamePlayManager.Instance.IsAINameTagsEnabled; }
        set { GamePlayManager.Instance.SetIsAINameTagsEnabled(value); }
    }

    [Category("Real AI")]
    public bool IsRealAIEnabled
    {
        get { return GameManager.Instance.controllerData.isRealAI; }
        set { GameManager.Instance.controllerData.isRealAI = value; }
    }

    [Category("Real AI")]
    [DisplayName("Reset Power")]
    public void ResetRealAIPower()
    {
        ResetRealAIPower();
    }

*/
}

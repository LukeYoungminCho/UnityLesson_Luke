using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region 싱글톤
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
        scoreText.text = "0";
        foreach (HitEffectData data in hitEffectList)
        {
            data.screenEffect.SetActive(false);
        }
    }
    #endregion

    public VideoPlayer videoPlayer;
    public ScoringText scoreText;
    public List<HitEffectData> hitEffectList;

    public int score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            scoreText.value = value;
        }
    }
    private int _score;
    private List<MakingNoteData> makingNoteDatas;

    private void Start()
    {
        SelectSongJsonFile();
    }
    public void SelectSongJsonFile()
    {
        string targetDirectory = EditorUtility.OpenFilePanel("재생할 노래 Json 파일을 선택하세요", "", "json");
        string json = System.IO.File.ReadAllText(targetDirectory);
        SongData data = JsonUtility.FromJson<SongData>(json);
        PlayGame(data);
    }

    public void PlayGame(SongData songData)
    {
        //todo -> 게임 초기화 , 비디오플레이
        //
        makingNoteDatas = songData.datas;
        videoPlayer.Play();

    }

    Dictionary<GameObject, Coroutine> hitEffectCoroutineDic = new Dictionary<GameObject, Coroutine>();
    public void OnHitNote(eHitPercent eHit)
    {
        foreach (HitEffectData data in hitEffectList)
        {
            if(data.hitPercent != eHit)
            {
                continue;
            }
            data.screenEffect.SetActive(true);

            if (hitEffectCoroutineDic.ContainsKey(data.screenEffect))
            {
                StopCoroutine(hitEffectCoroutineDic[data.screenEffect]);
                hitEffectCoroutineDic[data.screenEffect] = null;
            }
            hitEffectCoroutineDic[data.screenEffect] = StartCoroutine(DelayDeactive(data.screenEffect , 2f));

            score += data.score;
        }
    }

    IEnumerator DelayDeactive(GameObject _screenEffect, float delayTime)
    {

    }


    private void Update()
    {
        if (makingNoteDatas != null)
        {
            float alphaTime = NoteManager.spawnDistance / NoteManager.noteSpeed;

            List<MakingNoteData> targetNotes = new List<MakingNoteData>();

            foreach (MakingNoteData data in makingNoteDatas)
            {
                if(data.time - alphaTime <= videoPlayer.clockTime)
                {
                    targetNotes.Add(data);
                    NoteManager.Instance.SpawnNote(data.keyCode);
                }
            }

            foreach (MakingNoteData data in targetNotes) // data를 지우면서 foreach 문을 돌리면 위험한 구조기 때문에 foreach 두개로 나눔
            {
                makingNoteDatas.Remove(data);
            }
        }

        // go to main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
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

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class MakingNoteManager : MonoBehaviour
{
    public SongData songData;
    public KeyCode[] keyCodes = new KeyCode[] { KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.Space, KeyCode.J, KeyCode.K, KeyCode.L };
    public VideoPlayer videoPlayer;

    private void Update()
    {
        foreach (KeyCode target in keyCodes) // 한영키 구분함!
        {
            if (Input.GetKeyDown(target))
            {
                MakeNoteData(target);
            }
        }

        if (Input.GetKeyDown(KeyCode.Insert))
        {
            SaveData();
        }
    }

    private void MakeNoteData(KeyCode targetCode)
    {
        MakingNoteData data = new MakingNoteData();
        data.keyCode = targetCode;
        data.time = (float)videoPlayer.time;
        songData.datas.Add(data);
    }

    public void SaveData()
    {
       // Insert 키를 누르면 디렉토리 설정창이 뜨고 선택시 디렉토리 문자열을 반환함(실제 파일을 저장하진 않는다)
       string saveDirectory =  EditorUtility.SaveFilePanel("저장할 곳을 지정하세여", "", $"{songData.title} - {songData.singer}", "json");
       // 디렉토리 설정한곳에 파일을 저장한다
       System.IO.File.WriteAllText(saveDirectory, JsonUtility.ToJson(songData));
       //Serialize: 클래스(오브젝트)들을 텍스트로 변환시켜서 저장하는 행위.  Json, XML 등의 포맷이있다.. 
       //Deserialize: 텍스트를 클래스로 변환해주는 작업. 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHitterManager : MonoBehaviour
{
    #region 싱글톤
    public static NoteHitterManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<NoteHitterManager>();
            return _instance;
        }
    }
    private static NoteHitterManager _instance;
    #endregion

    public List<NoteHitter> noteHitters;

    public NoteHitter GetNoteHitter(KeyCode keyCode)
    {
        foreach (NoteHitter noteHitter in noteHitters)
        {
            if (noteHitter.targetKeyCode == keyCode)
            {
                return noteHitter;
            }
        }
        Debug.LogError($"키코드가 잘못 들어왔습니다. {keyCode} 키 입력받음");
        return null;
    }
}

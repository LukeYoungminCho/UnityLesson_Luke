using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    #region SingleTon
    public static NoteManager Instance;    
    private void Awake()
    {
        if(Instance == null)
        Instance = this;
    }
    #endregion

    public static float spawnDistance = 400f;
    public static float noteSpeed = 100f;

    public Note notePrefab;
    public Transform noteParent;
    public List<Note> notes = new List<Note>();
    
    public void SpawnNote(KeyCode keyCode)
    {
        NoteHitter noteHitter = NoteHitterManager.Instance.GetNoteHitter(keyCode);

        GameObject noteObject = Instantiate(notePrefab.gameObject, noteParent);
        noteObject.transform.position = noteHitter.transform.position + Vector3.up * spawnDistance;
        //noteObject.transform.SetParent(noteParent); //?
        noteObject.transform.localScale = Vector3.one;

        Note script = noteObject.GetComponent<Note>();
        script.targetKeyCode = keyCode;
    }

}

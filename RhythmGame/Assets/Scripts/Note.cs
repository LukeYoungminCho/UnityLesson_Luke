using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    
    public KeyCode targetKeyCode;
    private float height = 0;

    private void Start()
    {
        NoteManager.Instance.notes.Add(this);        
    }
    void Update()
    {
        transform.Translate(Vector2.down * NoteManager.noteSpeed * Time.deltaTime);

        if (Input.GetKeyDown(targetKeyCode))
        {
            NoteHitter targetHitter = NoteHitterManager.Instance.GetNoteHitter(targetKeyCode);

            // todo -> local 좌표로 height 를 사용하고있는데 현재 canvas 스케일이 달라서 거리에 문제가있음. World 좌표값으로 height 구해서 적용해야함./
            if (targetHitter.canHit == true)
            {
                float distance = Vector2.Distance(this.transform.position, targetHitter.transform.position);
                float hitPercent = distance - targetHitter.targetImage.rectTransform.rect.height;

                if (hitPercent <= 0)
                {
                    targetHitter.canHit = false;
                    Hitted();
                }
            }
            
        }
    }

    public void Hitted()
    {
        Destroy(this.gameObject);
        NoteManager.Instance.notes.Remove(this);
    }
}

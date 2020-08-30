using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor.UI;
using UnityEngine;

public class Note : MonoBehaviour
{
    public KeyCode targetKeycode;
    private float height = 0;
    private float maxRange;
    private float minRange;

    private void Start()
    {
        NoteManager.Instance.notes.Add(this);
    }

    void Update()
    {
        NoteMove();
        CheckHit();
    }

    private void NoteMove()
    {
        transform.Translate(Vector2.down * NoteManager.noteSpeed * Time.deltaTime);
        if(transform.localPosition.y < -500f)
        {
            GameManager.Instance.OnHitNote(eHitPercent.Miss);
            Destroy(this.gameObject);
            NoteManager.Instance.notes.Remove(this);
            
        }
    }

    private void CheckHit()
    {
        if (Input.GetKey(targetKeycode))
        {
            NoteHitter targetHitter = NoteHitterManager.Instance.GetNoteHitter(targetKeycode);

            if (height == 0) /// 월드 좌표 기준으로 hitterHeight 설정
            {
                Vector3[] wCorners = new Vector3[4];
                targetHitter.targetImage.rectTransform.GetWorldCorners(wCorners);
                ///bl - tl - tr - br
                height = wCorners[1].y - wCorners[0].y;
                minRange = -height;
                maxRange = height;
            }

            if (targetHitter.canHit == true)
            {
                float dist = (this.transform.position.y - targetHitter.targetImage.rectTransform.position.y);

                float hitPercent = dist - height;

                if (hitPercent <= height * 0.5f && hitPercent >= -height) // 딱 영역안
                {
                    targetHitter.canHit = false;
                    Hitted(dist);
                    Debug.Log($"Hitted ! - {dist} - {height}");
                }
            }
        }
    }

    public void Hitted(float dist)
    {
        float hitPercent = (height - dist) / height;

        Destroy(this.gameObject);
        NoteManager.Instance.notes.Remove(this);
        GameManager.Instance.score += 100;
    }
}

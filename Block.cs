using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] GameObject blockParticleVFX;
    [SerializeField] Sprite[] blockSprites;

    Level level;
    int hits;

    public object SpriteRende { get; private set; }

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if(tag == "Breakable")
        level.CountBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (tag == "Breakable")
        {
            HandleHits();
        }
        else if (tag == "Unbreakable")
        {
            return;
        }
    }

    private void HandleHits()
    {
        hits++;
        if (hits == (blockSprites.Length + 1))
        {
            DestryBlock();
        }
        else
        {
            ShowSprites();
        }
    }

    private void ShowSprites()
    {
        int spriteIndex = (hits - 1) % (blockSprites.Length+1);
        GetComponent<SpriteRenderer>().sprite = blockSprites[spriteIndex];
    }

    private void DestryBlock()
    {
        SoundVFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        ParticleVFX();
    }

    private void SoundVFX()
    {
        FindObjectOfType<GameSession>().UpdateScore();
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 1f);
    }

    private void ParticleVFX()
    {
        GameObject particleVFX = Instantiate(blockParticleVFX,transform.position,transform.rotation);
        Destroy(particleVFX, 1f);
    }

}

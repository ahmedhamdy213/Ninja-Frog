using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollcter : MonoBehaviour
{
    private int oranges = 0;
    [SerializeField] private Text orangesText;
    [SerializeField] private AudioSource CollectionSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("orange"))
        {
            CollectionSoundEffect.Play();
            Destroy(collision.gameObject);
            oranges++;
            orangesText.text = "oranges: " + oranges;
        }
    }
}

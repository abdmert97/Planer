using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines.Primitives;
using TMPro;
using UnityEngine;

public class WayPointEffect : MonoBehaviour
{
   public SpriteRenderer _spriteRenderer1;
   public SpriteRenderer _spriteRenderer2;
   private Vector3 _defaultScale;
   private float defaultFont;
   private Color _startColor;
   public TextMeshPro _textMeshPro;
   private Color _startColorText;
   private void Start()
   {
   
       
       
         _startColor = _spriteRenderer1.color; 
         _startColorText = _textMeshPro.color; 

    
      _defaultScale = _spriteRenderer1.transform.localScale;
      defaultFont = _textMeshPro.fontSize;
     
   }

   private void OnTriggerEnter(Collider other)
   {
      StartCoroutine(FadeEffect());
   }
   private IEnumerator FadeEffect()
   {

      for (int i = 0; i < 40; i++)
      {
           _textMeshPro.color -= Color.black*0.04f;
            _spriteRenderer1.color -= Color.black*0.04f;
            _spriteRenderer2.color -= Color.black*0.04f;
      
            _spriteRenderer1.transform.localScale += (Vector3.one *  0.06f);
            _spriteRenderer2.transform.localScale += (Vector3.one *  0.06f);
            _textMeshPro.fontSize += 0.5f;
            yield return null;
      }
      Invoke(nameof(Activate),7f);
   }

   void Activate()
   {
      _spriteRenderer1.transform.localScale = _defaultScale;
      _spriteRenderer2.transform.localScale = _defaultScale;
      _textMeshPro.fontSize = defaultFont;
      
      _spriteRenderer1.color = _startColor;
      _spriteRenderer2.color = _startColor;
      _textMeshPro.color = _startColorText;
   }

}

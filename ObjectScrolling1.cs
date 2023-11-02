using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RareCoders
{
    public class ObjectScrolling1 : MonoBehaviour
    {
        public float scrollSpeed;

        private Renderer _renderer;
        private Vector2 savedOffset;

        private void OnEnable()
        {
            _renderer = GetComponent<Renderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (TheGlobals1.playingMode)
            {
                float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
                Vector2 offset = new Vector2(0, y);
                _renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
            }
        }
    }
}
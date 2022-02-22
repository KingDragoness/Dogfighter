using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityUtilities;

namespace Dogfighter
{
    public class WindowTweenSize : MonoBehaviour
    {
        public Vector2 SizeTarget;
        public float minimumYStart = 40;
        public float duration = 1;

        private void Awake()
        {
            
        }

        private void OnEnable()
        {
            var rectTransform = GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(0, minimumYStart);
            TweeningOperation(SizeTarget);
        }

        public async void TweeningOperation(Vector2 size)
        {
            var tasks = new Task[2];
            tasks[0] = ResizeTarget(new Vector2(size.x, minimumYStart), duration);
            await tasks[0];
            tasks[1] = ResizeTarget(new Vector2(size.x, size.y), duration);
            await tasks[1];

            await Task.WhenAll(tasks);

            //Debug.Log("Tweening done");
        }

        public async Task ResizeTarget(Vector2 size, float duration)
        {
            var end = Time.unscaledTime + duration;
            var end1 = Time.unscaledTime + (duration / 2f);
            var startPoint = Time.unscaledTime;
            var rectTransform = GetComponent<RectTransform>();

            while(Time.unscaledTime < end)
            {
                var origin = rectTransform.sizeDelta;
                var target = size;

                var delta =(Time.unscaledTime - startPoint) / (duration * 2);
                var point1 = Vector2.Lerp(origin, target, delta);

                rectTransform.sizeDelta = point1;

                await Task.Yield();
            }

            rectTransform.sizeDelta = size;

        }

    }
}
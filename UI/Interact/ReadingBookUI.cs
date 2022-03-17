using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pragma;

namespace Dogfighter
{

    public class ReadingBookUI : BaseInteractUI
    {

        public Image bookPage_Cover;
        public Image bookPage_L;
        public Image bookPage_R;
        public ReadableBookObj currentReadableBook;
        private int currentIndex = 0;

        public void OnEnable()
        {
            LoadBook();
            LoadPage();

        }

        public override void ExitUI()
        {
            base.ExitUI();
        }

        private void LoadBook()
        {
            currentIndex = 0;
        }

        public void NextPage()
        {
            if (currentIndex == 0)
            {
                currentIndex++;
            }
            else
            {
                currentIndex += 2;
            }

            if (currentIndex >= currentReadableBook.paperSprites.Count)
            {
                currentIndex = currentReadableBook.paperSprites.Count - 1;
            }

            LoadPage();
        }

        public void BackPage()
        {
            currentIndex -= 2;

            if (currentIndex <= 0)
            {
                currentIndex = 0;
            }

            LoadPage();
        }

        private void LoadPage()
        {
            //index 0 is front page
            if (currentIndex == 0)
            {
                bookPage_Cover.gameObject.SetActive(true);
                bookPage_L.gameObject.SetActive(false);
                bookPage_R.gameObject.SetActive(false);
                bookPage_Cover.sprite = currentReadableBook.paperSprites[0];

            }
            else
            {
                bookPage_Cover.gameObject.SetActive(false);
                bookPage_L.gameObject.SetActive(true);
                bookPage_R.gameObject.SetActive(true);

                var pageL = currentReadableBook.paperSprites[currentIndex];

                if (currentIndex + 1< currentReadableBook.paperSprites.Count)
                {
                    var pageR = currentReadableBook.paperSprites[currentIndex + 1];
                    bookPage_R.sprite = currentReadableBook.paperSprites[currentIndex + 1];
                }
                else
                {
                    bookPage_R.sprite = null;
                }

                bookPage_L.sprite = pageL;

            }


        }

    }

}
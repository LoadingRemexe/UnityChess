using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityChess;
using System.Linq;

namespace Tests
{
    public class Bishops
    {
        [UnityTest]
        public IEnumerator BishopsWithEnumeratorPasses()
        {
            UnityEditor.SceneManagement.EditorSceneManager.LoadScene("Board"); // Open Board

            yield return new WaitForSeconds(4f); // Wait For Load
            
            GameManager.Instance.is960 = true; // Set Mode
            UIManager.Instance.StartNewGame(0); // Start and Place peices

            yield return new WaitForSeconds(4f); // Wait for load

            List<VisualPiece> bishops = GameObject.FindObjectsOfType<VisualPiece>().Where(go => go.name.Contains("Bishop")).ToList();
            Assert.AreEqual(4, bishops.Count); // Four bishops total


            //Check placements
            int whitebishops = 0;
            int blackbishops = 0;
            int lightbishops = 0;
            int darkbishops = 0;
            foreach (VisualPiece vp in bishops)
            {
                if (vp.PieceColor == Side.White) whitebishops++; else blackbishops++;
                if (vp.CurrentSquare.File % 2 == 0) lightbishops++; else darkbishops++;
            }
            Assert.AreEqual(2, whitebishops);
            Assert.AreEqual(2, blackbishops);
            Assert.AreEqual(2, lightbishops);
            Assert.AreEqual(2, darkbishops);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityChess;
using System.Linq;

namespace Tests
{
    public class Queens
    {
        [UnityTest]
        public IEnumerator QueensWithEnumeratorPasses()
        {
            UnityEditor.SceneManagement.EditorSceneManager.LoadScene("Board"); // Open Board

            yield return new WaitForSeconds(4f); // Wait For Load

            GameManager.Instance.is960 = true; // Set Mode
            UIManager.Instance.StartNewGame(0); // Start and Place peices

            yield return new WaitForSeconds(4f); // Wait for load

            List<VisualPiece> queens = GameObject.FindObjectsOfType<VisualPiece>().Where(go => go.name.Contains("Queen")).ToList();
            Assert.AreEqual(2, queens.Count); // two queens

            //Check placements
            int whiteQueen = 0;
            int blackqueen = 0;
            foreach (VisualPiece vp in queens)
            {
                if (vp.PieceColor == Side.White) whiteQueen++; else blackqueen++;
            }
            Assert.AreEqual(1, whiteQueen);
            Assert.AreEqual(1, blackqueen);
        }
    }
}

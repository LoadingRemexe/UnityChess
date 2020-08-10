using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityChess;
using System.Linq;
namespace Tests
{
    public class Knights
    {
      
        [UnityTest]
        public IEnumerator KnightsWithEnumeratorPasses()
        {
            UnityEditor.SceneManagement.EditorSceneManager.LoadScene("Board"); // Open Board

            yield return new WaitForSeconds(4f); // Wait For Load

            GameManager.Instance.is960 = true; // Set Mode
            UIManager.Instance.StartNewGame(0); // Start and Place peices

            yield return new WaitForSeconds(4f); // Wait for load

            List<VisualPiece> Knights = GameObject.FindObjectsOfType<VisualPiece>().Where(go => go.name.Contains("Knight")).ToList();
            Assert.AreEqual(4, Knights.Count); // Four Knights total


            //Check placements
            int whiteKnights = 0;
            int blackKnights = 0;
            foreach (VisualPiece vp in Knights)
            {
                if (vp.PieceColor == Side.White) whiteKnights++; else blackKnights++;
            }
            Assert.AreEqual(2, whiteKnights);
            Assert.AreEqual(2, blackKnights);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityChess;
using System.Linq;
namespace Tests
{
    public class Mirror
    {
   
        [UnityTest]
        public IEnumerator MirrorWithEnumeratorPasses()
        {
            UnityEditor.SceneManagement.EditorSceneManager.LoadScene("Board"); // Open Board

            yield return new WaitForSeconds(4f); // Wait For Load

            GameManager.Instance.is960 = true; // Set Mode
            UIManager.Instance.StartNewGame(0); // Start and Place peices

            yield return new WaitForSeconds(4f); // Wait for load

            List<VisualPiece> WhitePeices = GameObject.FindObjectsOfType<VisualPiece>().Where(go => go.PieceColor == Side.White 
                    && !(go.name.Contains("Pawn"))).ToList(); // remove pawns
            Assert.AreEqual(8, WhitePeices.Count); // White Peices

            List<VisualPiece> BlackPeices = GameObject.FindObjectsOfType<VisualPiece>().Where(go => go.PieceColor == Side.Black 
                    && !(go.name.Contains("Pawn"))).ToList(); // remove pawns
            Assert.AreEqual(8, BlackPeices.Count); // Black Peices

            foreach(VisualPiece vp in WhitePeices)
            {
                VisualPiece mirrored = BlackPeices.Where(v => v.CurrentSquare.File == vp.CurrentSquare.File).FirstOrDefault();
                Assert.IsNotNull(mirrored); //found peice on opposite side

                string whitename = vp.gameObject.name.Replace("White ", ""); // remove color from name to be left with peice type
                string blackname = mirrored.gameObject.name.Replace("Black ", "");

                Assert.AreEqual(whitename, blackname);
            }

        }
    }
}

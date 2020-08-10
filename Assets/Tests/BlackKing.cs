using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityChess;
using System.Linq;
namespace Tests
{
    public class BlackKing
    {
        [UnityTest]
        public IEnumerator BlackKingWithEnumeratorPasses()
        {
            UnityEditor.SceneManagement.EditorSceneManager.LoadScene("Board"); // Open Board

            yield return new WaitForSeconds(4f); // Wait For Load

            GameManager.Instance.is960 = true; // Set Mode
            UIManager.Instance.StartNewGame(0); // Start and Place peices

            yield return new WaitForSeconds(4f); // Wait for load

            VisualPiece King = GameObject.FindObjectsOfType<VisualPiece>().Where(go => go.name.Contains("King") && go.PieceColor == Side.Black).FirstOrDefault();
            Assert.NotNull(King); //One black King
            List<VisualPiece> Rooks = GameObject.FindObjectsOfType<VisualPiece>().Where(go => go.name.Contains("Rook") && go.PieceColor == Side.Black).ToList();
            Assert.AreEqual(2, Rooks.Count); // two black Rooks


            bool KingBetweenRooks = false;
            KingBetweenRooks = (Rooks[0].CurrentSquare.File < King.CurrentSquare.File && King.CurrentSquare.File < Rooks[1].CurrentSquare.File) // if rook a is left of rook b
                || (Rooks[1].CurrentSquare.File < King.CurrentSquare.File && King.CurrentSquare.File < Rooks[0].CurrentSquare.File);// if rook b is left of rook a

            Assert.IsTrue(KingBetweenRooks);
        }
    }
}

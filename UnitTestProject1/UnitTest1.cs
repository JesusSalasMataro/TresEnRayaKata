using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TresEnRaya;
using TresEnRaya.Enums;
using TresEnRaya.Exceptions;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private static Game _sut;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            _sut = new Game();
        }

        [TestMethod]
        public void The_Game_Begins_With_A_Board_Of_3x3_Empty_Boxes()
        {
            // ARRANGE
            _sut = new Game();

            // ACT
            GamePieceTypeEnum[] boxes = _sut.GetBoxes();

            // ASSERT
            Assert.AreEqual(GamePieceTypeEnum.None, boxes[(int)BoxPositionEnum.AboveLeft]);
            Assert.AreEqual(GamePieceTypeEnum.None, boxes[(int)BoxPositionEnum.AboveCenter]);
            Assert.AreEqual(GamePieceTypeEnum.None, boxes[(int)BoxPositionEnum.AboveRight]);
            Assert.AreEqual(GamePieceTypeEnum.None, boxes[(int)BoxPositionEnum.MiddleLeft]);
            Assert.AreEqual(GamePieceTypeEnum.None, boxes[(int)BoxPositionEnum.MiddleCenter]);
            Assert.AreEqual(GamePieceTypeEnum.None, boxes[(int)BoxPositionEnum.MiddleRight]);
            Assert.AreEqual(GamePieceTypeEnum.None, boxes[(int)BoxPositionEnum.DownLeft]);
            Assert.AreEqual(GamePieceTypeEnum.None, boxes[(int)BoxPositionEnum.DownCenter]);
            Assert.AreEqual(GamePieceTypeEnum.None, boxes[(int)BoxPositionEnum.DownRight]);
        }

        [TestMethod]
        public void Red_Game_Pieces_Can_Be_Placed_In_The_Board()
        {
            // ARRANGE
            _sut = new Game();

            // ACT
            _sut.PlacePiece(GamePieceTypeEnum.White, BoxPositionEnum.DownLeft);
            _sut.PlacePiece(GamePieceTypeEnum.Red, BoxPositionEnum.DownRight);
            GamePieceTypeEnum[] boxes = _sut.GetBoxes();

            // ASSERT
            Assert.AreEqual(GamePieceTypeEnum.Red, boxes[(int)BoxPositionEnum.DownRight]);
        }

        [TestMethod]
        public void White_Game_Pieces_Can_Be_Placed_In_The_Board()
        {
            // ARRANGE
            _sut = new Game();

            // ACT
            _sut.PlacePiece(GamePieceTypeEnum.White, BoxPositionEnum.DownRight);
            GamePieceTypeEnum[] boxes = _sut.GetBoxes();

            // ASSERT
            Assert.AreEqual(GamePieceTypeEnum.White, boxes[(int)BoxPositionEnum.DownRight]);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongFirstPiecePlacedException))]
        public void First_Piece_Placed_In_The_Board_Must_Be_White()
        {
            // ARRANGE
            _sut = new Game();

            // ACT
            _sut.PlacePiece(GamePieceTypeEnum.Red, BoxPositionEnum.DownRight);

            // ASSERT

        }

        [TestMethod]
        [ExpectedException(typeof(OcuppiedBoxException))]
        public void A_Piece_Cant_Be_Placed_In_An_Ocuppied_Box()
        {
            // ARRANGE
            _sut = new Game();

            // ACT
            _sut.PlacePiece(GamePieceTypeEnum.White, BoxPositionEnum.DownRight);
            _sut.PlacePiece(GamePieceTypeEnum.Red, BoxPositionEnum.DownRight);

            // ASSERT

        }

        [TestMethod]
        [ExpectedException(typeof(WrongPiecePlacedException))]
        public void Place_Two_Pieces_Of_Same_Color_In_Consecutive_Turns_Is_Not_Allowed()
        {
            // ARRANGE
            _sut = new Game();

            // ACT
            _sut.PlacePiece(GamePieceTypeEnum.White, BoxPositionEnum.DownRight);
            _sut.PlacePiece(GamePieceTypeEnum.White, BoxPositionEnum.AboveLeft);

            // ASSERT

        }

        [TestMethod]
        public void When_Board_Is_Full_Game_Ends_And_Result_Is_Draw()
        {
            // ARRANGE
            _sut = new Game();

            // ACT
            _sut.PlacePiece(GamePieceTypeEnum.White, BoxPositionEnum.AboveLeft);
            _sut.PlacePiece(GamePieceTypeEnum.Red, BoxPositionEnum.AboveRight);
            _sut.PlacePiece(GamePieceTypeEnum.White, BoxPositionEnum.AboveCenter);
            _sut.PlacePiece(GamePieceTypeEnum.Red, BoxPositionEnum.MiddleLeft);
            _sut.PlacePiece(GamePieceTypeEnum.White, BoxPositionEnum.MiddleCenter);
            _sut.PlacePiece(GamePieceTypeEnum.Red, BoxPositionEnum.DownRight);
            _sut.PlacePiece(GamePieceTypeEnum.White, BoxPositionEnum.DownLeft);
            _sut.PlacePiece(GamePieceTypeEnum.Red, BoxPositionEnum.DownCenter);
            _sut.PlacePiece(GamePieceTypeEnum.White, BoxPositionEnum.MiddleRight);

            // ASSERT
            Assert.AreEqual(_sut.GameResult, GameResultEnum.Draw);
            Assert.IsTrue(_sut.HasFinished());
        }

        [TestMethod]
        public void When_ThereAre_3_Pieces_OfSameColor_InLine_Game_Ends_And_Result_Is_Color_Wins()
        {
            // ARRANGE
            _sut = new Game();

            // ACT
            _sut.PlacePiece(GamePieceTypeEnum.White, BoxPositionEnum.AboveLeft);
            _sut.PlacePiece(GamePieceTypeEnum.Red, BoxPositionEnum.DownCenter);
            _sut.PlacePiece(GamePieceTypeEnum.White, BoxPositionEnum.AboveCenter);
            _sut.PlacePiece(GamePieceTypeEnum.Red, BoxPositionEnum.MiddleCenter);
            _sut.PlacePiece(GamePieceTypeEnum.White, BoxPositionEnum.AboveRight);

            // ASSERT
            Assert.AreEqual(_sut.GameResult, GameResultEnum.WhiteWins);
            Assert.IsTrue(_sut.HasFinished());
        }
    }
}

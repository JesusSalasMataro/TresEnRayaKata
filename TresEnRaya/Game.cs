using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TresEnRaya.Enums;
using TresEnRaya.Exceptions;

namespace TresEnRaya
{
    public class Game
    {
        private const int NUM_BOXES = 9;

        private GamePieceTypeEnum[] _boxes;
        private GamePieceTypeEnum _lastGamePlacedPiece;

        public GameResultEnum GameResult { get; set; }

        public Game()
        {
            InitializeGameBoxes();
            _lastGamePlacedPiece = GamePieceTypeEnum.None;
            GameResult = GameResultEnum.None;
        }


        #region Public methods        

        public GamePieceTypeEnum[] GetBoxes()
        {
            return _boxes;
        }

        public void PlacePiece(GamePieceTypeEnum gamePieceType, BoxPositionEnum boxPosition)
        {
            CheckNotAllowedMoves(gamePieceType, boxPosition);
            PlacePieceIntoBox(gamePieceType, boxPosition);
            SetLastGamePlacedPiece(gamePieceType);

            if (BoardIsFull())
            {
                SetGameDrawResult();
            }

            if (ThreePiecesOfSameTypeInARow(gamePieceType))
            {
                SetGameWinResult(gamePieceType);
            }
        }

        public bool HasFinished()
        {
            return GameResult != GameResultEnum.None;
        }

        #endregion

        #region Private methods

        private void InitializeGameBoxes()
        {
            _boxes = new GamePieceTypeEnum[NUM_BOXES];

            for (int i = 0; i < NUM_BOXES; i++)
            {
                _boxes[i] = GamePieceTypeEnum.None;
            }
        }

        private void SetLastGamePlacedPiece(GamePieceTypeEnum gamePieceType)
        {
            _lastGamePlacedPiece = gamePieceType;
        }

        private void PlacePieceIntoBox(GamePieceTypeEnum gamePieceType, BoxPositionEnum boxPosition)
        {
            _boxes[(int)boxPosition] = gamePieceType;
        }

        private void CheckNotAllowedMoves(GamePieceTypeEnum gamePieceType, BoxPositionEnum boxPosition)
        {
            if (FirstGamePlacedPieceIsWhite(gamePieceType))
            {
                throw new WrongFirstPiecePlacedException();
            }

            if (IsOcuppiedBox(boxPosition))
            {
                throw new OcuppiedBoxException();
            }

            if (LastPlacedPieceIsSameColor(gamePieceType))
            {
                throw new WrongPiecePlacedException();
            }
        }

        private bool BoardIsFull()
        {
            return !_boxes.Any(b => b == GamePieceTypeEnum.None);
        }

        private bool LastPlacedPieceIsSameColor(GamePieceTypeEnum gamePieceTypeEnum)
        {
            return gamePieceTypeEnum == _lastGamePlacedPiece;
        }

        private bool IsOcuppiedBox(BoxPositionEnum boxPosition)
        {
            return _boxes[(int)boxPosition] != GamePieceTypeEnum.None;
        }

        private bool FirstGamePlacedPieceIsWhite(GamePieceTypeEnum gamePieceType)
        {
            return IsFirstPlacedPiece(gamePieceType) && gamePieceType != GamePieceTypeEnum.White;
        }

        private bool IsFirstPlacedPiece(GamePieceTypeEnum gamePieceType)
        {
            return _boxes.All(b => b == GamePieceTypeEnum.None);
        }

        private void SetGameWinResult(GamePieceTypeEnum gamePieceType)
        {
            if (gamePieceType == GamePieceTypeEnum.White)
            {
                GameResult = GameResultEnum.WhiteWins;
            }
            else if (gamePieceType == GamePieceTypeEnum.Red)
            {
                GameResult = GameResultEnum.RedWins;
            }
        }

        private void SetGameDrawResult()
        {
            GameResult = GameResultEnum.Draw;
        }

        private bool ThreePiecesOfSameTypeInARow(GamePieceTypeEnum gamePieceType)
        {
            bool threePiecesOfSameTypeInARow = false;

            threePiecesOfSameTypeInARow = CheckIfThreePiecesOfSameTypeInFirstRow(gamePieceType);

            if (!threePiecesOfSameTypeInARow)
            {
                threePiecesOfSameTypeInARow = CheckIfThreePiecesOfSameTypeInSecondRow(gamePieceType);
            }

            if (!threePiecesOfSameTypeInARow)
            {
                threePiecesOfSameTypeInARow = CheckIfThreePiecesOfSameTypeInThirdRow(gamePieceType);
            }

            if (!threePiecesOfSameTypeInARow)
            {
                threePiecesOfSameTypeInARow = CheckIfThreePiecesOfSameTypeInFirstColumn(gamePieceType);
            }

            if (!threePiecesOfSameTypeInARow)
            {
                threePiecesOfSameTypeInARow = CheckIfThreePiecesOfSameTypeInSecondColumn(gamePieceType);
            }

            if (!threePiecesOfSameTypeInARow)
            {
                threePiecesOfSameTypeInARow = CheckIfThreePiecesOfSameTypeInThirdColumn(gamePieceType);
            }

            if (!threePiecesOfSameTypeInARow)
            {
                threePiecesOfSameTypeInARow = CheckIfThreePiecesOfSameTypeInFirstDiagonal(gamePieceType);
            }

            if (!threePiecesOfSameTypeInARow)
            {
                threePiecesOfSameTypeInARow = CheckIfThreePiecesOfSameTypeInSeconDiagonal(gamePieceType);
            }

            return threePiecesOfSameTypeInARow;
        }

        private bool CheckIfThreePiecesOfSameTypeInFirstRow(GamePieceTypeEnum gamePieceType)
        {
            return _boxes[(int)BoxPositionEnum.AboveLeft] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.AboveCenter] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.AboveRight] == gamePieceType;
        }

        private bool CheckIfThreePiecesOfSameTypeInSecondRow(GamePieceTypeEnum gamePieceType)
        {
            return _boxes[(int)BoxPositionEnum.MiddleLeft] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.MiddleCenter] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.MiddleRight] == gamePieceType;
        }

        private bool CheckIfThreePiecesOfSameTypeInThirdRow(GamePieceTypeEnum gamePieceType)
        {
            return _boxes[(int)BoxPositionEnum.DownLeft] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.DownCenter] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.DownRight] == gamePieceType;
        }

        private bool CheckIfThreePiecesOfSameTypeInFirstColumn(GamePieceTypeEnum gamePieceType)
        {
            return _boxes[(int)BoxPositionEnum.AboveLeft] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.MiddleLeft] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.DownLeft] == gamePieceType;
        }

        private bool CheckIfThreePiecesOfSameTypeInSecondColumn(GamePieceTypeEnum gamePieceType)
        {
            return _boxes[(int)BoxPositionEnum.AboveCenter] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.MiddleCenter] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.DownCenter] == gamePieceType;
        }

        private bool CheckIfThreePiecesOfSameTypeInThirdColumn(GamePieceTypeEnum gamePieceType)
        {
            return _boxes[(int)BoxPositionEnum.AboveRight] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.MiddleRight] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.DownRight] == gamePieceType;
        }

        private bool CheckIfThreePiecesOfSameTypeInFirstDiagonal(GamePieceTypeEnum gamePieceType)
        {
            return _boxes[(int)BoxPositionEnum.AboveLeft] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.MiddleCenter] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.DownRight] == gamePieceType;
        }

        private bool CheckIfThreePiecesOfSameTypeInSeconDiagonal(GamePieceTypeEnum gamePieceType)
        {
            return _boxes[(int)BoxPositionEnum.AboveRight] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.MiddleCenter] == gamePieceType &&
                _boxes[(int)BoxPositionEnum.DownLeft] == gamePieceType;
        }

        #endregion
    }
}

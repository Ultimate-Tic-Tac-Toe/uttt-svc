using UtttApi.ObjectModel.Abstracts;
using UtttApi.ObjectModel.Enums;

namespace UtttApi.ObjectModel.Models
{
    public class GlobalBoard : ATicTacToeBoard
    {
        public LocalBoard[] LocalBoards { get; set; }

        public GlobalBoard() : base()
        {
            LocalBoards = new LocalBoard[9];
            for (int i = 0; i < 9; i++)
            {
                LocalBoards[i] = new LocalBoard();
            }
        }

        public bool IsValidMove(Move move)
        {
            LocalBoard lb = LocalBoards[move.LbIndex];

            if (lb.Focus && lb.Board[move.MarkIndex] == MarkType.EMPTY)
            {
                return true;
            }

            return false;
        }

        public void MakeMove(Move move)
        {
            LocalBoard lb = LocalBoards[move.LbIndex];

            lb.MarkBoard(move);

            if (lb.HasTicTacToe(move.Mark))
            {
                lb.Playable = false;
                MarkBoard(new Move { Mark = move.Mark, MarkIndex = move.LbIndex });
            }
            else if (lb.IsFull())
            {
                lb.Playable = false;
                MarkBoard(new Move { Mark = MarkType.DRAW, MarkIndex = move.LbIndex });
            }
        }

        public void UpdateFocus(int index, GameStatus status)
        {
            if (status == GameStatus.IN_PROGRESS)
            {
                LocalBoard nextLb = LocalBoards[index];

                // if nextLb is playable, set focus to true and all others to false
                if (nextLb.Playable)
                {
                    foreach (var lb in LocalBoards)
                    {
                        lb.Focus = false;
                    }

                    nextLb.Focus = true;
                }

                // if nextLb is not playable, all playable boards are in focus and all unplayable boards are not
                else
                {
                    foreach (var lb in LocalBoards)
                    {
                        lb.Focus = lb.Playable;
                    }
                }
            }
            else
            {
                foreach (var lb in LocalBoards)
                {
                    lb.Focus = false;
                    lb.Playable = false;
                }
            }
        }
    }
}
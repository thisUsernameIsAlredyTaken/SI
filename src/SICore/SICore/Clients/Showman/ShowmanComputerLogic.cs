﻿using System.Linq;

namespace SICore
{
    /// <summary>
    /// Логика ведущего-компьютера
    /// </summary>
    internal sealed class ShowmanComputerLogic : ViewerComputerLogic<Showman>, IShowman
    {
        public ShowmanComputerLogic(Showman client, ViewerData data)
            : base(client, data)
        {
            
        }

        private void SelectPlayer(string message)
        {
            int num = _data.Players.Count(p => p.CanBeSelected);
            int i = Data.Rand.Next(num);
            while (i < _data.Players.Count && !_data.Players[i].CanBeSelected)
                i++;

            _actor.SendMessage(message, i.ToString());
        }

        private void AnswerNextToDelete()
        {
            SelectPlayer(Messages.NextDelete);
        }

        private void AnswerNextStake()
        {
            SelectPlayer(Messages.Next);
        }

        private void AnswerFirst()
        {
            SelectPlayer(Messages.First);
        }

        private void AnswerRight()
        {
            bool right = false;

            foreach (var s in _data.PersonDataExtensions.Right)
            {
                right = AnswerChecker.IsAnswerRight(_data.PersonDataExtensions.Answer, s);
                if (right)
                    break;
            }

            if (right)
                _actor.SendMessage(Messages.IsRight, "+");
            else
                _actor.SendMessage(Messages.IsRight, "-");
        }

        #region ShowmanInterface Members

        public void StarterChoose()
        {
            Execute(AnswerFirst, 10 + Data.Rand.Next(10));
        }

        public void FirstStake()
        {
            Execute(AnswerNextStake, 10 + Data.Rand.Next(10));
        }

        public void IsRight()
        {
            Execute(AnswerRight, 10 + Data.Rand.Next(10));
        }

        public void FirstDelete()
        {
            Execute(AnswerNextToDelete, 10 + Data.Rand.Next(10));
        }

        public void ChangeSum()
        {

        }

        #endregion

        public void OnInitialized()
        {
            ((PersonAccount)_data.Me).BeReadyCommand.Execute(null);
        }

        public void ClearSelections(bool full = false)
        {

        }


        public void ChooseQuest()
        {
            
        }

        public void Cat()
        {
            
        }

        public void Stake()
        {
            
        }

        public void ChooseFinalTheme()
        {
            
        }

        public void FinalStake()
        {
            
        }

        public void CatCost()
        {
            
        }

        public void Table()
        {
            
        }

        public void FinalThemes()
        {
            
        }
    }
}

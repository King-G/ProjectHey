using ProjectHey.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHeyMobile.ViewModels
{
    public class HeyFeaturesViewModel: BaseViewModel
    {
        #region Private Properties
        private bool _FullProfileUnlocked = false;
        private bool _EventsUnlocked = false;
        private bool _CommonFriendsUnlocked = false;
        private bool _LikesUnlocked = false;
        private bool _MusicUnlocked = false;
        private bool _TVShowsUnlocked = false;
        private bool _MoviesUnlocked = false;
        private bool _SportsUnlocked = false;
        private bool _BooksUnlocked = false;
        private Connection _Connection;
        #endregion

        #region Public Properties
        public Connection Connection
        {
            get { return _Connection; }
            set { SetValue(ref _Connection, value); }
        }
        public bool FullProfileUnlocked
        {
            get { return _FullProfileUnlocked; }
            set { SetValue(ref _FullProfileUnlocked, value); }
        }
        public bool EventsUnlocked
        {
            get { return _EventsUnlocked; }
            set { SetValue(ref _EventsUnlocked, value); }
        }
        public bool CommonFriendsUnlocked
        {
            get { return _CommonFriendsUnlocked; }
            set { SetValue(ref _CommonFriendsUnlocked, value); }
        }
        public bool LikesUnlocked
        {
            get { return _LikesUnlocked; }
            set { SetValue(ref _LikesUnlocked, value); }
        }
        public bool MusicUnlocked
        {
            get { return _MusicUnlocked; }
            set { SetValue(ref _MusicUnlocked, value); }
        }
        public bool TVShowsUnlocked
        {
            get { return _TVShowsUnlocked; }
            set { SetValue(ref _TVShowsUnlocked, value); }
        }
        public bool MoviesUnlocked
        {
            get { return _MoviesUnlocked; }
            set { SetValue(ref _MoviesUnlocked, value); }
        }
        public bool SportsUnlocked
        {
            get { return _SportsUnlocked; }
            set { SetValue(ref _SportsUnlocked, value); }
        }
        public bool BooksUnlocked
        {
            get { return _BooksUnlocked; }
            set { SetValue(ref _BooksUnlocked, value); }
        }
        #endregion

        public HeyFeaturesViewModel(ConnectionViewModel connectionViewModel)
        {
            _Connection = connectionViewModel.Connection;
            //Unlock(_Connection.Progress);
            Unlock(0.81);


        }

        private void Unlock(double progress)
        {
            if (progress >= 1)
            {
                _FullProfileUnlocked = true;
                _EventsUnlocked = true;
                _CommonFriendsUnlocked = true;
                _LikesUnlocked = true;
                _MusicUnlocked = true;
                _TVShowsUnlocked = true;
                _MoviesUnlocked = true;
                _SportsUnlocked = true;
                _BooksUnlocked = true;
            }
            else if (progress >= 0.80)
            {
                _EventsUnlocked = true;
                _CommonFriendsUnlocked = true;
                _LikesUnlocked = true;
                _MusicUnlocked = true;
                _TVShowsUnlocked = true;
                _MoviesUnlocked = true;
                _SportsUnlocked = true;
                _BooksUnlocked = true;
            }
            else if (progress >= 0.70)
            {
                _CommonFriendsUnlocked = true;
                _LikesUnlocked = true;
                _MusicUnlocked = true;
                _TVShowsUnlocked = true;
                _MoviesUnlocked = true;
                _SportsUnlocked = true;
                _BooksUnlocked = true;
            }
            else if (progress >= 0.60)
            {
                _LikesUnlocked = true;
                _MusicUnlocked = true;
                _TVShowsUnlocked = true;
                _MoviesUnlocked = true;
                _SportsUnlocked = true;
                _BooksUnlocked = true;
            }
            else if (progress >= 0.50)
            {
                _MusicUnlocked = true;
                _TVShowsUnlocked = true;
                _MoviesUnlocked = true;
                _SportsUnlocked = true;
                _BooksUnlocked = true;
            }
            else if (progress >= 0.40)
            {
                _TVShowsUnlocked = true;
                _MoviesUnlocked = true;
                _SportsUnlocked = true;
                _BooksUnlocked = true;
            }
            else if (progress >= 0.30)
            {
                _MoviesUnlocked = true;
                _SportsUnlocked = true;
                _BooksUnlocked = true;
            }
            else if (progress >= 0.20)
            {
                _SportsUnlocked = true;
                _BooksUnlocked = true;
            }
            else if (progress >= 0.10)
            {
                _BooksUnlocked = true;
            }
        }
    }
}

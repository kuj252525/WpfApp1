using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Atomus.WpfApp2.ViewModel
{
    public class MainWindowViewModel : MVVM.ViewModel
    {
        //멤버 정의
        private string userID;
        private string password;
        private string email;
        private List<MainWindowViewModel> list;
        private bool isEnabledControl;

        private MainWindowViewModel selecteditem;
        
        [Required]
        [Display(Name ="아이디")]
        //프로퍼티 정의
        public string UserID 
        {
            get
            {
                return this.userID;
            }
            set
            {
                if(this.userID != value)
                {
                    this.userID = value;
                    this.NotifyPropertyChanged();   // ViewModel의 값이 바뀌었을 때, View에 알려주는 메소드.
                }
            }         
        }

        [Required]
        [Display(Name ="패스워드")]
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    this.NotifyPropertyChanged();   // ViewModel의 값이 바뀌었을 때, View에 알려주는 메소드.
                }
            }
        }

        [Required]
        [Display(Name = "이메일")]
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    this.NotifyPropertyChanged();   // ViewModel의 값이 바뀌었을 때, View에 알려주는 메소드.
                }
            }
        }

        public List<MainWindowViewModel> UserList
        {
            get
            {
                return this.list;
            }
            set
            {
                this.list = value;
                this.NotifyPropertyChanged();   
            }
        }

        public bool IsEnabledControl
        {
            get
            {
                return this.isEnabledControl;
            }
            set
            {
                if (this.isEnabledControl != value)
                {
                    this.isEnabledControl = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public MainWindowViewModel Selecteditem
        {
            get
            {
                return this.selecteditem;
            }
            set
            {
                if (this.selecteditem != value)
                {
                    this.selecteditem = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public ICommand SaveCommand { get; set; } // ctrl + . => 추천해주는 단축키
        public ICommand InitCommand { get; set; }

        public MainWindowViewModel()    //ctor + tab2번 => 메소드 생성 단축키
        {
            this.IsEnabledControl = true;
            //this.selecteditem = new MainWindowViewModel();

            this.list = new List<MainWindowViewModel>();

            this.SaveCommand = new MVVM.DelegateCommand
                (
                    () => { this.SaveProcess(); }
                    , () => { return this.IsEnabledControl; }
                );

            this.InitCommand = new MVVM.DelegateCommand
                (
                    () => { this.InitProcess(); }
                    , () => { return this.IsEnabledControl; }
                );

        }

        private void InitProcess()
        {
            this.selecteditem = new MainWindowViewModel();
        }

        private void SaveProcess()
        {
            //throw new NotImplementedException();

            MainWindowViewModel mainWindowViewModel;
            List<MainWindowViewModel> models;

            try
            {
                this.IsEnabledControl = false;
                (this.SaveCommand as MVVM.DelegateCommand).RaiseCanExecuteChanged();

                //System.Threading.Thread.Sleep(3000);  //3s 동안 잠김

                //this.ValidateResult = true;

                //this.NotifyPropertyChanged("UserID");
                //this.NotifyPropertyChanged("Password");
                //this.NotifyPropertyChanged("Email");

                //if (!this.ValidateResult)
                //    return;

                mainWindowViewModel = new MainWindowViewModel();
                mainWindowViewModel.UserID = this.selecteditem.UserID;
                mainWindowViewModel.Password = this.selecteditem.Password;
                mainWindowViewModel.Email = this.selecteditem.Email;

                this.list.Add(mainWindowViewModel);
                models = this.list;
                this.UserList = null;
                this.UserList = models;

            }

            catch(Exception)
            {
            }
            finally
            {
                this.IsEnabledControl = true;
                (this.SaveCommand as MVVM.DelegateCommand).RaiseCanExecuteChanged();
            }



        }
    }
}

using JsonBase64.Model;
using JsonBase64.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JsonBase64.ViewModel
{
    public class RegisterViewModel : BaseViewModel<Usuario>
    {
        private Command _registerCommand;
        private string _jsonResult;
        private UsuariosService _usuariosService;

        public RegisterViewModel(Usuario model = null) : base(model)
        {
            if (model == null)
            {
                Model = new Usuario();
            }
            _usuariosService = new UsuariosService();
        }

        public string UserName
        {
            get => Model.Username;

            set
            {
                if (string.Equals(value, Model.Username)) return;
                Model.Username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => Model.Password;

            set
            {
                if (string.Equals(value, Model.Password)) return;
                Model.Password = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => Model.Name;

            set
            {
                if (string.Equals(value, Model.Name)) return;
                Model.Name = value;
                OnPropertyChanged();
            }
        }

        public string Ap1
        {
            get => Model.Ap1;

            set
            {
                if (string.Equals(value, Model.Ap1)) return;
                Model.Ap1 = value;
                OnPropertyChanged();
            }
        }

        public string Ap2
        {
            get => Model.Ap2;

            set
            {
                if (string.Equals(value, Model.Ap2)) return;
                Model.Ap2 = value;
                OnPropertyChanged();
            }
        }

        public Command RegisterCommand
        {
            get => _registerCommand ??
                (_registerCommand = new Command(RegisterAction));
        }

        public string JsonResult
        {
            get => _jsonResult;
            set
            {
                if (string.Equals(_jsonResult, value)) return;
                _jsonResult = value;

                OnPropertyChanged();
            }
        }

        private async void RegisterAction()
        {
            Usuario newObject = EncriptOrDecriptData(true);

            JsonResult = await _usuariosService?.RegisterAsync(newObject);
        }
    } //principal
}

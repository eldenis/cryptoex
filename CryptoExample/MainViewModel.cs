using System;
using System.Reactive;
using Crypto;
using ReactiveUI;
using System.Reactive.Subjects;

namespace CryptoExample
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            Encrypt = ReactiveCommand.Create(EncryptImpl);
            Decrypt = ReactiveCommand.Create(DecryptImpl);

            ShowErrorMessage = new Subject<Exception>();

            Encrypt.ThrownExceptions.Subscribe(x => ShowErrorMessage.OnNext(x));
            Decrypt.ThrownExceptions.Subscribe(x => ShowErrorMessage.OnNext(x));


        }

        #region Properties

        public ISubject<Exception> ShowErrorMessage { get; }
        public ReactiveCommand Encrypt { get; }
        public ReactiveCommand Decrypt { get; }

        private string _salt;
        public string Salt
        {
            get => _salt;
            set => this.RaiseAndSetIfChanged(ref _salt, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        private string _original;
        public string Original
        {
            get => _original;
            set => this.RaiseAndSetIfChanged(ref _original, value);
        }

        private string _result;
        public string Result
        {
            get => _result;
            set => this.RaiseAndSetIfChanged(ref _result, value);
        }

        #endregion

        #region Methods

        private void DecryptImpl()
        {
            DefaultCrypto.SetSalt(Salt);
            Result = DefaultCrypto.DecryptStringAES(Original, Password);
        }

        private void EncryptImpl()
        {
            DefaultCrypto.SetSalt(Salt);
            Result = DefaultCrypto.EncryptStringAES(Original, Password);
        }

        #endregion
    }
}

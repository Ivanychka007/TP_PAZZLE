using System;
using System.Configuration;
using System.Windows.Forms;
using University.Puzzle.Client;
using University.Puzzle.ObjectsLibrary;
using University.Puzzle.ValidationLibrary;

namespace University.Puzzle.UI
{
    #region Class: AuthorizationRegistrationForm
    /// <summary>
    /// Окно авторизации.
    /// </summary>
    public partial class AuthorizationRegistrationForm : Form
    {
        #region Fields: Private
        /// <summary>
        /// Взаимодействует с Web API.
        /// </summary>
        private UserHandler _userHandler;

        public UserForm UserForm
        {
            get => default;
            set
            {
            }
        }

        public AdministratorForm AdministratorForm
        {
            get => default;
            set
            {
            }
        }
        #endregion

        #region Methods: Private
        /// <summary>
        /// Обработчик нажатия кнопки "Войти".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private async void ButtonLogin_Click(object sender, EventArgs e)
        {
            var login = textBoxLogin.Text;
            var password = textBoxPassword.Text;

            try
            {
                TextValidator.IsValidLogin(login);
                TextValidator.IsValidPassword(password);

                var user = new User(login, password);

                await _userHandler.Authorize(user);

                if(await _userHandler.IsAdmin(user.Login))
                {
                    new AdministratorForm().Show();
                    this.Dispose();
                }
                else
                {
                    new UserForm(await _userHandler.GetId(login)).Show();
                    this.Dispose();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик события после закрытия формы.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void AuthorizationRegistrationForm_onClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Регистрация".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private async void ButtonRegister_Click(object sender, EventArgs e)
        {
            var login = textBoxLogin.Text;
            var password = textBoxPassword.Text;

            try
            {
                TextValidator.IsValidLogin(login);
                TextValidator.IsValidPassword(password);

                var newUser = new User(login, password);

                await _userHandler.Register(newUser);
                
                MessageBox.Show("Пользователь был успешно зарегистрирован.", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Constructors: Public
        /// <summary>
        /// Используется при инициализации класса.
        /// </summary>
        public AuthorizationRegistrationForm()
        {
            InitializeComponent();
            _userHandler = new UserHandler(ConfigurationManager.ConnectionStrings["WebApiUrl"].ConnectionString);
        }
        #endregion
    }
    #endregion
}

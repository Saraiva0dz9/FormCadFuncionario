using FormFuncionario.Models;
using FormFuncionario.Services.FuncionarioCadDb;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Syncfusion.Blazor.Notifications;

namespace FormFuncionario.Pages
{
    public partial class InitialPage
    {
        // Deoendencies Injection
        [Inject]
        private IFuncionarioService _funcionarioService { get; set; } = default!;

        // Variables
        private bool IsDialogCadVisible = false;
        private bool isCheckedM = false;
        private bool isCheckedF = false;

        // Objects
        private Funcionario funcionario = new Funcionario();

        // Components
        private SfToast ToastObj = new();
        private EditContext editContext;

        // Code
        protected override void OnInitialized()
        {
            editContext = new(funcionario);
        }

        public void OnDialogCadOpen()
        {
            this.IsDialogCadVisible = true;
        }

        public void VerifySelectionFirst()
        {
            this.isCheckedF = false;
            funcionario.Sexo = "M";
        }
        
        public void VerifySelectionSecond()
        {
            this.isCheckedM = false;
            funcionario.Sexo = "F";
        }

        public async Task SalvarCadastro()
        { 
            try
            {
                await _funcionarioService.PostFuncionario(funcionario);
            }
            catch (Exception ex)
            {
                await ToastObj!.ShowAsync(new ToastModel()
                {
                    Title = "Aviso.",
                    Content = ex.Message,
                    CssClass = "e-toast-danger",
                    Icon = "fa-solid fa-triangle-exclamation"
                });
                return;
            }

            this.IsDialogCadVisible = false;

            await ToastObj!.ShowAsync(new ToastModel()
            {
                Title = "Aviso.",
                Content = "Funcionário cadastrado com sucesso",
                CssClass = "e-toast-success",
                Icon = "fa-solid fa-triangle-exclamation"
            });
        }       

        public void OnDialogCadClose()
        {
            funcionario.FirstName = string.Empty;
            funcionario.Sobrenome = string.Empty;
        }
    }
}

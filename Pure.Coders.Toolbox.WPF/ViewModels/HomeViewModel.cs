using Microsoft.Extensions.Logging;
using Pure.Coders.Toolbox.WPF.Views;
using Pure.Library.Coders.Toolbox;
using Pure.Library.WPF;
using System.Windows;
using System.Windows.Controls;

namespace Pure.Coders.Toolbox.WPF.ViewModels
{
    public sealed class HomeViewModel : WorkspaceViewModel
    {
        public HomeViewModel(AppSettings appSettings,
            CodeGeneratorViewModel codeGeneratorViewModel,
            ILogger logger
            )
        {
            _logger = logger;
            _appSettings = appSettings;

            _viewModels[nameof(CodeGeneratorViewModel)] = codeGeneratorViewModel;
        }

        #region Variables
        private readonly ILogger _logger;
        private readonly AppSettings _appSettings;
        private readonly Dictionary<string, WorkspaceViewModel> _viewModels = [];
        #endregion

        #region Event Handlers
        protected override void OnButtonClick(Button sender) => ButtonClickInvocations[sender.Name].Invoke();

        private Dictionary<string, Action>? _buttonClickInvocations;
        private Dictionary<string, Action> ButtonClickInvocations => _buttonClickInvocations ??= new()
        {
            ["ShowCodeGeneratorButton"] = () => OnShowCodeGeneratorButton()
        };
        private void OnShowCodeGeneratorButton()
        {
            CodeGeneratorViewModel vm = (CodeGeneratorViewModel)_viewModels[nameof(CodeGeneratorViewModel)];
            vm.InitialiseDataSources();

            CodeGenerator v = new()
            {
                DataContext = vm,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                SizeToContent = SizeToContent.WidthAndHeight
            };
            v.Show();
        }
        #endregion
    }
}

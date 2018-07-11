using System;
using Prism.Navigation;
using Prism.Services;

namespace Cheeteye.ViewModels
{
    public class RewardsContentViewModel : BaseViewModel
    {
        public RewardsContentViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
        }
    }
}

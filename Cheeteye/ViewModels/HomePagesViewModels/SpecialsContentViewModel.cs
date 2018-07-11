using System;
using Prism.Navigation;
using Prism.Services;

namespace Cheeteye.ViewModels
{
    public class SpecialsContentViewModel : BaseViewModel
    {
        public SpecialsContentViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
        }
    }
}

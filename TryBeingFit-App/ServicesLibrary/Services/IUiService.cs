using DomainLibrary.Entities;
using DomainLibrary.Enums;
using System.Collections.Generic;

namespace ServicesLibrary.Services
{
    public interface IUiService
    {
        public List<string> MainMenuItems { get; set; }
        public List<string> AccountMenuItems { get; set; }


        int LogInMenu(); // LogIn or Register
        int RoleMenu();

        int ChooseMenu<T>(List<T> items);
        int ChooseEntitiesMenu<T>(List<T> entities) where T : IBaseEntity;

        int MainMenu(UserRole role); // choose from the follwoing menues:

        int AccountMenu(UserRole role);
        int TrainingsMenu(); //Video or Live
        int TrainingMenuItems<T>(List<T> trainings) where T : Training;
        void UpgradeToPremium();


        void Welcome(User user);

    }
}

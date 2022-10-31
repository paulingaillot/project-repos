namespace LOCMI.Controllers;

using LOCMI.Models.Menu;
using LOCMI.Views;

public sealed class InitialController
{
    private Menu<MainMenuCommand>? _mainMenu;

    private View? _view;

    public void Run()
    {
        _view = new View();
        var demoController = new DemoController(_view);
        var expController = new ExperimentalController(_view);
        var demoCommand = new MenuDemoCommand(demoController);
        var expCommand = new MenuExpCommand(expController);
        _mainMenu = new Menu<MainMenuCommand>("Main Menu");
        _mainMenu.Add("Demonstration", demoCommand);
        _mainMenu.Add("Experimental", expCommand);

        while (!_mainMenu.GetIsClosed())
        {
            List<Entry<MainMenuCommand>> entries = _mainMenu.GetEntries();
            _view.Display("Choose a choice from the menu below:");
            /* display entries */
            entries.ForEach(static entry => entry.Show());
            /* Read the user's choice */
            string? read = Console.ReadLine();
            var userChoice = Convert.ToInt32(read);
            /* Execute the user's choice */
            _mainMenu.Execute(userChoice);
        }
    }
}
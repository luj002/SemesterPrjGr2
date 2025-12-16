LoginMenu loginMenu = new LoginMenu();
string memberId = loginMenu.Login();

UserMenu menu = new UserMenu(memberId);
menu.ShowMenu();
namespace Project_1_Bank_Extension_2
{
    internal class Program
    {

        public static string clientsFile = "Clients.txt";
        public static string usersFile = "Users.txt";
        public static stUser currentUser = new stUser();

        public struct stUser
        {

            public string userName;
            public string password;
            public int permissions;
            public bool markForDelete;

        }

        static string Tabs(short numberOfTabs)
        {

            string tabs = "";

            for (short i = 0; i < numberOfTabs; i++)
            {
                tabs += "\t";
            }

            return tabs;

        }

        static List<string> SplitString(string s, string delim)
        {

            List<string> lword = new List<string>();

            string word = "";
            short pos = 0;

            while ((pos = (short)s.IndexOf(delim)) != -1)
            {

                word = s.Substring(0, pos);

                if (word != " ")
                {
                    lword.Add(word);
                }

                s = s.Substring(pos + delim.Length);

            }

            if (s != "")
            {
                lword.Add(s);
            }

            return lword;

        }

        static stUser ConvertUserLineToRecord(string line, string separator = "#//#")
        {

            stUser user;

            List<string> lUserData = SplitString(line, separator);

            user.userName = lUserData[0];
            user.password = lUserData[1];
            user.permissions = int.Parse(lUserData[2]);
            user.markForDelete = false;

            return user;

        }

        static List<stUser> LoadUsersDataFromFile(string fileName)
        {

            List<stUser> lUsers = new List<stUser>();

            if (File.Exists(fileName))
            {

                using (StreamReader reader = new StreamReader(fileName))
                {

                    string line = "";

                    stUser user;

                    while ((line = reader.ReadLine()) != null)
                    {

                        user = ConvertUserLineToRecord(line);

                        lUsers.Add(user);

                    }

                }

            }
            else
            {
                Console.WriteLine($"The file with name [{fileName}] not found!.");
            }

            return lUsers;

        }

        static string ReadUserName()
        {

            Console.Write("\nEnter Username? ");
            string userName = Console.ReadLine().Trim();

            return userName;

        }

        static string ReadPassword()
        {

            Console.Write("\nEnter password? ");
            string password = Console.ReadLine();

            return password;

        }

        static bool FindUserByUserNameAndPassword(string userName, string password, ref stUser user)
        {

            List<stUser> lUsers = LoadUsersDataFromFile(usersFile);

            foreach (stUser u in lUsers)
            {

                if (u.userName == userName && u.password == password)
                {
                    user = u;
                    return true;
                }

            }

            return false;

        }

        enum enMainMenuOption
        {
            eClientList = 1, eAddNewClient = 2, eDeleteClient = 3, eUpdateClient = 4,
            eFindClient = 5, eTransactions = 6, eManageUsers = 7, eLogout = 8
        }

        static enMainMenuOption ReadMainMenuOption()
        {

            short choice;

            do
            {

                Console.Write("Choose what do you want to do? [1 to 8]? ");
                choice = short.Parse(Console.ReadLine());

            } while (choice < 1 || choice > 8);

            return (enMainMenuOption)choice;

        }

        struct stClient
        {

            public string accountNumber;
            public string pinCode;
            public string name;
            public string phone;
            public double accountBalance;
            public bool markForDelete;

        }

        static stClient ConvertClientLineToRecord(string line, string separator = "#//#")
        {

            stClient client;

            List<string> lClientData = SplitString(line, separator);

            client.accountNumber = lClientData[0];
            client.pinCode = lClientData[1];
            client.name = lClientData[2];
            client.phone = lClientData[3];
            client.accountBalance = double.Parse(lClientData[4]);
            client.markForDelete = false;

            return client;

        }

        enum enMainMenuePermissions
        {
            pAll = -1, pShowClientList = 1, pAddNewClient = 2, pDeleteClient = 4,
            pUpdateClient = 8, pFindClient = 16, pTransactions = 32, pManageUsers = 64

        }

        static bool CheckAccessPermission(enMainMenuePermissions permission)
        {

            return (currentUser.permissions == (int)enMainMenuePermissions.pAll || (currentUser.permissions & (int)permission) == (int)permission);

        }

        static void ShowAccessDeniedMessage()
        {

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine(Tabs(2) + "Access Denied,");
            Console.WriteLine("You don't have the permission to do this,");
            Console.WriteLine("Please contact your admin.");
            Console.WriteLine("---------------------------------------------");

        }

        static List<stClient> LoadClientsDataFromFile()
        {

            List<stClient> lClients = new List<stClient>();

            if (File.Exists(clientsFile))
            {

                using (StreamReader reader = new StreamReader(clientsFile))
                {
                    string line = "";
                    stClient client;

                    while ((line = reader.ReadLine()) != null)
                    {

                        client = ConvertClientLineToRecord(line);
                        lClients.Add(client);

                    }

                }

            }
            else
            {
                Console.WriteLine($"The file with name {clientsFile} not found!.");
            }

            return lClients;

        }

        static void PrintClientRecordLine(stClient client)
        {

            Console.Write($"| {client.accountNumber.PadRight(15)}");
            Console.Write($"| {client.pinCode.PadRight(9)}");
            Console.Write($"| {client.name.PadRight(40)}");
            Console.Write($"| {client.phone.PadRight(12)}");
            Console.Write($"| {client.accountBalance.ToString().PadRight(16)}");

        }

        static void ShowClientList()
        {

            if (!CheckAccessPermission(enMainMenuePermissions.pShowClientList))
            {
                ShowAccessDeniedMessage();
                return;
            }

            List<stClient> lClients = LoadClientsDataFromFile();

            Console.WriteLine($"\n{Tabs(3)} Client List ({lClients.Count}) Client(s).");

            Console.WriteLine("______________________________________________________________________________________________________\n");
            Console.Write($"| {"Account Number".PadRight(15)}");
            Console.Write($"| {"Pin Code".PadRight(9)}");
            Console.Write($"| {"Client Name".PadRight(40)}");
            Console.Write($"| {"Phone".PadRight(12)}");
            Console.WriteLine($"| {"Account Balance".PadRight(16)}");
            Console.WriteLine("______________________________________________________________________________________________________\n");

            if (lClients.Count == 0)
            {
                Console.WriteLine(Tabs(4) + "No Clients Available In The System!");
            }
            else
            {

                foreach (stClient client in lClients)
                {

                    PrintClientRecordLine(client);
                    Console.WriteLine();

                }

            }

            Console.WriteLine("\n______________________________________________________________________________________________________\n");

        }

        static void GoBackToMainMenu()
        {

            Console.Write("\nPress any key to Go Back to Main Menu...");
            Console.ReadKey();

            ShowMainMenuScreen();

        }

        static void AddDataLineToFile(string dataLine, string fileName)
        {

            if (File.Exists(fileName))
            {

                using (StreamWriter writer = new StreamWriter(fileName, append: true))
                {

                    writer.WriteLine(dataLine);

                }

            }
            else
            {
                Console.WriteLine($"\nThe file with name [{fileName}] not foumd!");
            }

        }

        static string ConvertClientRecordToLine(stClient client, string seperator = "#//#")
        {

            string dataLine;

            dataLine = client.accountNumber + seperator;
            dataLine += client.pinCode + seperator;
            dataLine += client.name + seperator;
            dataLine += client.phone + seperator;
            dataLine += client.accountBalance.ToString();

            return dataLine;

        }

        static string ReadAccountNumber()
        {

            Console.Write("\nPlease Enter Account Number? ");
            string accountNumber = Console.ReadLine().Trim();

            return accountNumber;

        }

        static bool ClientExistsByAcountNumber(string accountNumber)
        {

            if (File.Exists(clientsFile))
            {

                using (StreamReader reader = new StreamReader(clientsFile))
                {

                    string line = "";

                    stClient client;

                    while ((line = reader.ReadLine()) != null)
                    {

                        client = ConvertClientLineToRecord(line);

                        if (client.accountNumber == accountNumber)
                        {
                            return true;
                        }

                    }

                }

            }

            return false;

        }

        static stClient ReadNewClient()
        {

            stClient client = new stClient();

            client.accountNumber = ReadAccountNumber();

            while (ClientExistsByAcountNumber(client.accountNumber))
            {

                Console.Write($"\nClient with Account Number [{client.accountNumber}] already exists, Enter another account Number? ");
                client.accountNumber = Console.ReadLine().Trim();

            }

            Console.Write("Please Enter Pin Code? ");
            client.pinCode = Console.ReadLine();

            Console.Write("Please Enter Name? ");
            client.name = Console.ReadLine();

            Console.Write("Please Enter Phone? ");
            client.phone = Console.ReadLine();

            Console.Write("Please Enter Account Balance? ");
            client.accountBalance = double.Parse(Console.ReadLine());

            return client;

        }

        static void AddNewClient()
        {

            string dataLine;

            stClient client = ReadNewClient();

            dataLine = ConvertClientRecordToLine(client);

            AddDataLineToFile(dataLine, clientsFile);

        }

        static void AddNewClients()
        {

            char addMore = 'N';

            do
            {

                Console.WriteLine("\nAdding New Client:");

                AddNewClient();

                Console.Write("\nClient Added Successfully, Do you want to add more clients? Y/N? ");
                addMore = char.Parse(Console.ReadLine());

            } while (char.ToUpper(addMore) == 'Y');

        }

        static void ShowAddNewClientsScreen()
        {

            if (!CheckAccessPermission(enMainMenuePermissions.pAddNewClient))
            {
                ShowAccessDeniedMessage();
                return;
            }

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(Tabs(1) + "Add New Clients Screen");
            Console.WriteLine("--------------------------------------------");

            AddNewClients();

        }

        static bool FindClientByAccountNumber(string accountNumber, List<stClient> lClients, ref stClient client)
        {

            foreach (stClient c in lClients)
            {

                if (c.accountNumber == accountNumber)
                {

                    client = c;

                    return true;

                }

            }

            return false;

        }

        static void PrintClientCard(stClient client)
        {

            Console.WriteLine("\nThe following are the client details:");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Account Number : {client.accountNumber}");
            Console.WriteLine($"Pin Code       : {client.pinCode}");
            Console.WriteLine($"Name           : {client.name}");
            Console.WriteLine($"Phone          : {client.phone}");
            Console.WriteLine($"Account Balance: {client.accountBalance}");
            Console.WriteLine("---------------------------------------");

        }

        static void MarkClientForDelete(string accountNumber, ref List<stClient> lClients)
        {

            for (int i = 0; i < lClients.Count; i++)
            {

                if (lClients[i].accountNumber == accountNumber)
                {

                    stClient c = lClients[i];

                    c.markForDelete = true;

                    lClients[i] = c;

                    break;

                }

            }

        }

        static void SaveClientsListToFile(List<stClient> lClients)
        {

            if (File.Exists(clientsFile))
            {

                using (StreamWriter writer = new StreamWriter(clientsFile))
                {

                    string dataLine = "";

                    foreach (stClient client in lClients)
                    {

                        if (!client.markForDelete)
                        {
                            dataLine = ConvertClientRecordToLine(client);

                            writer.WriteLine(dataLine);
                        }

                    }

                }

            }
            else
            {
                Console.WriteLine($"\nThe file with name [{clientsFile}] not found!.");
            }

        }

        static void DeleteClientByAccountNumber(string accountNumber, ref List<stClient> lClients)
        {

            stClient client = new stClient();

            if (FindClientByAccountNumber(accountNumber, lClients, ref client))
            {

                PrintClientCard(client);

                Console.Write("\nAre you sure you want to delete this client? Y/N? ");
                char confirm = char.ToUpper(Console.ReadKey().KeyChar);

                Console.WriteLine();

                if (confirm == 'Y')
                {

                    MarkClientForDelete(accountNumber, ref lClients);

                    SaveClientsListToFile(lClients);

                    // Refresh Clients List
                    lClients = LoadClientsDataFromFile();

                    Console.WriteLine("\nClient deleted successfully.");

                }
                else
                {
                    Console.WriteLine("\nDeletion cancelled.");
                }

            }
            else
            {
                Console.WriteLine($"\nClient with Account Number [{accountNumber}] is not found!");
            }

        }

        static void ShowDeleteClientScreen()
        {

            if (!CheckAccessPermission(enMainMenuePermissions.pDeleteClient))
            {
                ShowAccessDeniedMessage();
                return;
            }

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(Tabs(1) + "Delete Client Screen");
            Console.WriteLine("--------------------------------------------");

            List<stClient> lClients = LoadClientsDataFromFile();

            string accountNumber = ReadAccountNumber();

            DeleteClientByAccountNumber(accountNumber, ref lClients);

        }

        static stClient ChangeClientRecord(string accountNumber)
        {

            stClient client = new stClient();

            client.accountNumber = accountNumber;

            Console.Write("\nPlease Enter Pin Code? ");
            client.pinCode = Console.ReadLine().Trim();

            Console.Write("Please Enter Name? ");
            client.name = Console.ReadLine();

            Console.Write("Please Enter Phone? ");
            client.phone = Console.ReadLine();

            Console.Write("Please Enter Account Balance? ");
            client.accountBalance = double.Parse(Console.ReadLine());

            return client;

        }

        static void UpdateClientByAccountNumber(string accountNumber, ref List<stClient> lClients)
        {

            stClient client = new stClient();

            if (FindClientByAccountNumber(accountNumber, lClients, ref client))
            {

                PrintClientCard(client);

                Console.Write("\nAre you sure you want to update this client? Y/N? ");
                char confirm = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (char.ToUpper(confirm) == 'Y')
                {

                    for (int i = 0; i < lClients.Count; i++)
                    {

                        if (lClients[i].accountNumber == accountNumber)
                        {

                            lClients[i] = ChangeClientRecord(accountNumber);

                            break;

                        }

                    }

                    SaveClientsListToFile(lClients);

                }
                else
                {
                    Console.WriteLine("\nUpdating cancelled.");
                }

            }
            else
            {
                Console.WriteLine($"\nClient with Account Number [{accountNumber}] is not found!.");
            }

        }

        static void ShowUpdateClientScreen()
        {

            if (!CheckAccessPermission(enMainMenuePermissions.pUpdateClient))
            {
                ShowAccessDeniedMessage();
                return;
            }

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(Tabs(1) + "Update Client Info Screen");
            Console.WriteLine("--------------------------------------------");

            List<stClient> lClients = LoadClientsDataFromFile();

            string accountNumber = ReadAccountNumber();

            UpdateClientByAccountNumber(accountNumber, ref lClients);

        }

        static void ShowFindClientScreen()
        {

            if (!CheckAccessPermission(enMainMenuePermissions.pFindClient))
            {
                ShowAccessDeniedMessage();
                return;
            }

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(Tabs(1) + "Find Client Screen");
            Console.WriteLine("--------------------------------------------");

            string accountNumber = ReadAccountNumber();

            List<stClient> lClients = LoadClientsDataFromFile();

            stClient client = new stClient();

            if (FindClientByAccountNumber(accountNumber, lClients, ref client))
            {

                PrintClientCard(client);

            }
            else
            {
                Console.WriteLine($"\nThe client with Account Number [{accountNumber}] is not found!");
            }

        }

        enum enTransactionsMenuOption
        {
            eDeposite = 1, eWithdraw = 2, eTotalBalances = 3, eMainMenu = 4
        }

        static short ReadTransactionsMenuOption()
        {

            short choice;

            do
            {

                Console.Write("\nChoose What do you want to do? [1 to 4]? ");
                choice = short.Parse(Console.ReadLine());

            } while (choice < 1 || choice > 4);

            return choice;

        }

        static void DepositeBalanceToClientByAccountNumber(string accountNumber, double amount, ref List<stClient> lClients)
        {

            Console.Write("\nAre you sure you want to perform this transaction? Y/N? ");
            char confirm = char.ToUpper(Console.ReadKey().KeyChar);

            Console.WriteLine();

            if (confirm == 'Y')
            {

                for (int i = 0; i < lClients.Count; i++)
                {

                    if (lClients[i].accountNumber == accountNumber)
                    {

                        stClient c = lClients[i];

                        c.accountBalance += amount;

                        lClients[i] = c;

                        SaveClientsListToFile(lClients);

                        Console.WriteLine("\n\nDone Successfully. New Balance is: " + lClients[i].accountBalance);

                        break;

                    }

                }

            }

        }

        static void ShowDepositeScreen()
        {

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(Tabs(1) + "Deposite Screen");
            Console.WriteLine("--------------------------------------------");

            string accountNumber = ReadAccountNumber();

            List<stClient> lClients = LoadClientsDataFromFile();

            stClient client = new stClient();

            while (!FindClientByAccountNumber(accountNumber, lClients, ref client))
            {

                Console.WriteLine($"\nClient with Account Number [{accountNumber}] doesn't exists.");
                accountNumber = ReadAccountNumber();

            }

            PrintClientCard(client);

            Console.Write("\nPlease enter Deposite Amount? ");
            double amount = double.Parse(Console.ReadLine());

            DepositeBalanceToClientByAccountNumber(accountNumber, amount, ref lClients);

        }

        static void GoBackToTransctionsMenu()
        {

            Console.Write("\nPress any key to go back to Transactions Menu...");
            Console.ReadKey();

            ShowTransactionsMenuScreen();

        }

        static void ShowWithDrawScreen()
        {

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(Tabs(1) + "Withdraw Screen");
            Console.WriteLine("--------------------------------------------");

            string accountNumber = ReadAccountNumber();

            List<stClient> lClients = LoadClientsDataFromFile();

            stClient client = new stClient();

            while (!FindClientByAccountNumber(accountNumber, lClients, ref client))
            {

                Console.WriteLine($"\nClient with Account Number [{accountNumber}] doesn't exists.");

                accountNumber = ReadAccountNumber();

            }

            PrintClientCard(client);

            Console.Write("\nPlease enter Withdraw Amount ? ");
            double amount = double.Parse(Console.ReadLine());

            while (amount > client.accountBalance)
            {

                Console.WriteLine($"\nAmount Exceeds the balance, you can withdraw up to {client.accountBalance}");
                Console.Write("Please enter another amount? ");
                amount = double.Parse(Console.ReadLine());

            }

            DepositeBalanceToClientByAccountNumber(accountNumber, amount * -1, ref lClients);

        }

        static void PrintClientRecordBalanceLine(stClient client)
        {

            Console.Write($"| {client.accountNumber.PadRight(15)}");
            Console.Write($"| {client.name.PadRight(40)}");
            Console.WriteLine($"| {client.accountBalance.ToString().PadRight(16)}");

        }

        static void ShowTotalBalancesScreen()
        {

            List<stClient> lClients = LoadClientsDataFromFile();

            Console.WriteLine($"\n{Tabs(3)}Balances List ({lClients.Count}) Client(s)");

            Console.WriteLine("______________________________________________________________________________________________________\n");

            Console.Write($"| {"Account Number".PadRight(15)}");
            Console.Write($"| {"Client Name".PadRight(40)}");
            Console.WriteLine($"| {"Balance".PadRight(16)}");

            Console.WriteLine("______________________________________________________________________________________________________\n");

            double totalBalances = 0;

            if (lClients.Count == 0)
            {

                Console.WriteLine("\nNo Clients Available In The System!");

            }
            else
            {

                foreach (stClient client in lClients)
                {

                    PrintClientRecordBalanceLine(client);

                    totalBalances += client.accountBalance;

                }

            }

            Console.WriteLine("______________________________________________________________________________________________________\n");

            Console.WriteLine($"{Tabs(3)}Total Balances is: {totalBalances}");

        }

        static void PerformTransactionsMenu(enTransactionsMenuOption transactionsMenuOption)
        {

            switch (transactionsMenuOption)
            {

                case enTransactionsMenuOption.eDeposite:
                    Console.Clear();
                    ShowDepositeScreen();
                    GoBackToTransctionsMenu();
                    break;

                case enTransactionsMenuOption.eWithdraw:
                    Console.Clear();
                    ShowWithDrawScreen();
                    GoBackToTransctionsMenu();
                    break;

                case enTransactionsMenuOption.eTotalBalances:
                    Console.Clear();
                    ShowTotalBalancesScreen();
                    GoBackToTransctionsMenu();
                    break;


                case enTransactionsMenuOption.eMainMenu:
                    ShowMainMenuScreen();
                    break;

            }

        }

        static void ShowTransactionsMenuScreen()
        {

            if (!CheckAccessPermission(enMainMenuePermissions.pTransactions))
            {
                ShowAccessDeniedMessage();
                GoBackToMainMenu();
                return;
            }

            Console.Clear();

            Console.WriteLine("============================================");
            Console.WriteLine(Tabs(1) + "Transactions Menu Screen");
            Console.WriteLine("============================================");

            Console.WriteLine(Tabs(1) + "[1] Deposite.");
            Console.WriteLine(Tabs(1) + "[2] Withdraw.");
            Console.WriteLine(Tabs(1) + "[3] Total Balances.");
            Console.WriteLine(Tabs(1) + "[4] Main Menu.");

            Console.WriteLine("============================================");

            PerformTransactionsMenu((enTransactionsMenuOption)ReadTransactionsMenuOption());


        }

        enum enManageUsersMenuOption { eListUsers = 1, eAddNewUser = 2, eDeleteUser = 3, eUpdateUser = 4, eFindUser = 5, eMainMenu = 6 }

        static short ReadManageUsersOption()
        {

            short choice;

            do
            {

                Console.Write("\nChoose what do you want to do? [1 to 6]? ");
                choice = short.Parse(Console.ReadLine());

            } while (choice < 1 || choice > 6);

            return choice;

        }

        static void PrintUserRecordLine(stUser user)
        {

            Console.Write($"| {user.userName.PadRight(15)}");
            Console.Write($"| {user.password.PadRight(10)}");
            Console.Write($"| {user.permissions.ToString().PadRight(12)}");

        }

        static void ShowUsersListScreen()
        {

            List<stUser> lUsers = LoadUsersDataFromFile(usersFile);

            Console.WriteLine($"\n{Tabs(4)}Users List ({lUsers.Count}) User(s)");

            Console.WriteLine("______________________________________________________________________________________________\n");

            Console.Write($"| {"User Name".PadRight(15)}");
            Console.Write($"| {"Password".PadRight(10)}");
            Console.WriteLine($"| {"Permissions".PadRight(12)}");

            Console.WriteLine("______________________________________________________________________________________________\n");

            if (lUsers.Count == 0)
            {

                Console.WriteLine(Tabs(4) + "\nNo Users Available In The System!");

            }
            else
            {

                foreach (stUser user in lUsers)
                {
                    PrintUserRecordLine(user);
                    Console.WriteLine();
                }

            }

            Console.WriteLine("\n______________________________________________________________________________________________\n");

        }

        static void GoBackToManageUsersMenu()
        {

            Console.Write("\nPress any key to go back to Manage Users Menu...");
            Console.ReadKey();

            ShowManageUsersMenuScreen();

        }

        static bool UserExistsByUsername(string userName, string fileName)
        {

            if (File.Exists(fileName))
            {

                using (StreamReader reader = new StreamReader(fileName))
                {

                    string dataLine = "";

                    stUser user;

                    while ((dataLine = reader.ReadLine()) != null)
                    {

                        user = ConvertUserLineToRecord(dataLine);

                        if (user.userName == userName)
                        {
                            return true;
                        }

                    }

                }

            }

            return false;

        }

        static int ReadPermissionsToSet()
        {

            Console.Write("\nDo you want to give full access? y/n? ");
            char answer = Console.ReadKey().KeyChar;

            Console.WriteLine();

            if (char.ToUpper(answer) == 'Y')
            {

                return -1;

            }

            int permissions = 0;

            Console.WriteLine("\nDo you want to give access to:");

            Console.Write("\nShow Client List? y/n? ");
            answer = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            permissions += (int)(answer == 'Y' ? enMainMenuePermissions.pShowClientList : 0);

            Console.Write("\nAdd New Client? y/n? ");
            answer = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            permissions += (int)(answer == 'Y' ? enMainMenuePermissions.pAddNewClient : 0);

            Console.Write("\nDelete Client? y/n? ");
            answer = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            permissions += (int)(answer == 'Y' ? enMainMenuePermissions.pDeleteClient : 0);

            Console.Write("\nUpdate Client? y/n? ");
            answer = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            permissions += (int)(answer == 'Y' ? enMainMenuePermissions.pUpdateClient : 0);

            Console.Write("\nFind Client? y/n? ");
            answer = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            permissions += (int)(answer == 'Y' ? enMainMenuePermissions.pFindClient : 0);

            Console.Write("\nTransactions? y/n? ");
            answer = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            permissions += (int)(answer == 'Y' ? enMainMenuePermissions.pTransactions : 0);

            Console.Write("\nManage Users? y/n? ");
            answer = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            permissions += (int)(answer == 'Y' ? enMainMenuePermissions.pManageUsers : 0);

            return permissions;

        }

        static stUser ReadNewUser()
        {

            stUser user = new stUser();

            user.userName = ReadUserName();

            while (UserExistsByUsername(user.userName, usersFile))
            {

                Console.Write($"\nUser with [{user.userName}] already exists, Enter another Username? ");
                user.userName = Console.ReadLine().Trim();

            }

            Console.Write("Enter Password? ");
            user.password = Console.ReadLine();

            user.permissions = ReadPermissionsToSet();

            return user;

        }

        static string ConvertUserRecordToLine(stUser user, string separator = "#//#")
        {

            string dataLine;

            dataLine = user.userName + separator;
            dataLine += user.password + separator;
            dataLine += user.permissions;

            return dataLine;

            //return $"{user.userName}{separator}{user.password}{separator}{user.permissions}";

        }

        static void AddNewUser()
        {

            stUser user = ReadNewUser();

            AddDataLineToFile(ConvertUserRecordToLine(user), usersFile);

        }

        static void AddNewUsers()
        {

            char addMore;

            do
            {

                Console.WriteLine("\nAdding new user:");

                AddNewUser();

                Console.Write("\nUser Added Succefully, Do you want to add more users? y/n? ");
                addMore = char.ToUpper(Console.ReadKey().KeyChar);

                Console.WriteLine();

            } while (addMore == 'Y');

        }

        static void ShowAddNewUsersScreen()
        {

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(Tabs(1) + "Add New Users Screen");
            Console.WriteLine("--------------------------------------------");

            AddNewUsers();

        }

        static void MarkUserForDelete(string userName, ref List<stUser> lUsers)
        {

            for (int i = 0; i < lUsers.Count; i++)
            {

                if (lUsers[i].userName == userName)
                {

                    stUser u = lUsers[i];

                    u.markForDelete = true;

                    lUsers[i] = u;

                    break;

                }

            }

        }

        static bool FindUserByUsername(string userName, List<stUser> lUsers, ref stUser user)
        {

            foreach (stUser u in lUsers)
            {

                if (u.userName == userName)
                {

                    user = u;
                    return true;

                }

            }

            return false;

        }

        static void PrintUserCard(stUser user)
        {

            Console.WriteLine("\nThe following are the user details:");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Username    : {user.userName}");
            Console.WriteLine($"Password    : {user.password}");
            Console.WriteLine($"Permissions : {user.permissions}");
            Console.WriteLine("-------------------------------------");

        }

        static void SaveUsersListToFile(List<stUser> lUsers)
        {

            if (File.Exists(usersFile))
            {

                using (StreamWriter writer = new StreamWriter(usersFile))
                {

                    string dataLine;

                    foreach (stUser user in lUsers)
                    {

                        if (!user.markForDelete)
                        {

                            dataLine = ConvertUserRecordToLine(user);

                            writer.WriteLine(dataLine);

                        }

                    }

                }

            }
            else
            {
                Console.WriteLine($"\nThe file with name [{usersFile}] not found!.");
            }

        }

        static void DeleteUserByUsername(string userName, ref List<stUser> lUsers)
        {

            stUser user = new stUser();

            if (FindUserByUsername(userName, lUsers, ref user))
            {

                if (user.userName != lUsers[0].userName)
                {

                    PrintUserCard(user);

                    Console.Write("\nAre you sure you want delete this user? y/n? ");
                    char confirm = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();

                    if (confirm == 'Y')
                    {

                        MarkUserForDelete(userName, ref lUsers);

                        SaveUsersListToFile(lUsers);

                        // Refresh Users List
                        lUsers = LoadUsersDataFromFile(usersFile);

                        Console.WriteLine("\nUser deleted successfully.");

                    }
                    else
                    {
                        Console.WriteLine("\nDeletion cancelled.");
                    }

                }
                else
                {
                    Console.WriteLine($"\nYou cannot delete this user.");
                }

            }
            else
            {
                Console.WriteLine($"\nThe user with name [{userName}] doesn't exist.");
            }

        }

        static void ShowDeleteUserScreen()
        {

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(Tabs(1) + "Delete Users Screen");
            Console.WriteLine("--------------------------------------------");

            string userName = ReadUserName();

            List<stUser> lUsers = LoadUsersDataFromFile(usersFile);

            DeleteUserByUsername(userName, ref lUsers);

        }

        static stUser ChangeUserRecord(string userName)
        {

            stUser user = new stUser();

            user.userName = userName;

            Console.Write("\nEnter Password? ");
            user.password = Console.ReadLine();

            user.permissions = ReadPermissionsToSet();

            return user;

        }

        static void UpdateUserByUsername(string userName, ref List<stUser> lUsers)
        {

            stUser user = new stUser();

            if (FindUserByUsername(userName, lUsers, ref user))
            {

                PrintUserCard(user);

                Console.Write("\nAre you sure you want to update this user? y/n? ");
                char confirm = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (confirm == 'Y')
                {

                    for (int i = 0; i < lUsers.Count; i++)
                    {

                        if (lUsers[i].userName == userName)
                        {

                            lUsers[i] = ChangeUserRecord(userName);

                            break;

                        }

                    }

                    SaveUsersListToFile(lUsers);

                    Console.WriteLine("\n\nUser Updated Successfully.");

                }
                else
                {
                    Console.WriteLine("\nUpdating Cancelled.");
                }

            }
            else
            {
                Console.WriteLine($"\nThe User With Username [{userName}] is not found!.");
            }

        }

        static void ShowUpdateUserScreen()
        {

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(Tabs(1) + "Update Users Screen");
            Console.WriteLine("--------------------------------------------");

            string userName = ReadUserName();

            List<stUser> lUsers = LoadUsersDataFromFile(usersFile);

            UpdateUserByUsername(userName, ref lUsers);

        }

        static void ShowFindUserScreen()
        {

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(Tabs(1) + "Find Users Screen");
            Console.WriteLine("--------------------------------------------");

            string userName = ReadUserName();

            List<stUser> lUsers = LoadUsersDataFromFile(usersFile);

            stUser user = new stUser();

            if (FindUserByUsername(userName, lUsers, ref user))
            {

                PrintUserCard(user);

            }
            else
            {
                Console.WriteLine($"\nUser with Username [{userName}] is not found!");
            }

        }

        static void PerformManageUsersMenuOption(enManageUsersMenuOption manageUsersMenuOption)
        {

            switch (manageUsersMenuOption)
            {

                case enManageUsersMenuOption.eListUsers:
                    Console.Clear();
                    ShowUsersListScreen();
                    GoBackToManageUsersMenu();
                    break;

                case enManageUsersMenuOption.eAddNewUser:
                    Console.Clear();
                    ShowAddNewUsersScreen();
                    GoBackToManageUsersMenu();
                    break;

                case enManageUsersMenuOption.eDeleteUser:
                    Console.Clear();
                    ShowDeleteUserScreen();
                    GoBackToManageUsersMenu();
                    break;

                case enManageUsersMenuOption.eUpdateUser:
                    Console.Clear();
                    ShowUpdateUserScreen();
                    GoBackToManageUsersMenu();
                    break;

                case enManageUsersMenuOption.eFindUser:
                    Console.Clear();
                    ShowFindUserScreen();
                    GoBackToManageUsersMenu();
                    break;

                case enManageUsersMenuOption.eMainMenu:
                    Console.Clear();
                    ShowMainMenuScreen();
                    break;

            }

        }

        static void ShowManageUsersMenuScreen()
        {

            if (!CheckAccessPermission(enMainMenuePermissions.pManageUsers))
            {
                ShowAccessDeniedMessage();
                GoBackToMainMenu();
                return;
            }

            Console.Clear();

            Console.WriteLine("============================================");
            Console.WriteLine(Tabs(1) + "Manage Users Menu Screen");
            Console.WriteLine("============================================");

            Console.WriteLine(Tabs(1) + "[1] Users List.");
            Console.WriteLine(Tabs(1) + "[2] Add New User.");
            Console.WriteLine(Tabs(1) + "[3] Delete User.");
            Console.WriteLine(Tabs(1) + "[4] Update User.");
            Console.WriteLine(Tabs(1) + "[5] Find User.");
            Console.WriteLine(Tabs(1) + "[6] Main Menu.");

            Console.WriteLine("============================================");

            PerformManageUsersMenuOption((enManageUsersMenuOption)ReadManageUsersOption());

        }

        static void PerformMainMenuOption(enMainMenuOption mainMenuOption)
        {

            switch (mainMenuOption)
            {

                case enMainMenuOption.eClientList:
                    Console.Clear();
                    ShowClientList();
                    GoBackToMainMenu();
                    break;

                case enMainMenuOption.eAddNewClient:
                    Console.Clear();
                    ShowAddNewClientsScreen();
                    GoBackToMainMenu();
                    break;

                case enMainMenuOption.eDeleteClient:

                    Console.Clear();
                    ShowDeleteClientScreen();
                    GoBackToMainMenu();
                    break;

                case enMainMenuOption.eUpdateClient:

                    Console.Clear();
                    ShowUpdateClientScreen();
                    GoBackToMainMenu();
                    break;

                case enMainMenuOption.eFindClient:

                    Console.Clear();
                    ShowFindClientScreen();
                    GoBackToMainMenu();
                    break;

                case enMainMenuOption.eTransactions:

                    Console.Clear();
                    ShowTransactionsMenuScreen();
                    break;

                case enMainMenuOption.eManageUsers:

                    Console.Clear();
                    ShowManageUsersMenuScreen();
                    break;

                case enMainMenuOption.eLogout:
                    Console.Clear();
                    Login();
                    break;

            }

        }

        static void ShowMainMenuScreen()
        {

            Console.Clear();

            Console.WriteLine("============================================");
            Console.WriteLine(Tabs(2) + "Main Menu Screen");
            Console.WriteLine("============================================");

            Console.WriteLine(Tabs(1) + "[1] Show Client List.");
            Console.WriteLine(Tabs(1) + "[2] Add New Client.");
            Console.WriteLine(Tabs(1) + "[3] Delete Client.");
            Console.WriteLine(Tabs(1) + "[4] Update Client Info.");
            Console.WriteLine(Tabs(1) + "[5] Find Client.");
            Console.WriteLine(Tabs(1) + "[6] Transactions.");
            Console.WriteLine(Tabs(1) + "[7] Manage Users.");
            Console.WriteLine(Tabs(1) + "[8] Logout.");

            Console.WriteLine("============================================");

            PerformMainMenuOption(ReadMainMenuOption());

        }

        static bool LoadUserInfo(string userName, string password)
        {
            return FindUserByUserNameAndPassword(userName, password, ref currentUser);
        }

        static void Login()
        {

            bool loadFailed = false;

            string userName, password;

            do
            {

                Console.Clear();

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine(Tabs(2) + "Login Screen");
                Console.WriteLine("--------------------------------------------");

                if (loadFailed)
                {
                    Console.WriteLine("\nInvalid Username/Password!");
                }

                userName = ReadUserName();
                password = ReadPassword();

                loadFailed = !LoadUserInfo(userName, password);

            } while (loadFailed);

            ShowMainMenuScreen();

        }

        static void Main(string[] args)
        {

            Login();

        }
    }
}
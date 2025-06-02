namespace Project_2_ATM_System
{
    internal class Program
    {

        public static string clientsFile = "Clients.txt";

        static string Tabs(short numberOfTabs)
        {

            string tabs = "";

            for (short i = 0; i < numberOfTabs; i++)
            {
                tabs += "\t";
            }

            return tabs;

        }

        static string ReadAccountNumber()
        {

            Console.Write("\nEnter Account Number? ");
            string accountNumber = Console.ReadLine().Trim();

            return accountNumber;

        }

        static string ReadPinCode()
        {

            Console.Write("\nEnter PIN Code? ");
            string pinCode = Console.ReadLine();

            return pinCode;

        }

        public struct stClient
        {

            public string accountNumber;
            public string pinCode;
            public string name;
            public string phone;
            public double accountBalance;
            public bool markForDelete;

        }

        public static stClient currentClient = new stClient();

        static List<string> SplitString(string s, string delim)
        {

            List<string> lWord = new List<string>();

            short pos = 0;
            string word = "";

            while ((pos = (short)s.IndexOf(delim)) != -1)
            {

                word = s.Substring(0, pos);

                if (word != " ")
                {

                    lWord.Add(word);

                }

                s = s.Substring(pos + delim.Length);

            }

            if (s != "")
            {
                lWord.Add(s);
            }

            return lWord;

        }

        static stClient ConvertClientLineToRecord(string dataLine, string separator = "#//#")
        {

            stClient client;

            List<string> lClientData = SplitString(dataLine, separator);

            client.accountNumber = lClientData[0];
            client.pinCode = lClientData[1];
            client.name = lClientData[2];
            client.phone = lClientData[3];
            client.accountBalance = double.Parse(lClientData[4]);
            client.markForDelete = false;

            return client;

        }

        static List<stClient> LoadClientsFromFile(string fileName)
        {

            List<stClient> lClients = new List<stClient>();

            if (File.Exists(fileName))
            {

                using (StreamReader reader = new StreamReader(fileName))
                {

                    string dataLine = "";
                    stClient client;

                    while ((dataLine = reader.ReadLine()) != null)
                    {

                        client = ConvertClientLineToRecord(dataLine);

                        lClients.Add(client);

                    }

                }

            }
            else
            {
                Console.WriteLine($"\nThe file with name [{fileName}] is not found!");
            }

            return lClients;

        }

        static bool FindClientByAccountNumberAndPinCode(string accountNumber, string pinCode, ref stClient client)
        {

            List<stClient> lClients = LoadClientsFromFile(clientsFile);

            foreach (stClient c in lClients)
            {

                if (c.accountNumber == accountNumber && c.pinCode == pinCode)
                {
                    client = c;
                    return true;
                }

            }

            return false;

        }

        static bool LoadClientInfo(string accountNumber, string pinCode)
        {

            return FindClientByAccountNumberAndPinCode(accountNumber, pinCode, ref currentClient);

        }

        enum enMainMenuOption
        {

            eQuickWithdraw = 1, eNormalWithdraw = 2, eDeposite = 3, eCheckBalance = 4, eLogout = 5

        }

        static enMainMenuOption ReadMainMenuOption()
        {

            short choice;

            do
            {

                Console.Write("Choose What do you want to do? [1:5]? ");
                choice = short.Parse(Console.ReadLine());

            } while (choice < 1 || choice > 5);

            return (enMainMenuOption)choice;

        }

        static short ReadQuickWithdrawOption()
        {

            short choice;

            do
            {

                Console.Write("\nChoose what to do from [1] to [9]? ");
                choice = short.Parse(Console.ReadLine());

            } while (choice < 1 || choice > 9);

            return choice;

        }

        static short GetQuickWithdrawAmount(short quickWithdrawOption)
        {

            switch (quickWithdrawOption)
            {

                case 1:
                    return 20;

                case 2:
                    return 50;

                case 3:
                    return 100;

                case 4:
                    return 200;

                case 5:
                    return 400;

                case 6:
                    return 600;

                case 7:
                    return 800;

                case 8:
                    return 1000;

                default:
                    return 0;

            }

        }

        static void PerformQuickWithdrawOption(short quickWithdrawOption)
        {

            if (quickWithdrawOption == 9) // Exit
            {
                return;
            }

            short withdrawAmount = GetQuickWithdrawAmount(quickWithdrawOption);

            if (withdrawAmount > currentClient.accountBalance)
            {

                Console.WriteLine("\nThe amount exceeds your balance, make another choice.");

                Console.Write("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();

                ShowNormalWithdrawScreen();

                return;

            }

            List<stClient> lClients = LoadClientsFromFile(clientsFile);

            if (DepositeBalanceToClient(currentClient.accountNumber, withdrawAmount * -1, ref lClients))
            {
                currentClient.accountBalance -= withdrawAmount;
            }

        }

        static string ConvertClientRecordToLine(stClient client, string separator = "#//#")
        {

            return $"{client.accountNumber}{separator}{client.pinCode}{separator}{client.name}{separator}{client.phone}{separator}{client.accountBalance}";

        }

        static void SaveClientsListToFile(List<stClient> lClients)
        {

            if (File.Exists(clientsFile))
            {

                using (StreamWriter writer = new StreamWriter(clientsFile))
                {

                    string dataLine = "";

                    foreach (stClient c in lClients)
                    {

                        if (!c.markForDelete)
                        {
                            dataLine = ConvertClientRecordToLine(c);

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

        static bool DepositeBalanceToClient(string accountNumber, double amount, ref List<stClient> lClients)
        {

            Console.Write("\nAre you sure you want perform this transaction? (Y/N)? ");
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

                        Console.WriteLine($"\n\nDone Successfully, New balance is: {lClients[i].accountBalance}");

                        return true;

                    }

                }

            }

            return false;

        }

        static void ShowQuickWithdrawScreen()
        {

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine(Tabs(2) + "Quick Withdraw Screen");
            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine($"{Tabs(1)}[1] 20 {Tabs(2)}[2] 50");
            Console.WriteLine($"{Tabs(1)}[3] 100{Tabs(2)}[4] 200");
            Console.WriteLine($"{Tabs(1)}[5] 400{Tabs(2)}[6] 600");
            Console.WriteLine($"{Tabs(1)}[7] 800{Tabs(2)}[8] 1000");
            Console.WriteLine(Tabs(1) + "[9] Exit");

            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine($"Your Balance is {currentClient.accountBalance}");

            PerformQuickWithdrawOption(ReadQuickWithdrawOption());

        }

        static void GobackToMainMenu()
        {

            Console.Write("\nPress any key to go back to Main Menu...");
            Console.ReadKey();

            ShowMainMenuScreen();

        }

        static int ReadNormalAmount()
        {

            int amount;

            do
            {

                Console.Write("\nEnter an amount multiple of 5's ? ");
                amount = int.Parse(Console.ReadLine());

            } while ((amount % 5) != 0);

            return amount;

        }

        static void PerformNormalWithdrawOption()
        {

            int withdrawAmount = ReadNormalAmount();

            if (withdrawAmount > currentClient.accountBalance)
            {

                Console.WriteLine("\nThe amount exceeds your balance, make another choice.");

                Console.Write("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();

                ShowNormalWithdrawScreen();

                return;

            }

            List<stClient> lClients = LoadClientsFromFile(clientsFile);

            if (DepositeBalanceToClient(currentClient.accountNumber, withdrawAmount * -1, ref lClients))
            {
                currentClient.accountBalance -= withdrawAmount;
            }

        }

        static void ShowNormalWithdrawScreen()
        {

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine(Tabs(2) + "Normal Withdraw Screen");
            Console.WriteLine("---------------------------------------------------");

            PerformNormalWithdrawOption();

        }

        static double ReadDepositeAmount()
        {

            double amount;

            do
            {

                Console.Write("\nEnter a positive Deposite Amount ? ");
                amount = double.Parse(Console.ReadLine());

            } while (amount <= 0);

            return amount;

        }

        static void PerformDepositOption()
        {

            double depositeAmount = ReadDepositeAmount();

            List<stClient> lClients = LoadClientsFromFile(clientsFile);

            if (DepositeBalanceToClient(currentClient.accountNumber, depositeAmount, ref lClients))
            {
                currentClient.accountBalance += depositeAmount;
            }

        }

        static void ShowDepositeScreen()
        {

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine(Tabs(2) + "Deposite Screen");
            Console.WriteLine("---------------------------------------------------");

            PerformDepositOption();

        }

        static void ShowCheckBalanceScreen()
        {

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine(Tabs(2) + "Check Balance Screen");
            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine($"\nYour Balance is {currentClient.accountBalance}");

        }

        static void PerformMainMenuOption(enMainMenuOption mainMenuOption)
        {

            switch (mainMenuOption)
            {

                case enMainMenuOption.eQuickWithdraw:
                    Console.Clear();
                    ShowQuickWithdrawScreen();
                    GobackToMainMenu();
                    break;

                case enMainMenuOption.eNormalWithdraw:
                    Console.Clear();
                    ShowNormalWithdrawScreen();
                    GobackToMainMenu();
                    break;

                case enMainMenuOption.eDeposite:
                    Console.Clear();
                    ShowDepositeScreen();
                    GobackToMainMenu();
                    break;

                case enMainMenuOption.eCheckBalance:
                    Console.Clear();
                    ShowCheckBalanceScreen();
                    GobackToMainMenu();
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

            Console.WriteLine("==============================================");
            Console.WriteLine(Tabs(2) + "ATM Main Menu Screen");
            Console.WriteLine("==============================================");

            Console.WriteLine(Tabs(1) + "[1] Quick Withdraw.");
            Console.WriteLine(Tabs(1) + "[2] Normal Withdraw.");
            Console.WriteLine(Tabs(1) + "[3] Deposit.");
            Console.WriteLine(Tabs(1) + "[4] Check Balance.");
            Console.WriteLine(Tabs(1) + "[5] Logout.");

            Console.WriteLine("==============================================");

            PerformMainMenuOption(ReadMainMenuOption());

        }

        static void Login()
        {

            bool loginFailed = false;

            string accountNumber, pinCode;

            do
            {

                Console.Clear();

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine(Tabs(2) + "Login Screen");
                Console.WriteLine("----------------------------------------------");

                if (loginFailed)
                {
                    Console.WriteLine("\nInvalid Account Number/PinCode!");
                }

                accountNumber = ReadAccountNumber();

                pinCode = ReadPinCode();

                loginFailed = !LoadClientInfo(accountNumber, pinCode);

            } while (loginFailed);

            ShowMainMenuScreen();

        }

        static void Main(string[] args)
        {

            Login();

        }
    }
}
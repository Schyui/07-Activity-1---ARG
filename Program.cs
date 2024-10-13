namespace UserNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Admin's Login");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter id: ");
            string idz = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            Console.Clear();

            Administrator admin = new Administrator(name, idz, password);          

        }
    }

    abstract class User {
        private string user_id;
        protected string user_password;
        public User(string id, string pass) { 
            this.user_id = id;
            this.user_password = pass;
        }
        public bool verifyLogin(string id, string pass)
        {
                Console.WriteLine("Logged in!");
                return true;
        }
        public abstract void updatePassword(string newPassword);
    }
    class Administrator: User
    {
        private string admin_name;
        public Administrator(string name, string id, string pass) : base(id, pass) { 
            this.admin_name = name;
            
            if (admin_name.Equals("elieza") && id.Equals("123") && pass.Equals("cutie"))
            {
                verifyLogin(id, pass);
                Console.WriteLine("welcome, Admin!");
                AccountSystem();
            }
            else {
                Console.WriteLine("You are not the admin. Exiting...");
            }
        }
        public override void updatePassword(string newPassword) { 
            this.user_password = newPassword;
            Console.WriteLine("Password changed!\nNew Password: " + user_password);
            Console.WriteLine();
        }
        public void updateAdminName(string name) { 
            this.admin_name=name;
            Console.WriteLine("Name changed!\nNew Name: "+admin_name);
            Console.WriteLine();
        }
        //additional account system 
        public void AccountSystem() {
            bool isCorrectSetInput = true;
            while (isCorrectSetInput)
            {
                Console.Write("Account Settings (\"S\"): ");
                string pick = Console.ReadLine().ToUpper();
                Console.Clear();
                if (pick[0] == 'S')
                {
                    isCorrectSetInput = false;
                    bool isCorrectChangeInput = true;
                    while (isCorrectChangeInput)
                    {
                        Console.WriteLine("ACCOUNT SETTINGS\n1. Change name\n2. Change password\n3. Exit");
                        Console.Write("Enter: ");
                        int chooseChange = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        if (chooseChange == 2)
                        {
                            Console.Write("Do you want to change your password (y/n)? ");
                            char pickPass = Convert.ToChar(Console.ReadLine());
                            Console.Clear();
                            if (pickPass == 'y')
                            {
                                Console.Write("Enter new Password: ");
                                string newPassword = Console.ReadLine();
                                Console.Clear();
                                updatePassword(newPassword);
                            }
                            else if (pickPass == 'n')
                            {
                                Console.WriteLine("GOTCHA");
                            }
                            continue;
                        }
                        else if (chooseChange == 1)
                        {
                            Console.Write("Do you want to change your name (y/n)? ");
                            char pickPass = Convert.ToChar(Console.ReadLine());
                            Console.Clear();
                            if (pickPass == 'y')
                            {
                                Console.Write("Enter new Name: ");
                                string newName = Console.ReadLine();
                                Console.Clear();
                                updateAdminName(newName);
                            }
                            else if (pickPass == 'n')
                            {
                                Console.WriteLine("GOTCHA");
                            }
                            continue;
                        }
                        else if (chooseChange == 3)
                        {
                            Console.WriteLine("Exiting...");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }
            }
        }
    }
}
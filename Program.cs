using System;
using System.Collections.Generic;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup key variables.
            int index = 0;
            bool check = false;

            // Prompt the user for the path for the login file.
            Console.Write("Enter path: ");
            string path = Console.ReadLine();
            
            // Read the login file.
            List<Account> userAccounts = readFile(path);

            // Check to see if reading the file was successful.
            if (userAccounts[0].getEmail() == "unknown") {
                // If reading the file failed, display error message.
                Console.WriteLine("ERROR: Unable to read file '" + path + "'");
            
            // If it worked, continue with the program.
            } else {
                // Prompt the user for their email.
                Console.Write("Email: ");
                string email = Console.ReadLine();

                // Check to see if the email is in one of the accounts.
                for (int i = 0; i < userAccounts.Count; i++)
                {
                    // If email passes the check, set check to true and set count.
                    if (userAccounts[i].getEmail() == email){
                        check = true;
                        index = i;
                        break;
                    }
                }

                // If an email was found, continue with the program.
                if (check)
                {
                    // Prompt the user for the password.
                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    // Check to see if that is correct password.
                    if (userAccounts[index].getPassword() == password)
                    {
                        // If the password is correct, continue the program.
                        // Greet the user and display information.
                        Console.WriteLine("Welcome, " + userAccounts[index].getName());
                        Console.WriteLine("Email: " + userAccounts[index].getEmail());
                        Console.WriteLine("Phone: " + userAccounts[index].getPhone());
                    } else {
                        // If password fails, display message.
                        Console.WriteLine("ERROR: Password is incorrect");
                    }
                } else {
                    // If the email is not found, display error message.
                    Console.WriteLine("ERROR: Email '" + email + "' Not Found");
                }
            }
        }

        static List<Account> readFile(string path)
        {
            // Create the list that stores the accounts.
            List<Account> userAccounts = new List<Account>();

            // Try to open the file.
            try
            {
                // Open and read the file.
                string[] lines = System.IO.File.ReadAllLines(path);

                // Read the data line by line
                foreach(string line in lines)
                {
                    // Split the line according to where the commas are.
                    string[] columns = line.Split(',');

                    // Make a new user account.
                    Account newAccount = new Account();

                    // Add all the values to the object.
                    newAccount.setName(columns[0]);
                    newAccount.setPhone(columns[1]);
                    newAccount.setPassword(columns[2]);
                    newAccount.setEmail(columns[3]);

                    // Add the object to the list of users.
                    userAccounts.Add(newAccount);
                }
            }
            // If reading the file failed, return a blank
            catch (Exception ex)
            {
                // Create a blank object.
                Account blankAccount = new Account();

                // Add to the list.
                userAccounts.Add(blankAccount);
            }

            // Return the user accounts.
            return userAccounts;
        }
    }

    class Account
    {
        // The member data.
        private string name;
        private string email;
        private string password;
        private string phone;

        // The class constructor.
        public Account()
        {
            name = "unknown";
            email = "unknown";
            password = "unknown";
            phone = "5555555555";
        }

        public void setName(string newName)
        {
            name = newName;
        }
        public string getName()
        {
            return name;
        }
        public void setEmail(string newEmail)
        {
            email = newEmail;
        }
        public string getEmail()
        {
            return email;
        }
        public void setPassword(string newPassword)
        {
            password = newPassword;
        }
        public string getPassword()
        {
            return password;
        }
        public void setPhone(string newPhone)
        {
            phone = newPhone;
        }
        public string getPhone()
        {
            return phone;
        }
    }
}

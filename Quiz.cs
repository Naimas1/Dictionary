using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Programі
    {
        private static readonly string dataFolderPath = "Data";
        private static readonly string usersFilePath = Path.Combine(dataFolderPath, "users.txt");
        private static readonly string quizzesFolderPath = Path.Combine(dataFolderPath, "Quizzes");

        public static void Main()
        {
            if (!Directory.Exists(dataFolderPath))
            {
                Directory.CreateDirectory(dataFolderPath);
            }

            if (!File.Exists(usersFilePath))
            {
                File.Create(usersFilePath).Close();
            }

            if (!Directory.Exists(quizzesFolderPath))
            {
                Directory.CreateDirectory(quizzesFolderPath);
            }

            Dictionary<string, User> users = GetLoadUsers();

            User currentUser = Login(users);

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Стартувати нову вікторину");
                Console.WriteLine("2. Переглянути результати минулих вікторин");
                Console.WriteLine("3. Переглянути Топ-20 з конкретної вікторини");
                Console.WriteLine("4. Змінити налаштування");
                Console.WriteLine("5. Вихід");

                Console.Write("Виберіть пункт меню: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StartQuiz(currentUser);
                        break;
                    case "2":
                        ShowPastQuizResults(currentUser);
                        break;
                    case "3":
                        ShowTop20ForQuiz();
                        break;
                    case "4":
                        ChangeSettings(currentUser);
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        private static Dictionary<string, User> GetLoadUsers()
        {
            throw new NotImplementedException();
        }

        public static void StartQuiz(User user)
        {
            // Логіка для старту вікторини.
        }

        public static void ShowPastQuizResults(User user)
        {
            // Логіка для перегляду результатів минулих вікторин.
        }

        public static void ShowTop20ForQuiz()
        {
            // Логіка для перегляду Топ-20 з конкретної вікторини.
        }

        public static void ChangeSettings(User user)
        {
            // Логіка для зміни налаштувань користувача.
        }

        public static void SaveUsers(Dictionary<string, User> users)
        {
            // Збереження користувачів у файл usersFilePath.
        }

        public static User Login(Dictionary<string, User> users)
        {
            // Логіка для входу користувача або реєстрації нового користувача.
            // Після успішного входу, повернення об'єкта User, який представляє поточного користувача.
        }
    }

    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public List<QuizResult> QuizResults { get; set; }
    }

    class QuizResult
    {
        public string QuizName { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}

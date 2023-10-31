// HomeWork template 1.4 // date: 17.10.2023

using Service;
using System;
using System.Linq.Expressions;
using System.Text;

/// QUESTIONS ///
/// 1. 

// HomeWork 10 : [{Анализатор кода}] --------------------------------

namespace IDA_C_sh_HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MainMenu.MainMenu mainMenu = new MainMenu.MainMenu();

            do
            {
                Console.Clear();
                mainMenu.Show_menu();
                if (mainMenu.User_Choice_Handle() == 0) break;
                Console.ReadKey();
            } while (true);
            // Console.ReadKey();
        }

        public static void Task_1(string work_name)
        /* Задание
         * Программа «Анализатор кода»
        Прочитать текст C#-программы (выбрать самостоятельно) и выполнить с ним:         
        1) все слова public в объявлении полей классов заменить на слово private. 
        2) в исходном коде в каждом слове длиннее двух символов все строчные символы заменить прописными. 
        3) также в коде программы удалить все «лишние» пробелы и табуляции, оставив только необходимые для разделения операторов. 
        4) Записать символы каждой строки программы в другой файл в обратном порядке. 
        */
        {
            Console.WriteLine("\n***\t{0}\n\n", work_name);

            // файл с внесенными изменениями по заданию
            string source_path = Directory.GetCurrentDirectory() + "\\test_code_source.cs";
            // файл с внесенными изиенеиями по заданию и инвертированный
            string inverted_path = Directory.GetCurrentDirectory() + "\\test_code_inverted.cs";

            // Выберем один из файлов текущего проекта и скопируем в строку для дальнейшей конверсии кода
            string[] files_at_project = Directory.GetFiles(Directory.GetCurrentDirectory());
            if (files_at_project == null) throw new Exception("FilesNotReadExeption");
            if (files_at_project.Length == 0 ) throw new Exception("FilesNotFoundExeption");
            string read_result;
            FileStream str_1 = new(files_at_project[0], FileMode.Open);
             {
                StreamReader streamReader_1 = new StreamReader(str_1);
                read_result = streamReader_1.ReadToEnd();
                read_result ??= string.Empty;
             }
            str_1.Close();

            // Блок изменений содержимого строки            
            string changed_code = read_result.Replace("public class", "private class");

            // уберем лишние табуляции
            var array_of_words = changed_code.Split('\t', StringSplitOptions.RemoveEmptyEntries);

            // собираем текст обратно в строку
            changed_code = string.Empty;
            foreach (string word in array_of_words) changed_code += word;

            // За счет опции StringSplitOptions.RemoveEmptyEntries удалим лишние пробелы
            array_of_words = changed_code.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // В словах больше 2-ух символов изменим регистр
            for (int i = 0; i < array_of_words.Length; i++)
                if (array_of_words[i].Length > 2) array_of_words[i] = array_of_words[i].ToUpper();

            // собираем текст обратно в строку
            changed_code = string.Empty;
            foreach (string word in array_of_words) changed_code += word;

            // Запишем в файл код с внесенными изменениями
            FileStream str_2 = new(source_path, FileMode.Create);             
            StreamWriter streamWriter_1 = new StreamWriter(str_2);
            streamWriter_1.Write(changed_code);
            streamWriter_1.Close();
            str_2.Close();

            // Разобъем код на строки
            array_of_words = changed_code.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            // Запишем в файл код с внесенными изменениями в инверсном порядке символы каждой строки программы
            FileStream str_3 = new(inverted_path, FileMode.Create);
            StreamWriter streamWriter_2 = new StreamWriter(str_3);
            foreach (string word in array_of_words) streamWriter_2.Write(word.Reverse());            
            streamWriter_2.Close();
            str_3.Close();
        }



    }// class Program
}// namespace
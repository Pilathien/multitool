using System;
using Multitool.Services.FileServices;

namespace Multitool
{
    class Program
    {
        private readonly FileService _fileService;
        
        public Program(FileService fileService)
        {
            _fileService = fileService;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("[1] - Load cookies\n[2] - Load combo\n[3] - Combo to cookies");

            /*string mode = Console.ReadLine();
            
            switch(mode)
            {
                case "1":
                    fileService.ReadCookies();
                    break;
                case "2":
                    fileService.ReadLogins();
                    break;
            }
            fileService.ReadLogins();*/
        }
    }
}
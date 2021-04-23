using System;
using System.Diagnostics;

namespace GitGoUpToheaven
{
    class Program
    {

        static void Main(string[] args)
        {
            string CaminhoRepositorio = null;
            string urlRepository = null;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Git Go Up To Heaven informe a opção:");
                Console.WriteLine("1 - Commit flash");
                Console.WriteLine("0 - exit");
                int menu;
                while (!(int.TryParse(Console.ReadLine(), out menu))) Console.WriteLine("Opção não numerica, digite novamente: ");
                switch (menu)
                {
                    case 1: CommitFlash(); break;
                    case 0: Console.Write("Finalizando..."); return;
                    default: Console.WriteLine("Nós não temos esta opção, escolhe novamente:"); break;
                }
            }

            void CommitFlash()
            {

                if (CaminhoRepositorio == null)
                {
                    Console.WriteLine("Informe caminho da pasta git");
                    CaminhoRepositorio = Console.ReadLine();
                }
                if(urlRepository  == null)
                {
                    Console.WriteLine("Informe a <github repository url> : ");
                    urlRepository = Console.ReadLine();
                }
                if (Util.Verificarfiledirectory(CaminhoRepositorio))
                {
                    Console.WriteLine("Descrição do commit:");
                    var descricaoCommit = "git commit -m \"" + Console.ReadLine() + "\" ";

                    //string comandoGitClone = @"/C " + "git clone " + CaminhoRepositorio;
                    ////Executa o comando no cmd do windows e aguarda a execução do mesmo para fechá-lo
                    ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
                    processStartInfo.RedirectStandardInput = true;
                    processStartInfo.RedirectStandardOutput = true;
                    processStartInfo.UseShellExecute = false;
                    Process process = Process.Start(processStartInfo);
                    process.StandardInput.WriteLine(@"cd " + CaminhoRepositorio);
                    process.StandardInput.WriteLine(@"git status");
                    process.StandardInput.WriteLine(@"git add *");
                    process.StandardInput.WriteLine(@"" + descricaoCommit + "");
                    process.StandardInput.WriteLine(@"git push " + urlRepository + "");

                }
                else { Console.WriteLine("Erro verifique o caminho do repositorio"); }

            }
        }

    }
}

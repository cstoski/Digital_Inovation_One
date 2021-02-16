using System;

namespace RevisaoInicialConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        //TODO: Adicionar Aluno
                        Console.WriteLine("informe o nome do Aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        
                        //Forma 1 - Mas se o usuario digitar uma letra dá erro
                        //Console.WriteLine("informe a nota do Aluno:");
                        //aluno.Nota = decimal.Parse(Console.ReadLine());

                        //Forma 2 -
                        Console.WriteLine("informe a nota do Aluno:");
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }
                        
                        //Insere o aluno na tabela e atualiza o valor do ìndice
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;

                    case "2":
                        //TODO: Listar Alunos
                        foreach (var item in alunos)
                        {
                            if (!string.IsNullOrEmpty(item.Nome))
                            {
                               Console.WriteLine($"Aluno: {item.Nome} - Nota: {item.Nota}"); 
                            }                            
                        }
                        break;

                    case "3":
                        //TODO: calcular Média geral
                        decimal notaTotal = 0;
                        var nrAlunos =0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal += alunos[i].Nota;
                                nrAlunos++;
                            } 
                        }
                            //calcula a média
                            var mediaGeral = notaTotal/nrAlunos;
                            Conceito conceitoGeral;

                            //Informação do Conceito para a Média Geral
                            switch (mediaGeral)
                            {
                                case var n when (n < 30):
                                    conceitoGeral = Conceito.E;
                                break;
                                
                                case var n when (n >= 30) && (n < 40):
                                    conceitoGeral = Conceito.D;
                                break;
                                case var n when (n >= 40) && (n < 50):
                                    conceitoGeral = Conceito.C;
                                break;
                                case var n when (n >= 50) && (n < 70):
                                    conceitoGeral = Conceito.B;
                                break;
                                case var n when (n >= 70) && (n < 100):
                                    conceitoGeral = Conceito.A;
                                break;

                                default:
                                throw new ArgumentOutOfRangeException();
                            }

                            Console.WriteLine($"Média Geral dos Alunos é: {mediaGeral} - Conceito: {conceitoGeral}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo Aluno");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - Calcular Média Geral");
            Console.WriteLine("x - Sair");
            Console.WriteLine();

            //Pega o Valor que o usuário digitar
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}

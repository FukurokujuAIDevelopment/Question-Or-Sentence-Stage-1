using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"log.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            try
            {
                //Reads the Language Files
                FileStream Subjects = new FileStream("Subjects.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
                FileStream Predicates = new FileStream("Predicates.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
                FileStream Objects = new FileStream("Objects.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
                FileStream Adverbs = new FileStream("Adverbs.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
                FileStream SentenceStructure = new FileStream("Sentence Structures.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
                StringSplitter(Subjects, Predicates, Objects, Adverbs, SentenceStructure);
            }
            catch (Exception e)
            {
                Console.WriteLine("Eine oder Mehrere Dateien konnten nicht gelesen werden!");
                Console.WriteLine("Bitte Kontaktiere mich auf GitHub oder hinterlasse ein Kommentar dort für weiter Hilfe");
                Console.WriteLine("Ich hoffe dass nun ein detailierter Errorreport erscheint");
                Console.WriteLine(e);
                Console.WriteLine("Bitte drücken sie ENTER um fortzufahren...");
                FileStream fs = new FileStream("Log.txt", FileMode.CreateNew, FileAccess.Write, FileShare.Write);
                string ErrorLog = e.ToString();
                StreamWriter fw = new StreamWriter(fs);
                fw.Write(ErrorLog);
                Console.ReadKey();
            }



        }
        static void StringSplitter(FileStream Subjects, FileStream Predicates, FileStream Objects, FileStream Adverbs, FileStream SentenceStructure)
        {
            string[] ListOfSubjects = new String[1000];
            string[] ListOfPredicates = new String[1000];
            string[] ListOfObjects = new String[1000];
            string[] ListOfAdverbs = new String[1000];
            string[] ListOfSentenceStructures = new String[1000];
            char[] LineDelimiter = new char[] { '*' };
            char[] IdentifierDelimiter = new Char[] { '+' };
            String SubjectsContent;
            String PredicatesContent;
            String ObjectsContent;
            String AdverbsContent;
            String SentenceStructureContent;


            AdverbsContent = Adverbs.ToString();
            string[] AdverbsContentFirstProcessingStage;
            AdverbsContentFirstProcessingStage = AdverbsContent.Split(LineDelimiter, StringSplitOptions.RemoveEmptyEntries);
            string[,] AdverbsContentFinal = new String[1000, 3];

            SentenceStructureContent = SentenceStructure.ToString();


            SubjectsContent = Subjects.ToString();
            string[] SubjectsContentFirstProcessingStage;
            SubjectsContentFirstProcessingStage = SubjectsContent.Split(LineDelimiter, StringSplitOptions.RemoveEmptyEntries);
            string[,] SubjectsContentFinal = new String[1000, 3];



            PredicatesContent = Predicates.ToString();
            string[] PredicatesContentFirstProcessingStage;
            PredicatesContentFirstProcessingStage = PredicatesContent.Split(LineDelimiter, StringSplitOptions.RemoveEmptyEntries);
            string[,] PredicatesContentFinal = new String[1000, 3];


            ObjectsContent = Objects.ToString();
            string[] ObjectsContentFirstProcessingStage;
            ObjectsContentFirstProcessingStage = ObjectsContent.Split(LineDelimiter, StringSplitOptions.RemoveEmptyEntries);
            string[,] ObjectsContentFinal = new String[1000, 3];



            int startPosDeclaration;
            int lengthDeclaration;
            int startPosWord;
            int lengthWord;
            int startPosMeaning;
            int lengthMeaning;

            for (int Counter = 0; Counter < SubjectsContentFirstProcessingStage.Length; Counter++)
            {
                startPosDeclaration = SubjectsContentFirstProcessingStage[Counter].LastIndexOf("*") + 1;
                lengthDeclaration = SubjectsContentFirstProcessingStage[Counter].IndexOf("+") - startPosDeclaration;
                SubjectsContentFinal[Counter, 0] = SubjectsContentFirstProcessingStage[Counter].Substring(startPosDeclaration, lengthDeclaration);

                startPosWord = SubjectsContentFirstProcessingStage[Counter].IndexOf("+") + 1;
                lengthWord = SubjectsContentFirstProcessingStage[Counter].IndexOf("-") - startPosWord;
                SubjectsContentFinal[Counter, 1] = SubjectsContentFirstProcessingStage[Counter].Substring(startPosWord, lengthWord);

                startPosMeaning = SubjectsContentFirstProcessingStage[Counter].LastIndexOf("-") + 1;
                lengthMeaning = SubjectsContentFirstProcessingStage[Counter].LastIndexOf("<") - startPosMeaning;
                SubjectsContentFinal[Counter, 2] = SubjectsContentFirstProcessingStage[Counter].Substring(startPosMeaning, lengthMeaning);


            }

            for (int Counter = 0; Counter < AdverbsContentFirstProcessingStage.Length; Counter++)
            {
                startPosDeclaration = AdverbsContentFirstProcessingStage[Counter].LastIndexOf("*") + 1;
                lengthDeclaration = AdverbsContentFirstProcessingStage[Counter].IndexOf("+") - startPosDeclaration;
                AdverbsContentFinal[Counter, 0] = AdverbsContentFirstProcessingStage[Counter].Substring(startPosDeclaration, lengthDeclaration);

                startPosWord = AdverbsContentFirstProcessingStage[Counter].IndexOf("+") + 1;
                lengthWord = AdverbsContentFirstProcessingStage[Counter].IndexOf("-") - startPosWord;
                AdverbsContentFinal[Counter, 1] = AdverbsContentFirstProcessingStage[Counter].Substring(startPosWord, lengthWord);

                startPosMeaning = AdverbsContentFirstProcessingStage[Counter].LastIndexOf("-") + 1;
                lengthMeaning = AdverbsContentFirstProcessingStage[Counter].LastIndexOf("<") - startPosMeaning;
                AdverbsContentFinal[Counter, 2] = AdverbsContentFirstProcessingStage[Counter].Substring(startPosMeaning, lengthMeaning);


            }

            for (int Counter = 0; Counter < PredicatesContentFirstProcessingStage.Length; Counter++)
            {
                startPosDeclaration = PredicatesContentFirstProcessingStage[Counter].LastIndexOf("*") + 1;
                lengthDeclaration = PredicatesContentFirstProcessingStage[Counter].IndexOf("+") - startPosDeclaration;
                PredicatesContentFinal[Counter, 0] = PredicatesContentFirstProcessingStage[Counter].Substring(startPosDeclaration, lengthDeclaration);

                startPosWord = PredicatesContentFirstProcessingStage[Counter].IndexOf("+") + 1;
                lengthWord = PredicatesContentFirstProcessingStage[Counter].IndexOf("-") - startPosWord;
                PredicatesContentFinal[Counter, 1] = PredicatesContentFirstProcessingStage[Counter].Substring(startPosWord, lengthWord);

                startPosMeaning = PredicatesContentFirstProcessingStage[Counter].LastIndexOf("-") + 1;
                lengthMeaning = PredicatesContentFirstProcessingStage[Counter].LastIndexOf("<") - startPosMeaning;
                PredicatesContentFinal[Counter, 2] = PredicatesContentFirstProcessingStage[Counter].Substring(startPosMeaning, lengthMeaning);


            }

            for (int Counter = 0; Counter < ObjectsContentFirstProcessingStage.Length; Counter++)
            {
                startPosDeclaration = ObjectsContentFirstProcessingStage[Counter].LastIndexOf("*") + 1;
                lengthDeclaration = ObjectsContentFirstProcessingStage[Counter].IndexOf("+") - startPosDeclaration;
                ObjectsContentFinal[Counter, 0] = ObjectsContentFirstProcessingStage[Counter].Substring(startPosDeclaration, lengthDeclaration);

                startPosWord = ObjectsContentFirstProcessingStage[Counter].IndexOf("+") + 1;
                lengthWord = ObjectsContentFirstProcessingStage[Counter].IndexOf("-") - startPosWord;
                ObjectsContentFinal[Counter, 1] = ObjectsContentFirstProcessingStage[Counter].Substring(startPosWord, lengthWord);

                startPosMeaning = ObjectsContentFirstProcessingStage[Counter].LastIndexOf("-") + 1;
                lengthMeaning = ObjectsContentFirstProcessingStage[Counter].LastIndexOf("<") - startPosMeaning;
                ObjectsContentFinal[Counter, 2] = ObjectsContentFirstProcessingStage[Counter].Substring(startPosMeaning, lengthMeaning);
            }
        }
    }
}
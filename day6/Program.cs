using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day6
{
    class Program
    {
        static void ProcessGroupAnswers1(string[] lines)
        {
            int answersCounter = 0;
            string groupAnswers = string.Empty;
            foreach (var line in lines)
            {
                if (line == string.Empty)
                {
                    answersCounter += groupAnswers.Distinct().Count();
                    groupAnswers = string.Empty;
                }
                else
                    groupAnswers += line;

            }

            answersCounter += groupAnswers.Distinct().Count();

            Console.WriteLine(answersCounter);
        }

        static void ProcessGroupAnswers2(string[] lines)
        {
            int answersCounter = 0;
            var groupAnswers = new List<string>();
            foreach (var line in lines)
            {
                if (line == string.Empty)
                {
                    var allAnswered = groupAnswers[0];
                    foreach (var answers in groupAnswers)
                    {
                        if (allAnswered == null)
                            break;
                        allAnswered = string.Concat(allAnswered.Intersect(answers).TakeWhile(char.IsLetter));
                    }

                    if(allAnswered != null)
                        answersCounter += allAnswered.Count();
                    groupAnswers.Clear();
                }
                else
                    groupAnswers.Add(line);

            }

            var allAnsweredLastGroup = groupAnswers[0];
            foreach (var answers in groupAnswers)
            {
                if (allAnsweredLastGroup == null)
                    break;
                allAnsweredLastGroup = string.Concat(allAnsweredLastGroup.Intersect(answers).TakeWhile(char.IsLetter));
            }

            if (allAnsweredLastGroup != null)
                answersCounter += allAnsweredLastGroup.Count();

            Console.WriteLine(answersCounter);
        }

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            ProcessGroupAnswers1(lines);
            ProcessGroupAnswers2(lines);
        }
    }
}

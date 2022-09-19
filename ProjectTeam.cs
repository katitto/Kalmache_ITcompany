using System;
using System.Collections;

namespace KAlmache_Project1
{
    public class ProjectTeam
    {

        private string projectName;
        private List<Programmer> myProgrammers = new List<Programmer>();

        public ProjectTeam(string projectName, Programmer programmer1, Programmer Programmer2)
        {
            this.projectName = projectName;
            MyProgrammers.Add(programmer1);
            MyProgrammers.Add(Programmer2);

        }

        public string ProjectName { get => projectName; set => projectName = value; }
        public List<Programmer> MyProgrammers { get => myProgrammers; set => myProgrammers = value; }

        public override string ToString()
        {
            string data = $"{projectName} \n";
            for (int i = 0; i < MyProgrammers.Count; i++)
            {
                data += $" \n Programmer {i+1} : {MyProgrammers[i]}";                
            }
            return $"{data} \n";

        }
    





    }
}
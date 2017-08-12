using System.Collections.Generic;

/// <summary>
///  A Singleton Class used to track Robot Class name variables to prevent duplication. 
/// </summary>
namespace RobotNameClassLibrary
{
    class RobotCounter
    {
        private static RobotCounter Instance;
        private List<string> RobotNames;

        private RobotCounter()
        {
            RobotNames = new List<string>(); 
        }

        public static RobotCounter GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new RobotCounter();
                }
                return Instance;
            }
        }

        public void AddRobotName(string name)
        {
            RobotNames.Add(name);
        }

        public bool ContainsName(string name)
        {
            return RobotNames.Contains(name); 
        }
    }
}

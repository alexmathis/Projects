using FlooringProgram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using System.IO;

namespace FlooringProgram.Data
{
    public class StateProdRepository : IStateRepository
    {
        private const string _filepath = @"DataFiles\States.txt";

        public State GetState(string StateName)
        {

            List<State> states = new List<State>();
            using (StreamReader sr = new StreamReader(_filepath))
            {
                
               
                string line="";
                 sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    State newstate = new State();

                    string[] columns = line.Split(',');

                    newstate.StateAbbreviation = columns[0];
                    newstate.StateName = columns[1];
                    newstate.TaxRate = decimal.Parse(columns[2]);

                    
                    states.Add(newstate);
                   

                }

                var stateToReturn = states.FirstOrDefault(s => s.StateAbbreviation== StateName||s.StateName==StateName);
                return stateToReturn;
               




            }

        }




        public List<State> ListState(string StateName)
        {
            List<State> states = new List<State>();
            using (StreamReader sr = new StreamReader(_filepath))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    State newstate = new State();

                    string[] columns = line.Split(',');

                    newstate.StateAbbreviation = columns[0];
                    newstate.StateName = columns[1].ToUpper();
                    newstate.TaxRate = decimal.Parse(columns[2]);


                    states.Add(newstate);


                }
                return states;
            }
        }
    }
}

using FlooringProgram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
   public  class StateTestRepository : IStateRepository
    {
        Dictionary<string, State> states = new Dictionary<string, State>();
        public StateTestRepository()
        {
            State OH = new State()
            {
                StateAbbreviation = "OH",
                StateName = "OHIO",
                TaxRate = 6.25M
            };
            State PA = new State()
            {
                StateAbbreviation = "PA",
                StateName = "PENNSIYLVANIA",
                TaxRate = 6.75M

            };
            State MI = new State()
            {
                StateAbbreviation = "MI",
                StateName = "MICHIGAN",
                TaxRate = 5.75M

            };
            State IN = new State()
            {
                StateAbbreviation = "IN",
                StateName = "INDIANA",
                TaxRate = 6.00M

            };



            states.Add("OHIO", OH);
            states.Add("PENNSYLVANIA", PA);
            states.Add("Michigan", MI);
            states.Add("INDIANA", IN);
        }
    

        public State GetState(string StateName)
        {
          
                State value = states[StateName];
                return value;
            
            
         
        }

        public Dictionary<string, State> ListState(string StateName)
        {
            return states;
        }
    }
}   

using FlooringProgram.Data;
using FlooringProgram.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Test.TestRepTests
{
    [TestFixture]
    public class TestStateTestRepository
    {




        [Test]
        public void TestGetState()
        {
            StateTestRepository repo = new StateTestRepository();
            State ohio = repo.GetState("OHIO");
            Assert.AreEqual("OH", ohio.StateAbbreviation);
            Assert.AreEqual("OHIO", ohio.StateName);
            Assert.AreEqual(6.25M, ohio.TaxRate);
        }
        [Test]
        public void TestListStates()
        {
            StateTestRepository repo = new StateTestRepository();
            Dictionary<string, State> states = repo.ListState("OHIO");
            Assert.AreEqual(1, states.Count());
        }

    }
}
   


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_GoldChallangeFour_Repository
{
    public class OutingsRepository
    {
        List<OutingsContent> _outingsList = new List<OutingsContent>();
        OutingsContent _outingsObject = new OutingsContent();

        public List<OutingsContent> DisplayList()
        {
            return _outingsList;
        }

        public void AddOutings(OutingsContent newOutings)
        {
            _outingsList.Add(newOutings);
        }

        public string CalculationsAll()
        {
            double total = 0;
            foreach (var test in _outingsList)
            {
                total += test.TotalCostEvent;
            }
            return total.ToString();
        }

        public string CalculationsOutingsGolf()
        {
            double total = 0;
            OutingsContent outingObj = new OutingsContent();
            foreach (var outing in _outingsList)
            {
                if (outing.EventType == EventType.Golf)
                {
                    total += outing.TotalCostEvent;
                }
            }
            return total.ToString();
        }

        public string CalculationsOutingsBowling()
        {
            double total = 0;
            OutingsContent outingObj = new OutingsContent();
            foreach (var outing in _outingsList)
            {
                if (outing.EventType == EventType.Bowling)
                {
                    total += outing.TotalCostEvent;
                }
            }
            return total.ToString();
        }

        public string CalculationsOutingsAmusementPark()
        {
            double total = 0;
            OutingsContent outingObj = new OutingsContent();
            foreach (var outing in _outingsList)
            {
                if (outing.EventType == EventType.AmusementPark)
                {
                    total += outing.TotalCostEvent;
                }
            }
            return total.ToString();
        }

        public string CalculationsOutingsConcerts()
        {
            double total = 0;
            OutingsContent outingObj = new OutingsContent();
            foreach (var outing in _outingsList)
            {
                if (outing.EventType == EventType.Concert)
                {
                    total += outing.TotalCostEvent;
                }
            }
            return total.ToString();
        }
    }
}

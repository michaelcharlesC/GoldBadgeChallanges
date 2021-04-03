using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_GoldChallangeTwo_Repository
{
    public class BadgeContentRepository
    {
        List<BadgeContent> _badgeRepo = new List<BadgeContent>();
        public Dictionary<int,List<string>> _dictionary = new Dictionary<int,List<string>>();
        BadgeContent _pocoRef = new BadgeContent();
        

        

        public void CreateNewBadgeID(BadgeContent input)
        {
            _dictionary.Add(input.BadgeID , input.DoorName);

        }

        public void AddValueToKey(int existingKey, List<string> newValue)
        {
            existingKey = _pocoRef.BadgeID; 
            while (_dictionary.ContainsKey(existingKey))
            {
                _dictionary[existingKey] = newValue;
            }
           

        }



        public string GetBadgeByKey(int badgeKey)
        {
            var badgeExist = _dictionary;

            if (badgeExist.ContainsKey(badgeKey))
            {
                return badgeKey.ToString();
            }
            else
            {
                return null;
            }
            
        }


        public bool RemoveDoorbyKey(string doorInput)
        {
            foreach (var badge in _dictionary)
            {
                foreach (var badgeValue in badge.Value)
                {
                    if (badgeValue == doorInput)
                    {
                        badge.Value.Remove(badgeValue);
                        return true;
                    }

                }

            }
            return false;
        }

        public List<string> GetDoorByKey(int existingKey)
        {

            return _dictionary[existingKey];
            

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Library;

namespace Library {
    public class Medals {
        private List<Medal> medalList;

        public Medals() {
            this.medalList = new List<Medal>();
        }

        public List<Medal> getMedalList() {
            return medalList;
        }

        public void setMedalList(List<Medal> medalList) {
            this.medalList = medalList;
        }

        public Medal getMedal(int medalIndex) {
            if(medalList[medalIndex] != null) {
                return this.medalList[medalIndex];
            } else {
                return null;
            }
        }

        

        public void addMedal(Medal medal) {
            if(medal != null) {
                medalList.Add(medal);
            } else {
                Debug.LogWarning("Medal to add is null");
            }
        }

        public void addMedal(string title, string description, int type) {
            Medal medal = new Medal(title, description, type);

            if(medal != null) {
                medalList.Add(medal);
            } else {
                Debug.LogWarning("Medal to add is null");
            }
        }


        public Medal removeMedal(int medalIndex) {
            Medal removedOne;

            if(medalList[medalIndex] != null) {
                removedOne = medalList[medalIndex];
                medalList.RemoveAt(medalIndex);

                return removedOne;
            } else {
                return null;
            }
        }

    }
}

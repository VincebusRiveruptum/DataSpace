using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Library;

namespace Library{
    public class ReceptionTips    {
        private List<Tips> receptionTips;

        public ReceptionTips() {
            this.receptionTips = new List<Tips>();
        }

        public void setTips(List<Tips> list) {
            this.receptionTips = list;
        }

        public List<Tips> getTips() {
            return this.receptionTips;
        }

        public Tips getTip(int index) {
            if(receptionTips[index] != null) {
                return receptionTips[index];
            } else {
                return null;
            }
        } 

        public void addTip(Tips tip) {
            receptionTips.Add(tip);
        }

        public void removeTip(int index) {
            if(receptionTips[index] != null) {
                receptionTips.RemoveAt(index);
            } else {
                return;
            }
        }

        // Setters and getters

        public int getId(int index) {
            return this.receptionTips[index].getId();
        }

        public string getTitle(int index) {
            return this.receptionTips[index].getTipTitle();
        }

        public string getTipString(int index) {
            return this.receptionTips[index].getTipString();
        }

        public void setId(int index, int id) {
            this.getTip(index).setId(id);
        }

        public void setTitle(int index, string title) {
            this.getTip(index).setTitle(title);
        }

        public void setTipString(int index, string tipString) {
            this.getTip(index).setTipString(tipString);
        }
    }
}
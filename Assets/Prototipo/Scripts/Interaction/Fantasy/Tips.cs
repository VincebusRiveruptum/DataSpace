using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Library;

namespace Library{
    public class Tips
    {
        private int id;
        private string title;
        private string tipString;

        public Tips(int id, string title, string tipString){
            this.id = id;   
            this.title = title; 
            this.tipString = tipString;
        }

        // Setters and getters

        public int getId() { 
            return id;
        }
        
        public string getTipTitle() {
            return title;
        }
        
        public string getTipString(){
            return tipString;
        }

        public void setId(int id) {
            this.id = id;
        }
        
        public void setTitle(string title) {
            this.title = title;
        }

        public void setTipString(string tipString) { 
            this.tipString = tipString;
        }
    }
}


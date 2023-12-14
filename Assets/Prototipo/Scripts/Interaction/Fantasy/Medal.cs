using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Library;

namespace Library {
    public class Medal{
        private string title;
        private string description;
        private int type;
        public Medal(string title, string description, int type) {
            this.title = title;
            this.description = description;
            this.type = type;
        }

        public string getTitle() { return title; }
        public string getDescription() { return description; }
        public int getType() { return type; }
        public void setTitle(string title) {  this.title = title; }
        public void setDescription(string description) { this.description = description; }
        public void setType(int type) { this.type = type;}
    }
}

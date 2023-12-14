using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Library;


namespace Library {
    public class Player {
        private string name;
        private string lastName;
        private string email;
        private string rut;
        private int score;

        public Player(string name, string lastName, string email, string rut) {
            this.name = name;
            this.lastName = lastName;
            this.email = email;
            this.rut = rut; 
            this.score = 0;
            
        }

        public Player() {
            this.name = "DefaultPlayer";
            this.lastName = "DefaultLastName";
            this.email = "email@email.com";
            this.rut = "12345678-9";
            this.score = 0;
        }

        public string getName() {
            return this.name;
        }

        public string getLastName() { return this.lastName; }
    
        public string getEmail() { return this.email;}

        public string getRut() {  return this.rut;}

        public int getScore() {
            return this.score;
        }

        public void setScore(int score) {
                this.score = score;
        }
           
        public void setName(string name) {
            this.name = name;
        }

        public void setLastName(string lastName) { this.lastName = lastName;}

        public void setEmail(string email) { this.email = email;}

        public void setRut() {  this.rut = rut;}

        //Methods
    }
}

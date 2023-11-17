using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Library;


namespace Library {
    public class Player {
        private string name;
        private int score;
        private int currentStage;            // Level
        private int currentStep;            // Totem

        public Player(string name, int score) {
            this.name = name;
            this.score = score;
            this.currentStage = 0;
            this.currentStep = 0;
        }

        public Player() {
            this.name = "NewPlayer";
            this.score = 0;
            this.currentStage = 0;
            this.currentStep = 0;
        }

        public string getName() {
            return this.name;
        }
    
        public int getScore() {
            return this.score;
        }

        public int getCurrentStage() {
            return this.currentStage;
        }

        public int getCurrentStep() { 
            return this.currentStep;           
        }

        public void setScore(int score) {
                this.score = score;
        }
           
        public void setName(string name) {
            this.name = name;
        }

        public void setCurrentStage(int stage) {
            this.currentStage = stage;
        }

        public void setCurrentStep(int step) {
            this.currentStep = step;
        }

        //Methods
    }
}

namespace Tokimon {
    public class Tokimon {
        private string tokiName;
        private string tokiType;
        private int tokiStrength;
        private double tokiSize;

        public Tokimon(string tokiName, double tokiSize, string tokiType, int tokiStrength ) {
            this.tokiName = tokiName;
            this.tokiType = tokiType;
            this.tokiStrength = tokiStrength;
            this.tokiSize = tokiSize;
        }

        public int TokiStrength {
            get => tokiStrength;
            set => tokiStrength = value;
        }

        public string TokiName {
            get => tokiName;
        }

        public string TokiType {
            get => tokiType;
        }

        public double TokiSize {
            get => tokiSize;
        }

        public override string ToString() {
            return "[Name: " + tokiName + ", Strength: "
                   + tokiStrength + ", Height: " + tokiSize +
                   ", Ability: " + tokiType + "]";
        }
    }
}
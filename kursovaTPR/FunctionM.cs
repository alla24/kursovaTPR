using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaTPR
{
    public class FunctionM
    {
        double gL11, gL21, gL31, gH11, gH21, gH31, gL12, gL22, gL32, gH12, gH22, gH32;
        double gL13, gL23, gL33, gH13, gH23, gH33, gL14, gL24, gL34, gH14, gH24, gH34;
        double gL15, gL25, gL35, gH15, gH25, gH35, a1, a2, a3, b1, b2, b3, b4, b5;
        public FunctionM(Dictionary<String, double> inputs)
        {
            gL11 = inputs["gL11"];
            gL21 = inputs["gL21"];
            gL31 = inputs["gL31"];
            gH11 = inputs["gH11"];
            gH21 = inputs["gH21"];
            gH31 = inputs["gH31"];
            gL12 = inputs["gL12"];
            gL22 = inputs["gL22"];
            gL32 = inputs["gL32"];
            gH12 = inputs["gH12"];
            gH22 = inputs["gH22"];
            gH32 = inputs["gH32"];
            gL13 = inputs["gL13"];
            gL23 = inputs["gL23"];
            gL33 = inputs["gL33"];
            gH13 = inputs["gH13"];
            gH23 = inputs["gH23"];
            gH33 = inputs["gH33"];
            gL14 = inputs["gL14"];
            gL24 = inputs["gL24"];
            gL34 = inputs["gL34"];
            gH14 = inputs["gH14"];
            gH24 = inputs["gH24"];
            gH34 = inputs["gH34"];
            gL15 = inputs["gL15"];
            gL25 = inputs["gL25"];
            gL35 = inputs["gL35"];
            gH15 = inputs["gH15"];
            gH25 = inputs["gH25"];
            gH35 = inputs["gH35"];
            a1 = inputs["a1"];
            a2 = inputs["a2"];
            a3 = inputs["a3"];
            b1 = inputs["b1"];
            b2 = inputs["b2"];
            b3 = inputs["b3"];
            b4 = inputs["b4"];
            b5 = inputs["b5"];
        }
        //to find the first point that fulfills conditions
        public Tuple<double, double, double> startingPoint()
        {

            double x1, x2, x3, check1, check2, check3, check4, check5;
            x1 = x2 = x3 = Math.Min(b1, Math.Min(b2, Math.Min(b3, Math.Min(b4, b5))));
            check1 = check2 = check3 = check4 = check5 = -1;
            while (check1 < 0 || check2 < 0 || check3 <= 0 || check4 <= 0 || check5 <= 0)
            {
                x1--;
                x2--;
                x3--;
                //check condition 1:
                check1 = b1 - ((gL11 + gH11) / 2 * x1 + (gL21 + gH21) / 2 * x2 + (gL31 + gH31) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH11 - gL11) * (gH11 - gL11) / 12 + x2 * x2 * (gH21 - gL21) * (gH21 - gL21) / 12 + x3 * x3 * (gH31 - gL31) * (gH31 - gL31) / 12), 1 / 2));
                //check condition 2:
                check2 = b2 - ((gL12 + gH12) / 2 * x1 + (gL22 + gH22) / 2 * x2 + (gL32 + gH32) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH12 - gL12) * (gH12 - gL12) / 12 + x2 * x2 * (gH22 - gL22) * (gH22 - gL22) / 12 + x3 * x3 * (gH32 - gL32) * (gH32 - gL32) / 12), 1 / 2));
                //check condition 3:
                check3 = b3 - ((gL13 + gH13) / 2 * x1 + (gL23 + gH23) / 2 * x2 + (gL33 + gH33) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH13 - gL13) * (gH13 - gL13) / 12 + x2 * x2 * (gH23 - gL23) * (gH23 - gL23) / 12 + x3 * x3 * (gH33 - gL33) * (gH33 - gL33) / 12), 1 / 2));
                //check condition 4:
                check4 = b4 - ((gL14 + gH14) / 2 * x1 + (gL24 + gH24) / 2 * x2 + (gL34 + gH34) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH14 - gL14) * (gH14 - gL14) / 12 + x2 * x2 * (gH24 - gL24) * (gH24 - gL24) / 12 + x3 * x3 * (gH34 - gL34) * (gH34 - gL34) / 12), 1 / 2));
                //check condition 5:
                check5 = b5 - ((gL15 + gH15) / 2 * x1 + (gL25 + gH25) / 2 * x2 + (gL35 + gH35) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH15 - gL15) * (gH15 - gL15) / 12 + x2 * x2 * (gH25 - gL25) * (gH25 - gL25) / 12 + x3 * x3 * (gH35 - gL35) * (gH35 - gL35) / 12), 1 / 2));
            }
            return Tuple.Create(x1, x2, x3);
        }


        //to find differential of the penalty function by X1
        public double diffX1(double r, double x1, double x2, double x3)
        {
            double result = 0;
            result = -a1 + 2 * r * ((gL11 + gH11) / 2 * x1 + (gL21 + gH21) / 2 * x2 + (gL31 + gH31) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH11 - gL11) * (gH11 - gL11) / 12 + x2 * x2 * (gH21 - gL21) * (gH21 - gL21) / 12 + x3 * x3 * (gH31 - gL31) * (gH31 - gL31) / 12), 1 / 2) - b1) * ((gL11 + gH11) / 2 + 0.816 * 1 / 2 * Math.Pow((x1 * x1 * (gH11 - gL11) * (gH11 - gL11) / 12 + x2 * x2 * (gH21 - gL21) * (gH21 - gL21) / 12 + x3 * x3 * (gH31 - gL31) * (gH31 - gL31) / 12), -1 / 2) * 2 * x1 * (gH11 - gL11) * (gH11 - gL11) / 12) +
                /*condition2*/ 2 * r * ((gL12 + gH12) / 2 * x1 + (gL22 + gH22) / 2 * x2 + (gL32 + gH32) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH12 - gL12) * (gH12 - gL12) / 12 + x2 * x2 * (gH22 - gL22) * (gH22 - gL22) / 12 + x3 * x3 * (gH32 - gL32) * (gH32 - gL32) / 12), 1 / 2) - b2) * ((gL12 + gH12) / 2 + 0.816 * 1 / 2 * Math.Pow((x1 * x1 * (gH12 - gL12) * (gH12 - gL12) / 12 + x2 * x2 * (gH22 - gL22) * (gH22 - gL22) / 12 + x3 * x3 * (gH32 - gL32) * (gH32 - gL32) / 12), -1 / 2) * 2 * x1 * (gH12 - gL12) * (gH12 - gL12) / 12) +
                /*condition3*/ 2 * r * ((gL13 + gH13) / 2 * x1 + (gL23 + gH23) / 2 * x2 + (gL33 + gH33) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH13 - gL13) * (gH13 - gL13) / 12 + x2 * x2 * (gH23 - gL23) * (gH23 - gL23) / 12 + x3 * x3 * (gH33 - gL33) * (gH33 - gL33) / 12), 1 / 2) - b3) * ((gL13 + gH13) / 2 + 0.816 * 1 / 2 * Math.Pow((x1 * x1 * (gH13 - gL13) * (gH13 - gL13) / 12 + x2 * x2 * (gH23 - gL23) * (gH23 - gL23) / 12 + x3 * x3 * (gH33 - gL33) * (gH33 - gL33) / 12), -1 / 2) * 2 * x1 * (gH13 - gL13) * (gH13 - gL13) / 12) +
                /*condition4*/ 2 * r * ((gL14 + gH14) / 2 * x1 + (gL24 + gH24) / 2 * x2 + (gL34 + gH34) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH14 - gL14) * (gH14 - gL14) / 12 + x2 * x2 * (gH24 - gL24) * (gH24 - gL24) / 12 + x3 * x3 * (gH34 - gL34) * (gH34 - gL34) / 12), 1 / 2) - b4) * ((gL14 + gH14) / 2 + 0.816 * 1 / 2 * Math.Pow((x1 * x1 * (gH14 - gL14) * (gH14 - gL14) / 12 + x2 * x2 * (gH24 - gL24) * (gH24 - gL24) / 12 + x3 * x3 * (gH34 - gL34) * (gH34 - gL34) / 12), -1 / 2) * 2 * x1 * (gH14 - gL14) * (gH14 - gL14) / 12) +
                /*condition5*/ 2 * r * ((gL15 + gH15) / 2 * x1 + (gL25 + gH25) / 2 * x2 + (gL35 + gH35) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH15 - gL15) * (gH15 - gL15) / 12 + x2 * x2 * (gH25 - gL25) * (gH25 - gL25) / 12 + x3 * x3 * (gH35 - gL35) * (gH35 - gL35) / 12), 1 / 2) - b5) * ((gL15 + gH15) / 2 + 0.816 * 1 / 2 * Math.Pow((x1 * x1 * (gH15 - gL15) * (gH15 - gL15) / 12 + x2 * x2 * (gH25 - gL25) * (gH25 - gL25) / 12 + x3 * x3 * (gH35 - gL35) * (gH35 - gL35) / 12), -1 / 2) * 2 * x1 * (gH15 - gL15) * (gH15 - gL15) / 12);
            return result;
        }
        //to find differential of the penalty function by X2
        public double diffX2(double r, double x1, double x2, double x3)
        {
            double result = 0;
            result = -a2 + 2 * r * ((gL11 + gH11) / 2 * x1 + (gL21 + gH21) / 2 * x2 + (gL31 + gH31) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH11 - gL11) * (gH11 - gL11) / 12 + x2 * x2 * (gH21 - gL21) * (gH21 - gL21) / 12 + x3 * x3 * (gH31 - gL31) * (gH31 - gL31) / 12), 1 / 2) - b1) * ((gL21 + gH21) / 2 + 0.816 * 1 / 2 * Math.Pow((x1 * x1 * (gH11 - gL11) * (gH11 - gL11) / 12 + x2 * x2 * (gH21 - gL21) * (gH21 - gL21) / 12 + x3 * x3 * (gH31 - gL31) * (gH31 - gL31) / 12), -1 / 2) * 2 * x2 * (gH21 - gL21) * (gH21 - gL21) / 12) +
                /*condition2*/ 2 * r * ((gL12 + gH12) / 2 * x1 + (gL22 + gH22) / 2 * x2 + (gL32 + gH32) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH12 - gL12) * (gH12 - gL12) / 12 + x2 * x2 * (gH22 - gL22) * (gH22 - gL22) / 12 + x3 * x3 * (gH32 - gL32) * (gH32 - gL32) / 12), 1 / 2) - b2) * ((gL22 + gH22) / 2 + 0.816 * 1 / 2 * Math.Pow((x1 * x1 * (gH12 - gL12) * (gH12 - gL12) / 12 + x2 * x2 * (gH22 - gL22) * (gH22 - gL22) / 12 + x3 * x3 * (gH32 - gL32) * (gH32 - gL32) / 12), -1 / 2) * 2 * x2 * (gH22 - gL22) * (gH22 - gL22) / 12) +
                /*condition3*/ 2 * r * ((gL13 + gH13) / 2 * x1 + (gL23 + gH23) / 2 * x2 + (gL33 + gH33) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH13 - gL13) * (gH13 - gL13) / 12 + x2 * x2 * (gH23 - gL23) * (gH23 - gL23) / 12 + x3 * x3 * (gH33 - gL33) * (gH33 - gL33) / 12), 1 / 2) - b3) * ((gL23 + gH23) / 2 + 0.816 * 1 / 2 * Math.Pow((x1 * x1 * (gH13 - gL13) * (gH13 - gL13) / 12 + x2 * x2 * (gH23 - gL23) * (gH23 - gL23) / 12 + x3 * x3 * (gH33 - gL33) * (gH33 - gL33) / 12), -1 / 2) * 2 * x2 * (gH23 - gL23) * (gH23 - gL23) / 12) +
                /*condition4*/ 2 * r * ((gL14 + gH14) / 2 * x1 + (gL24 + gH24) / 2 * x2 + (gL34 + gH34) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH14 - gL14) * (gH14 - gL14) / 12 + x2 * x2 * (gH24 - gL24) * (gH24 - gL24) / 12 + x3 * x3 * (gH34 - gL34) * (gH34 - gL34) / 12), 1 / 2) - b4) * ((gL24 + gH24) / 2 + 0.816 * 1 / 2 * Math.Pow((x1 * x1 * (gH14 - gL14) * (gH14 - gL14) / 12 + x2 * x2 * (gH24 - gL24) * (gH24 - gL24) / 12 + x3 * x3 * (gH34 - gL34) * (gH34 - gL34) / 12), -1 / 2) * 2 * x2 * (gH24 - gL24) * (gH24 - gL24) / 12) +
                /*condition5*/ 2 * r * ((gL15 + gH15) / 2 * x1 + (gL25 + gH25) / 2 * x2 + (gL35 + gH35) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH15 - gL15) * (gH15 - gL15) / 12 + x2 * x2 * (gH25 - gL25) * (gH25 - gL25) / 12 + x3 * x3 * (gH35 - gL35) * (gH35 - gL35) / 12), 1 / 2) - b5) * ((gL25 + gH25) / 2 + 0.816 * 1 / 2 * Math.Pow((x1 * x1 * (gH15 - gL15) * (gH15 - gL15) / 12 + x2 * x2 * (gH25 - gL25) * (gH25 - gL25) / 12 + x3 * x3 * (gH35 - gL35) * (gH35 - gL35) / 12), -1 / 2) * 2 * x2 * (gH25 - gL25) * (gH25 - gL25) / 12);
            return result;
        }
        //to find differential of the penalty function by X3
        public double diffX3(double r, double x1, double x2, double x3)
        {
            double result = 0;
            result = -a3 + 2 * r * ((gL11 + gH11) / 2 * x1 + (gL21 + gH21) / 2 * x2 + (gL31 + gH31) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH11 - gL11) * (gH11 - gL11) / 12 + x2 * x2 * (gH21 - gL21) * (gH21 - gL21) / 12 + x3 * x3 * (gH31 - gL31) * (gH31 - gL31) / 12), 1 / 2) - b1) * ((gL31 + gH31) / 2 + 0.816 * 1 / 2 * Math.Pow((x1 * x1 * (gH11 - gL11) * (gH11 - gL11) / 12 + x2 * x2 * (gH21 - gL21) * (gH21 - gL21) / 12 + x3 * x3 * (gH31 - gL31) * (gH31 - gL31) / 12), -1 / 2) * 2 * x3 * (gH31 - gL31) * (gH31 - gL31) / 12) +
                /*condition2*/ 2 * r * ((gL12 + gH12) / 2 * x1 + (gL22 + gH22) / 2 * x2 + (gL32 + gH32) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH12 - gL12) * (gH12 - gL12) / 12 + x2 * x2 * (gH22 - gL22) * (gH22 - gL22) / 12 + x3 * x3 * (gH32 - gL32) * (gH32 - gL32) / 12), 1 / 2) - b2) * ((gL32 + gH32) / 2 + 0.816 * 1 / 2 * Math.Pow((x1 * x1 * (gH12 - gL12) * (gH12 - gL12) / 12 + x2 * x2 * (gH22 - gL22) * (gH22 - gL22) / 12 + x3 * x3 * (gH32 - gL32) * (gH32 - gL32) / 12), -1 / 2) * 2 * x3 * (gH32 - gL32) * (gH32 - gL32) / 12) +
                /*condition3*/ 2 * r * ((gL13 + gH13) / 2 * x1 + (gL23 + gH23) / 2 * x2 + (gL33 + gH33) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH13 - gL13) * (gH13 - gL13) / 12 + x2 * x2 * (gH23 - gL23) * (gH23 - gL23) / 12 + x3 * x3 * (gH33 - gL33) * (gH33 - gL33) / 12), 1 / 2) - b3) * ((gL33 + gH33) / 2 + 0.816 * 1 / 2 * Math.Pow((x1 * x1 * (gH13 - gL13) * (gH13 - gL13) / 12 + x2 * x2 * (gH23 - gL23) * (gH23 - gL23) / 12 + x3 * x3 * (gH33 - gL33) * (gH33 - gL33) / 12), -1 / 2) * 2 * x3 * (gH33 - gL33) * (gH33 - gL33) / 12) +
                /*condition4*/ 2 * r * ((gL14 + gH14) / 2 * x1 + (gL24 + gH24) / 2 * x2 + (gL34 + gH34) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH14 - gL14) * (gH14 - gL14) / 12 + x2 * x2 * (gH24 - gL24) * (gH24 - gL24) / 12 + x3 * x3 * (gH34 - gL34) * (gH34 - gL34) / 12), 1 / 2) - b4) * ((gL34 + gH34) / 2 + 0.816 * 1 / 2 * Math.Pow((x1 * x1 * (gH14 - gL14) * (gH14 - gL14) / 12 + x2 * x2 * (gH24 - gL24) * (gH24 - gL24) / 12 + x3 * x3 * (gH34 - gL34) * (gH34 - gL34) / 12), -1 / 2) * 2 * x3 * (gH34 - gL34) * (gH34 - gL34) / 12) +
                /*condition5*/ 2 * r * ((gL15 + gH15) / 2 * x1 + (gL25 + gH25) / 2 * x2 + (gL35 + gH35) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH15 - gL15) * (gH15 - gL15) / 12 + x2 * x2 * (gH25 - gL25) * (gH25 - gL25) / 12 + x3 * x3 * (gH35 - gL35) * (gH35 - gL35) / 12), 1 / 2) - b5) * ((gL35 + gH35) / 2 + 0.816 * 1 / 2 * Math.Pow((x1 * x1 * (gH15 - gL15) * (gH15 - gL15) / 12 + x2 * x2 * (gH25 - gL25) * (gH25 - gL25) / 12 + x3 * x3 * (gH35 - gL35) * (gH35 - gL35) / 12), -1 / 2) * 2 * x3 * (gH35 - gL35) * (gH35 - gL35) / 12);
            return result;
        }

        //calculate goal function
        public double getFunction(double x1, double x2, double x3)
        {
            double result = 0;
            result = -a1 * x1 - a2 * x2 - a3 * x3;
            return result;
        }

        //calculate penalty function
        public double getPenaltyFunction(double r, double x1, double x2, double x3)
        {
            double result = 0;
            result = (-a1 * x1 - a2 * x2 - a3 * x3) + r * (((gL11 + gH11) / 2 * x1 + (gL21 + gH21) / 2 * x2 + (gL31 + gH31) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH11 - gL11) * (gH11 - gL11) / 12 + x2 * x2 * (gH21 - gL21) * (gH21 - gL21) / 12 + x3 * x3 * (gH31 - gL31) * (gH31 - gL31) / 12), 1 / 2) - b1) +
                /*condition 2*/((gL12 + gH12) / 2 * x1 + (gL22 + gH22) / 2 * x2 + (gL32 + gH32) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH12 - gL12) * (gH12 - gL12) / 12 + x2 * x2 * (gH22 - gL22) * (gH22 - gL22) / 12 + x3 * x3 * (gH32 - gL32) * (gH32 - gL32) / 12), 1 / 2) - b2) +
                /*condition 3*/((gL13 + gH13) / 2 * x1 + (gL23 + gH23) / 2 * x2 + (gL33 + gH33) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH13 - gL13) * (gH13 - gL13) / 12 + x2 * x2 * (gH23 - gL23) * (gH23 - gL23) / 12 + x3 * x3 * (gH33 - gL33) * (gH33 - gL33) / 12), 1 / 2) - b3) +
                /*condition 4*/((gL14 + gH14) / 2 * x1 + (gL24 + gH24) / 2 * x2 + (gL34 + gH34) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH14 - gL14) * (gH14 - gL14) / 12 + x2 * x2 * (gH24 - gL24) * (gH24 - gL24) / 12 + x3 * x3 * (gH34 - gL34) * (gH34 - gL34) / 12), 1 / 2) - b4) +
                /*condition 5*/((gL15 + gH15) / 2 * x1 + (gL25 + gH25) / 2 * x2 + (gL35 + gH35) / 2 * x3 + 0.816 * Math.Pow((x1 * x1 * (gH15 - gL15) * (gH15 - gL15) / 12 + x2 * x2 * (gH25 - gL25) * (gH25 - gL25) / 12 + x3 * x3 * (gH35 - gL35) * (gH35 - gL35) / 12), 1 / 2) - b5));
            return result;
        }
    }
}

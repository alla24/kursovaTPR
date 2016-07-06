using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Collections.Generic;

namespace kursovaTPR
{
    public class Calc
    {
    public Tuple<double, double, double,double> calc(Dictionary <String,double> inputs)
    {
        
        double r = 0.01;
        double b = 0.001;
        double e = 0.1;
        double funct = 0.0;
        double functOld = 900.0;
        double x1, x2, x3;
        double d1, d2, d3;
        double dfOld = 2000.0;
        double df = funct+e*10;

        FunctionM funcCalc = new FunctionM(inputs);
        /*define starting x1,x2,x3 and calculate function is this point
        Tuple<double, double, double> xTuple = funcCalc.startingPoint();
        x1 = xTuple.Item1;
        x2 = xTuple.Item2;
        x3 = xTuple.Item3;*/
        x1 = x2 = x3 = Math.Max(inputs["b1"], Math.Max(inputs["b2"],Math.Max(inputs["b3"],Math.Max(inputs["b4"],inputs["b5"])))) + 1;        
        while ( Math.Abs(dfOld-df) >= e)
        {
            r = r * (1+b);
            functOld = funct;
            dfOld = df;
            //calculate differential
			d1 = (funcCalc.diffX1(r, x1, x2, x3));
			d2 = (funcCalc.diffX2(r, x1, x2, x3));
			d3 = (funcCalc.diffX3(r, x1, x2, x3));

			d1 = ((d1) > 0 ? (d1) : 0);//if (d1) > 0 is true ? then (d1) : else d1=0
			d2 = ((d2) > 0 ? (d2) : 0);
			d3 = ((d3) > 0 ? (d3) : 0);

			double xN1 = x1 - (b * d1);
			double xN2 = x2 - (b * d2);
			double xN3 = x3 - (b * d3);
			x1 = xN1;
			x2 = xN2;
			x3 = xN3;
            //calculate goal function
			funct = funcCalc.getFunction(x1, x2, x3);


            //calculate penalty function
			df = funcCalc.getPenaltyFunction(r, x1, x2, x3);
		
		}
		
        /*так як в якості х визначено час, використаний за кожною технологією, то об'єм випуску по кожній технології = х*а*/
        return Tuple.Create(x1*inputs["a1"],x2*inputs["a2"],x3*inputs["a3"],-funct);
    }
    }
}

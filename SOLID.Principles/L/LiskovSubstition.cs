using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Principles.L
{
    class LiskovSubstition
    {
        class BronkenPrinciple
        {
            abstract class Car
            {

            }

            class Audi : Car
            {

            }

            class BMW : Car
            {

            }

            private void PrintMotorSizeAudi(Car car)
            {
                // print 1.4
            }

            private void PrintMotorSizeBMW(Car car)
            {
                // print 2.0
            }

            public BronkenPrinciple()
            {
                var audi = new Audi();
                var bmw = new BMW();
            }

            private void PrintCarSize(Car car)
            {
                if (car.GetType().BaseType == typeof(BMW))
                {
                    PrintMotorSizeBMW(car);
                }
                else if (car.GetType().BaseType == typeof(Audi))
                {
                    PrintMotorSizeAudi(car);
                }
            }
        }
        
        class PrincipleOk
        {
            interface Car
            {
                public decimal PrintMotorSize();
            }

            class BMW : Car
            {
                public decimal PrintMotorSize()
                {
                    return 2.0m;
                }
            }

            class Audi : Car
            {
                public decimal PrintMotorSize()
                {
                    return 1.4m;
                }
            }

            public PrincipleOk()
            {
                Car bmw = new BMW();
                Car audi = new Audi();

                PrintMotorCarSize(bmw);
                PrintMotorCarSize(audi);
            }

            private void PrintMotorCarSize(Car car)
            {
                car.PrintMotorSize();
            }
        }
    }
}

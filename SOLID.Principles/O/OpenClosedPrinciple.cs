using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Principles.O
{
    /// <summary>
    /// Open for extention, closed for modification.
    /// </summary>
    public class OpenClosedPrinciple
    {
        public class BrokenPrinciple
        {
            public bool StoreInformation(string storeType, string data)
            {
                if (storeType == "SQL")
                {
                    // save data to SQL
                } else if (storeType == "WindowsRegister")
                {
                    // save to windows register
                } else if (storeType == "Algun otro tipo apestoso")
                {
                    // codigo de ese tipo apestoso
                }

                return true;
            }
        }

        public class PrincipleOk
        {
            interface IStoreInformation
            {
                public bool Store(string data);
            }

            class StoreInformationSql : IStoreInformation
            {
                public bool Store(string data)
                {
                    // here we store information on SQL
                    return true;
                }
            }

            class StoreInformationToWindowsRegister : IStoreInformation
            {
                public bool Store(string data)
                {
                    // here we are currently adding a new feature without breaking or even touching the existing
                    // sql information class
                    return true;
                }
            }
        }        


        public class BrokenPrincipleSecondExample
        {
            class Car
            {
                public string Brand { get; }
                public Car(string brand)
                {
                    Brand = brand;
                }
            }

            public BrokenPrincipleSecondExample()
            {
                var honda = new Car("Honda");
                var mazda = new Car("Mazda");
                var nissan = new Car("Nissan");

                PrintCarPrice(honda);
                PrintCarPrice(mazda);
                PrintCarPrice(nissan);
            }

            void PrintCarPrice(Car car)
            {
                if (car.Brand == "Honda")
                {
                    // print 500
                } else if (car.Brand == "Mazda")
                {
                    // print 400
                } else if (car.Brand == "Nissan")
                {
                    // print 300
                }
            }
        }

        public class PrincpleOkSecondExample
        {
            interface Car
            {
                double PrintPrice();
            }

            class Honda : Car
            {
                public double PrintPrice()
                {
                    return 500;
                }
            }

            class Mazda : Car
            {
                public double PrintPrice()
                {
                    return 400;
                }
            }

            class Nissan : Car
            {
                public double PrintPrice()
                {
                    return 300;
                }
            }

            public PrincpleOkSecondExample()
            {
                var honda = new Honda();
                var mazda = new Mazda();
                var nissan = new Nissan();

                PrintCarPrice(honda);
                PrintCarPrice(mazda);
                PrintCarPrice(nissan);
            }

            void PrintCarPrice(Car car)
            {
                car.PrintPrice();
            }
        }
    }
}

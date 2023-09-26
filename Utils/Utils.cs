using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teahouse.Models;

namespace teahouse.Utils;
    public class Utils
    {
        public static int GetDrinkTypeName(string type) {
            if(type == "Cold") {
                return 0;
            } else if(type == "Hot") {
                return 1;
            } else {
                return 2;
            }
        }
    }
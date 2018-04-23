using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolina.Models.Requests
{
    class CheckPaymentJSON
    {
        public List<ListOfCounters> counters { get; set; }
        public List<ListOfStreets> streets { get; set; }
        public List<Settlements> settlements { get; set; }
        public PersonalAccount personalAccount { get; set; }
    }

    public class ListOfCounters                     // Получение списка счётчиков
    {
        public int id { get; set; }
        public string meter_no { get; set; }                    // серийный номер счётчика
        public int value { get; set; }                          // показания 
        public int value_real { get; set; }                     // актуальные показания
    }

    public class ListOfStreets                      // Получение списка улиц
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class PersonalAccount                    // Работа с лицевыми счетами
    {
        public int arg_building_num { get; set; }                 // номер дома
        public string arg_building_letter { get; set; }           // буква дома
        public int arg_flat_num { get; set; }                     // номер квартиры
        public string arg_flat_letter { get; set; }               // буква квартиры
        public int arg_corpus_num { get; set; }                   // номер корпуса
        public int arg_corpus_letter { get; set; }                // буква корпуса
    }

    public class Settlements                        // Работа с населёнными пунктами
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarNameIsvalid = "Araba ismi en az 2 karakter olmalıdır";
        public static string CarPriceIsvalid = "Araba fiyatı 0'dan büyük olmalıdır";
        public static string CarAdded = "Araba başarıyla eklendi";
        public static string CarDeleted = "Araba başarıyla silindi";
        public static string CarUpdated = "Araba başarıyla güncellendi";
        public static string CarListed = "Arabalar listelendi";
        public static string MaintanenceTime = "Sistem bakımda. Lütfen daha sonra tekrar deneyin";
    }
}
using DynamicProcessor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageRecognizer
{
    /// <summary>
    /// Предназначен для распознавания изображения и вывода результатов.
    /// </summary>
    static class Recognizer
    {
        /// <summary>
        /// Представляет хранилище с координатами фрагментов сканируемого изображения и списками выходных знаков после их разбора.
        /// </summary>
        struct Images
        {
            /// <summary>
            /// Координата X разбираемого фрагмента, относящегося к первому изображению.
            /// </summary>
            public int Px1;
            /// <summary>
            /// Координата Y разбираемого фрагмента, относящегося к первому изображению.
            /// </summary>
            public int Py1;
            /// <summary>
            /// Координата X разбираемого фрагмента, относящегося ко второму изображению.
            /// </summary>
            public int Px2;
            /// <summary>
            /// Координата Y разбираемого фрагмента, относящегося ко второму изображению.
            /// </summary>
            public int Py2;
            /// <summary>
            /// Координата X разбираемого фрагмента, относящегося к третьему изображению.
            /// </summary>
            public int Px3;
            /// <summary>
            /// Координата Y разбираемого фрагмента, относящегося к третьему изображению.
            /// </summary>
            public int Py3;
            /// <summary>
            /// Список знаков разобранного фрагмента, относящегося к первому изображению.
            /// </summary>
            public List<SignValue> Img1;
            /// <summary>
            /// Список знаков разобранного фрагмента, относящегося к второму изображению.
            /// </summary>
            public List<SignValue> Img2;
            /// <summary>
            /// Список знаков разобранного фрагмента, относящегося к третьему изображению.
            /// </summary>
            public List<SignValue> img3;

            /// <summary>
            /// Находит наиболее подходящие друг к другу изображения, сравнивая знаки, содержащиеся в списках, и вычисляя, какое изображение соответствует более всего,
            /// т.е. имеет наименьшую разницу в знаках и встречающееся более всего раз. Его номер возвращается. Количество раз, которое оно встретилось,
            /// возвращается в переменную "count".
            /// </summary>
            /// <param name="lst1">Знаки первого искомого изображения.</param>
            /// <param name="lst2">Знаки второго искомого изображения.</param>
            /// <param name="lst3">Знаки третьего искомого изображения.</param>
            /// <param name="count">Степень соответствия. Чем больше, тем лучше.</param>
            /// <returns>Возвращает номер наиболее подходящего изображения.</returns>
            public byte GetBySign(List<SignValue> lst1, List<SignValue> lst2, List<SignValue> lst3, out int count)
            {
                count = 0;
                if (Img1 == null && Img2 == null && img3 == null)
                    return 0;
                int i1 = 0, i2 = 0, i3 = 0;
                for (int k = 0; k < Map.AllMax; k++)
                {
                    SignValue sv1 = SignValue.MaxValue, sv2 = SignValue.MaxValue, sv3 = SignValue.MaxValue;
                    if (Img1 != null)
                        sv1 = Img1[k] - lst1[k];
                    if (Img2 != null)
                        sv2 = Img2[k] - lst2[k];
                    if (img3 != null)
                        sv3 = img3[k] - lst3[3];
                    if (sv1 < sv2 && sv1 < sv3)
                    {
                        i1++;
                        continue;
                    }
                    if (sv2 < sv1 && sv2 < sv3)
                    {
                        i2++;
                        continue;
                    }
                    i3++;
                }
                if (i1 > i2 && i1 > i3)
                {
                    count = i1;
                    return 1;
                }
                if (i2 > i1 && i2 > i3)
                {
                    count = i2;
                    return 2;
                }
                count = i3;
                return 3;
            }
        }

        /// <summary>
        /// Результат по первому изображению.
        /// </summary>
        public static Bitmap Result1 { get; private set; }
        /// <summary>
        /// Результат по второму изображению.
        /// </summary>
        public static Bitmap Result2 { get; private set; }
        /// <summary>
        /// Результат по третьему изображению.
        /// </summary>
        public static Bitmap Result3 { get; private set; }
        /// <summary>
        /// Первое исходное изображение.
        /// </summary>
        public static Bitmap Image1 { get; private set; }
        /// <summary>
        /// Второе исходное изображение.
        /// </summary>
        public static Bitmap Image2 { get; private set; }
        /// <summary>
        /// Третье исходное изображение.
        /// </summary>
        public static Bitmap Image3 { get; private set; }

        /// <summary>
        /// Выполняет все необходимые процедуры для поиска заданных объектов на сканируемом изображении.
        /// </summary>
        /// <param name="scanPath">Путь к папке с выбранным примером.</param>
        public static void Recognize(string scanPath)
        {
            Bitmap bitMain = new Bitmap(string.Format(@"{0}\{1}", scanPath, "imgMain.bmp"));
            Bitmap bit1 = new Bitmap(string.Format(@"{0}\{1}", scanPath, "img1.bmp"));
            Bitmap bit2 = new Bitmap(string.Format(@"{0}\{1}", scanPath, "img2.bmp"));
            Bitmap bit3 = new Bitmap(string.Format(@"{0}\{1}", scanPath, "img3.bmp"));
            if (bitMain.Width <= 0 || bitMain.Height <= 0)
                throw new ArgumentException("Размеры сканируемого изображения некорректны");
            if (bit1.Width <= 0 || bit1.Height <= 0)
                throw new ArgumentException("Размеры первого изображения некорректны");
            if (bit2.Width <= 0 || bit2.Height <= 0)
                throw new ArgumentException("Размеры второго изображения некорректны");
            if (bit3.Width <= 0 || bit3.Height <= 0)
                throw new ArgumentException("Размеры третьего изображения некорректны");
            if (bit1.Width > bitMain.Width || bit1.Height > bitMain.Height)
                throw new ArgumentException("Размеры первого изображения превышают размеры сканируемого изображения");
            if (bit2.Width > bitMain.Width || bit2.Height > bitMain.Height)
                throw new ArgumentException("Размеры второго изображения превышают размеры сканируемого изображения");
            if (bit3.Width > bitMain.Width || bit3.Height > bitMain.Height)
                throw new ArgumentException("Размеры третьего изображения превышают размеры сканируемого изображения");
            Image1 = bit1;
            Image2 = bit2;
            Image3 = bit3;
            Map mapMain = GetMap(bitMain);
            Map map1 = GetMap(bit1);
            Map map2 = GetMap(bit2);
            Map map3 = GetMap(bit3);
            using (FileStream fs = new FileStream(string.Format(@"{0}\{1}", Application.StartupPath, "imgMain.xml"), FileMode.Create))
            {
                mapMain.ToStream(fs);
            }
            using (FileStream fs = new FileStream(string.Format(@"{0}\{1}", Application.StartupPath, "img1.xml"), FileMode.Create))
            {
                map1.ToStream(fs);
            }
            using (FileStream fs = new FileStream(string.Format(@"{0}\{1}", Application.StartupPath, "img2.xml"), FileMode.Create))
            {
                map2.ToStream(fs);
            }
            using (FileStream fs = new FileStream(string.Format(@"{0}\{1}", Application.StartupPath, "img3.xml"), FileMode.Create))
            {
                map3.ToStream(fs);
            }
            List<SignValue> sv1, sv2, sv3;
            MapTest(map1, map2, map3, out sv1, out sv2, out sv3, true);
            List<Images> lst = Find(bit1, bit2, bit3, bitMain);
            Images? image1, image2, image3;
            FindMin(lst, sv1, sv2, sv3, out image1, out image2, out image3);
            Result1 = Result2 = Result3 = null;
            if (image1 != null)
            {
                int x1 = image1.Value.Px1, y1 = image1.Value.Py1;
                Result1 = GetCurrentBitmap(bitMain, ref x1, ref y1, bit1.Width, bit1.Height);
            }
            if (image2 != null)
            {
                int x2 = image2.Value.Px2, y2 = image2.Value.Py2;
                Result2 = GetCurrentBitmap(bitMain, ref x2, ref y2, bit2.Width, bit2.Height);
            }
            if (image3 != null)
            {
                int x3 = image3.Value.Px3, y3 = image3.Value.Py3;
                Result3 = GetCurrentBitmap(bitMain, ref x3, ref y3, bit3.Width, bit3.Height);
            }
        }

        /// <summary>
        /// Находит наиболее соответствующие друг другу изображения: фрагмент исследуемого изображения и входное изображение.
        /// </summary>
        /// <param name="img">Список знаков, полученных в результате разбора фрагментов сканируемого изображения.</param>
        /// <param name="sv1">Список знаков, полученных в результате разбора первого изображения.</param>
        /// <param name="sv2">Список знаков, полученных в результате разбора второго изображения.</param>
        /// <param name="sv3">Список знаков, полученных в результате разбора третьего изображения.</param>
        /// <param name="im1">Результат поиска первого изображения на сканируемом.</param>
        /// <param name="im2">Результат поиска второго изображения на сканируемом.</param>
        /// <param name="im3">Результат поиска третьего изображения на сканируемом.</param>
        static void FindMin(List<Images> img, List<SignValue> sv1, List<SignValue> sv2, List<SignValue> sv3, out Images? im1, out Images? im2, out Images? im3)
        {
            im1 = im2 = im3 = null;
            for (int k = 0, s1 = 0, s2 = 0, s3 = 0; k < img.Count; k++)
            {
                int count;
                switch (img[k].GetBySign(sv1, sv2, sv3, out count))
                {
                    case 1:
                        if (count <= s1)
                            break;
                        s1 = count;
                        im1 = img[k];
                        break;
                    case 2:
                        if (count <= s2)
                            break;
                        s2 = count;
                        im2 = img[k];
                        break;
                    case 3:
                        if (count <= s3)
                            break;
                        s3 = count;
                        im3 = img[k];
                        break;
                    default:
                        throw new Exception("Неизвестный тип объекта");
                }
            }
        }

        /// <summary>
        /// Создаёт списки знаков изображений, проводя их обработку следующим образом:
        /// 1) Разбор изображений с помощью ряда знаков, количество которых зависит от размера изображения (см. GetMap).
        /// 2) Осуществляет разбор полученных в результате выполнения п.1 карт, по количеству знаков, равному Map.AllMax.
        /// Таким образом, получаются списки знаков, которые "выровнены" по определённым знакам, последовательность которых нам известна.
        /// Это очень важно. Подытожив вышесказанное, можно сказать, что мы сравниваем знаки, которые получены одним и тем же путём и,
        /// соответственно, имеющие примерно одинаковые значения, т.е. они не превышают допустимого отклонения. Таким образом,
        /// на следующем этапе мы можем сравнить их и определить, какие из них подходят друг к другу больше и какие - нет.
        /// Но здесь есть одна особенность: дело в том, что не все изображения впишутся в "погрешность". Именно поэтому иногда программа по
        /// "неизвестным причинам" может не распознать изображения. Написание такого механизма, который позволит вместо "излишней погрешности"
        /// получать более точный результат, используя её, мы оставим до следующего раза. Если человек, изучающий этот код, поймёт, что надо добавить для
        /// того, чтобы расширить возможности программы, то это означает, что он понял суть технологии.
        /// </summary>
        /// <param name="bit1">Первое изображение.</param>
        /// <param name="bit2">Второе изображение.</param>
        /// <param name="bit3">Третье изображение.</param>
        /// <param name="bitm">Сканируемое изображение.</param>
        /// <returns>Возвращает списки знаков изображений.</returns>
        static List<Images> Find(Bitmap bit1, Bitmap bit2, Bitmap bit3, Bitmap bitm)
        {
            List<Images> lst = new List<Images>();
            for (int x1 = 0, y1 = 0, x2 = 0, y2 = 0, x3 = 0, y3 = 0; ; )
            {
                int px1 = x1, py1 = y1, px2 = x2, py2 = y2, px3 = x3, py3 = y3;
                Bitmap b1 = GetCurrentBitmap(bitm, ref x1, ref y1, bit1.Width, bit1.Height);
                Bitmap b2 = GetCurrentBitmap(bitm, ref x2, ref y2, bit2.Width, bit2.Height);
                Bitmap b3 = GetCurrentBitmap(bitm, ref x3, ref y3, bit3.Width, bit3.Height);
                if (b1 == null && b2 == null && b3 == null)
                    break;
                List<SignValue> sv1, sv2, sv3;
                MapTest(GetMap(b1), GetMap(b2), GetMap(b3), out sv1, out sv2, out sv3, false);
                Images images = new Images
                {
                    Px1 = px1,
                    Px2 = px2,
                    Px3 = px3,
                    Py1 = py1,
                    Py2 = py2,
                    Py3 = py3,
                    Img1 = (sv1.Count > 0) ? sv1 : null,
                    Img2 = (sv2.Count > 0) ? sv2 : null,
                    img3 = (sv3.Count > 0) ? sv3 : null
                };
                lst.Add(images);
            }
            return lst;
        }

        /// <summary>
        /// Осуществляет разбор карт по количеству знаков, равному Map.AllMax. Таким образом, формируются списки выходных знаков.
        /// </summary>
        /// <param name="map1">Карта первого изображения.</param>
        /// <param name="map2">Карта второго изображения.</param>
        /// <param name="map3">Карта третьего изображения.</param>
        /// <param name="sv1">Первый список.</param>
        /// <param name="sv2">Второй список.</param>
        /// <param name="sv3">Третий список.</param>
        /// <param name="toFile">Определяет, следует записывать получаемые карты в файлы или нет.</param>
        static void MapTest(Map map1, Map map2, Map map3, out List<SignValue> sv1, out List<SignValue> sv2, out List<SignValue> sv3, bool toFile)
        {
            Processor ce1 = (map1 == null) ? null : new Processor(map1);
            Processor ce2 = (map2 == null) ? null : new Processor(map2);
            Processor ce3 = (map3 == null) ? null : new Processor(map3);
            sv1 = new List<SignValue>(); sv2 = new List<SignValue>(); sv3 = new List<SignValue>();
            for (int k = 0, plus = SignValue.MaxValue.Value / Map.AllMax, p = 0; p < Map.AllMax; k += plus, p++)
            {
                if (ce1 != null)
                    sv1.Add(ce1.Run(new SignValue(k)).Value);
                if (ce2 != null)
                    sv2.Add(ce2.Run(new SignValue(k)).Value);
                if (ce3 != null)
                    sv3.Add(ce3.Run(new SignValue(k)).Value);
            }
            if (!toFile)
                return;
            if (map1 != null)
                using (FileStream fs = new FileStream(string.Format(@"{0}\{1}", Application.StartupPath, "img1_transformed.xml"), FileMode.Create))
                {
                    map1.ToStream(fs);
                }
            if (map2 != null)
                using (FileStream fs = new FileStream(string.Format(@"{0}\{1}", Application.StartupPath, "img2_transformed.xml"), FileMode.Create))
                {
                    map2.ToStream(fs);
                }
            if (map3 != null)
                using (FileStream fs = new FileStream(string.Format(@"{0}\{1}", Application.StartupPath, "img3_transformed.xml"), FileMode.Create))
                {
                    map3.ToStream(fs);
                }
        }

        /// <summary>
        /// Копирует указанную часть изображения в отдельное изображение.
        /// Если по ширине достигнут конец, то переход на новую строку осуществляется автоматически.
        /// </summary>
        /// <param name="target">Изображение, копию участка которого требуется снять.</param>
        /// <param name="x">Стартовый X.</param>
        /// <param name="y">Стартовый Y.</param>
        /// <param name="wid">Требуемая ширина.</param>
        /// <param name="hei">Требуемая высота.</param>
        /// <returns>Возвращает изображение, представляющее собой указанную часть исходного изображения.</returns>
        static Bitmap GetCurrentBitmap(Bitmap target, ref int x, ref int y, int wid, int hei)
        {
            int mx = x + wid, my = y + hei;
            if (mx > target.Width)
            {
                if (my > target.Height)
                    return null;
                x = 0;
                mx = wid;
                y++;
                my++;
            }
            if (my > target.Height)
                return null;
            Bitmap ret = new Bitmap(wid, hei);
            int sy = y;
            for (int xr = 0; x < mx; x++, xr++)
            {
                for (int yr = 0; y < my; y++, yr++)
                    ret.SetPixel(xr, yr, target.GetPixel(x, y));
                y = sy;
            }
            return ret;
        }

        /// <summary>
        /// Создаёт карту, полученную в результате прогона карты указанного изображения по ряду знаков, количество которых зависит от размера изображения.
        /// </summary>
        /// <param name="target">Разбираемое изображение.</param>
        /// <returns>Возвращает карту, полученную в результате прогона карты изображения по ряду знаков.</returns>
        static Map GetMap(Bitmap target)
        {
            if (target == null)
                return null;
            Map map = new Map();
            GetSign(target).ForEach(it => map.Add(new MapObject { Sign = it }));
            map.ObjectNumeration();
            return map;
        }

        /// <summary>
        /// Преобразует изображение в список знаков.
        /// </summary>
        /// <param name="target">Преобразуемое изображение.</param>
        /// <returns>Возвращает изображение в виде списка знаков.</returns>
        static List<SignValue> BitmapToList(Bitmap target)
        {
            List<SignValue> lst = new List<SignValue>();
            for (int y = 0; y < target.Height; y++)
                for (int x = 0; x < target.Width; x++)
                    lst.Add(new SignValue(target.GetPixel(x, y).ToArgb() & 0x00FFFFFF));
            return lst;
        }

        /// <summary>
        /// Преобразует изображение в список знаков, размера, меньшего или равного Map.AllMax, чтобы уместить их на карту.
        /// При этом, каждый знак, добавляемый в список, проходит прогон по определённому знаку.
        /// Количество знаков для прогонов зависит от размера изображения.
        /// </summary>
        /// <param name="target">Преобразуемое изображение.</param>
        /// <returns>Возвращает список знаков, размера, меньшего или равного Map.AllMax.</returns>
        static List<SignValue> GetSign(Bitmap target)
        {
            List<SignValue> lst = BitmapToList(target);
            int plus = SignValue.MaxValue.Value / Map.AllMax; SignValue sv = SignValue.MinValue;
            while (lst.Count > Map.AllMax)
            {
                List<SignValue> nlst = new List<SignValue>();
                int k = 0; SignValue? val = null;
                while ((val = Parse(lst, ref k, sv)) != null)
                    nlst.Add(val.Value);
                sv = new SignValue(sv + plus);
                lst = nlst;
            }
            return lst;
        }

        /// <summary>
        /// Сжимает указанный список знаков по две позиции за каждый раз.
        /// </summary>
        /// <param name="target">Преобразуемый список.</param>
        /// <param name="k">Стартовая позиция для преобразования.</param>
        /// <param name="sv">Знак для преобразования.</param>
        /// <returns>Возвращает знак после преобразования или null в случае окончания операции.</returns>
        static SignValue? Parse(List<SignValue> target, ref int k, SignValue sv)
        {
            Map map = new Map();
            int mx = (target.Count % 2 != 0) ? target.Count - 1 : target.Count;
            for (int x = 0; x < 2 && k < mx; x++, k++)
                map.Add(new MapObject { Sign = target[k] });
            Processor ce = new Processor(map);
            return ce.Run(sv);
        }
    }
}